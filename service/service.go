// Copyright (c) 2023, donnie <donnie4w@gmail.com>
// All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.
//
// github.com/donnie4w/tim
package service

import (
	"sort"
	"time"

	. "github.com/donnie4w/gofer/util"
	"github.com/donnie4w/tim/data"
	. "github.com/donnie4w/tim/stub"
	"github.com/donnie4w/tim/sys"
	"github.com/donnie4w/tim/util"
	"github.com/donnie4w/tim/vgate"
	"github.com/donnie4w/tlnet"
)

var service = &timservice{}

type timservice struct{}

func (this *timservice) osregister(name, pwd string, domain *string) (node string, e sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	return data.Handler.Register(name, pwd, domain)
}

func (this *timservice) register(bs []byte) (node string, e sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	var ta *TimAuth
	var err error
	if util.JTP(bs[0]) {
		ta, err = JsonDecode[*TimAuth](bs[1:])
	} else {
		ta, err = TDecode(bs[1:], &TimAuth{})
	}
	if err == nil {
		node, e = data.Handler.Register(*ta.Name, *ta.Pwd, ta.Domain)
	} else {
		e = sys.ERR_PARAMS
	}
	return
}

func (this *timservice) ping(ws *tlnet.Websocket) (err sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	wsware.SendWs(ws.Id, nil, sys.TIMPING)
	return
}

func (this *timservice) ack(bs []byte) (err sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	awaitEnd(bs[1:])
	return
}

func (this *timservice) ostoken(node string, domain *string) (_r int64, e sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	if !existUser(&Tid{Node: node, Domain: domain}) {
		return _r, sys.ERR_NOEXIST
	}
	tid := &Tid{Node: node, Domain: domain}
	_r = token()
	tokenTempCache.Add(_r, tid)
	return
}

func (this *timservice) token(bs []byte) (_r int64, e sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	ta := newAuth(bs)
	if ta == nil {
		return _r, sys.ERR_PARAMS
	}
	var node string
	if node, e = data.Handler.Token(*ta.Name, *ta.Pwd, ta.Domain); e == nil {
		tid := &Tid{Node: node, Domain: ta.Domain, Extend: ta.Extend}
		_r = token()
		tokenTempCache.Add(_r, tid)
	}
	return
}

func (this *timservice) auth(bs []byte, ws *tlnet.Websocket) (e sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	if wsware.wsmap.Has(ws.Id) {
		wsware.SendWs(ws.Id, &TimAck{Ok: true, TimType: int8(sys.TIMAUTH)}, sys.TIMACK)
		return
	}
	ta := newAuth(bs)
	if ta == nil {
		return sys.ERR_PARAMS
	}
	if ta != nil {
		isAuth := false
		var tid *Tid
		if ta.Token != nil {
			if tid, _ = tokenTempCache.Get(*ta.Token); tid != nil {
				tid.Resource, tid.Termtyp = ta.Resource, ta.Termtyp
				tokenTempCache.Remove(*ta.Token)
				if !isblock(tid.Node) {
					isAuth = true
				}
			}
		} else if ta.Name != nil && ta.Pwd != nil && !isblock(*ta.Name) {
			if _r, err := data.Handler.Login(*ta.Name, *ta.Pwd, ta.Domain); err == nil {
				tid = &Tid{Node: _r, Domain: ta.Domain, Extend: ta.Extend, Resource: ta.Resource, Termtyp: ta.Termtyp}
				if !isblock(_r) {
					isAuth = true
				}
			}
		}
		if isAuth {
			overentry := true
			if wsware.GetUserDeviceLen(tid.Node) < sys.DeviceLimit {
				wis := sys.CsWssInfo(tid.Node)
				if len(wis)+wsware.GetUserDeviceLen(tid.Node) < sys.DeviceLimit {
					overentry = false
					if tid.Termtyp != nil {
						typebs := wsware.GetUserDeviceTypeLen(tid.Node)
						c := 0
						for _, u := range append(wis, typebs...) {
							if u == byte(*tid.Termtyp) {
								c++
							}
						}
						if c > sys.DeviceTypeLimit {
							overentry = true
						}
					}
				}
			}
			if overentry {
				return sys.ERR_OVERENTRY
			}
			wsware.AddTid(ws, tid)
			if util.JTP(bs[0]) {
				wsware.SetJsonOn(ws)
			}
			wsware.SendWs(ws.Id, &TimAck{Ok: true, TimType: int8(sys.TIMAUTH), N: &tid.Node}, sys.TIMACK)
		} else {
			e = sys.ERR_AUTH
		}
	}
	return
}

func sysMessage(tn *TimNodes, tm *TimMessage) (err sys.ERROR) {
	if tn == nil && tm == nil {
		return sys.ERR_PARAMS
	}
	if checkList(tn.Nodelist) {
		t := time.Now().UnixNano()
		for _, u := range tn.Nodelist {
			tm.ToTid = &Tid{Node: u}
			tm.Timestamp = &t
			service.osmessage(tm)
		}
	} else {
		return sys.ERR_ACCOUNT
	}
	return
}

func (this *timservice) osmessage(tm *TimMessage) (err sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	if tm == nil || tm.ToTid == nil {
		return sys.ERR_PARAMS
	}
	tm.MsType, tm.OdType = sys.SOURCE_OS, sys.ORDER_INOF
	return sys.TimMessageProcessor(tm, sys.TRANS_SOURCE)
}

func (this *timservice) message(bs []byte, ws *tlnet.Websocket) (_r sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	tm := newTimMessage(bs)
	if tm == nil || tm.MsType == sys.SOURCE_OS {
		return sys.ERR_PARAMS
	}
	if !checkTid(tm.ToTid) || !checkTid(tm.RoomTid) {
		return sys.ERR_ACCOUNT
	}

	if wss, b := wsware.Get(ws); b {
		tm.FromTid = wss.tid
		if !existUser(tm.ToTid) || !existGroup(tm.RoomTid) {
			return sys.ERR_ACCOUNT
		}
		if tm.MsType == sys.SOURCE_ROOM {
			if tm.RoomTid != nil && authGroup(tm.RoomTid.Node, tm.FromTid.Node, tm.FromTid.Domain) {
				var err error
				switch tm.OdType {
				case sys.ORDER_INOF:
					err = data.Handler.SaveMessage(tm)
				case sys.ORDER_REVOKE:
					if tm.Mid == nil || *tm.Mid == 0 {
						return sys.ERR_PARAMS
					}
					tid := util.ChatIdByRoom(tm.RoomTid.Node, wss.tid.Domain)
					if _t, err := data.Handler.GetMessageByMid(tid, *tm.Mid); err == nil && _t != nil {
						if _t.FromTid.Node == tm.FromTid.Node && _t.RoomTid.Node == tm.RoomTid.Node {
							err = data.Handler.DelMessageByMid(tid, *tm.Mid)
						} else {
							return sys.ERR_AUTH
						}
					} else {
						return sys.ERR_PARAMS
					}
				case sys.ORDER_STREAM:
				default:
					return sys.ERR_PARAMS
				}
				if err == nil {
					if tm.OdType != sys.ORDER_STREAM {
						wsware.SendNode(tm.FromTid.Node, tm, sys.TIMMESSAGE)
					}
					if rs := data.Handler.GroupRoster(tm.RoomTid.Node); rs != nil && len(rs) > 0 {
						for _, u := range rs {
							if u != wss.tid.Node {
								t := newTimMessage(bs)
								t.FromTid, t.Mid, t.Timestamp, t.ToTid = wss.tid, tm.Mid, tm.Timestamp, &Tid{Node: u}
								util.GoPoolTx.Go(func() { sys.TimMessageProcessor(t, sys.TRANS_SOURCE) })
							}
						}
					}
				}
			} else {
				return sys.ERR_AUTH
			}
		} else if tm.MsType == sys.SOURCE_USER {
			if tm.RoomTid != nil && tm.ToTid != nil {
				if authGroup(tm.RoomTid.Node, tm.FromTid.Node, tm.FromTid.Domain) && authGroup(tm.RoomTid.Node, tm.ToTid.Node, tm.FromTid.Domain) {
					return this.messagehandle(bs, tm)
				} else {
					return sys.ERR_AUTH
				}
			} else if tm.ToTid != nil && authTidNode(tm.FromTid, tm.ToTid) {
				return this.messagehandle(bs, tm)
			} else {
				return sys.ERR_AUTH
			}
		} else {
			return sys.ERR_PARAMS
		}
	}
	return
}

func (this *timservice) messagehandle(bs []byte, tm *TimMessage) (_r sys.ERROR) {
	ok := true
	switch tm.OdType {
	case sys.ORDER_INOF:
		if err := data.Handler.SaveMessage(tm); err == nil {
			wsware.SendNode(tm.FromTid.Node, tm, sys.TIMMESSAGE)
		} else {
			return sys.ERR_DATABASE
		}
	case sys.ORDER_REVOKE:
		if tm.Mid == nil || *tm.Mid == 0 {
			return sys.ERR_PARAMS
		}
		tid := util.ChatIdByNode(tm.FromTid.Node, tm.ToTid.Node, tm.FromTid.Domain)
		if _t, err := data.Handler.GetMessageByMid(tid, *tm.Mid); err == nil && _t != nil {
			if _t.FromTid.Node == tm.FromTid.Node && _t.ToTid.Node == tm.ToTid.Node {
				if err = data.Handler.DelMessageByMid(tid, *tm.Mid); err == nil {
					t := newTimMessage(bs)
					t.FromTid, t.ToTid = tm.FromTid, tm.FromTid
					sys.TimMessageProcessor(t, sys.TRANS_SOURCE)
				}
				ok = true
			} else {
				return sys.ERR_AUTH
			}
		} else {
			return sys.ERR_PARAMS
		}
	case sys.ORDER_BURN:
		if tm.Mid == nil || *tm.Mid == 0 {
			return sys.ERR_PARAMS
		}
		tid := util.ChatIdByNode(tm.FromTid.Node, tm.ToTid.Node, tm.FromTid.Domain)
		if _t, err := data.Handler.GetMessageByMid(tid, *tm.Mid); err == nil && _t != nil {
			if _t.FromTid.Node == tm.ToTid.Node && _t.ToTid.Node == tm.FromTid.Node {
				if err = data.Handler.DelMessageByMid(tid, *tm.Mid); err == nil {
					t := newTimMessage(bs)
					t.FromTid, t.ToTid = tm.FromTid, tm.FromTid
					sys.TimMessageProcessor(t, sys.TRANS_SOURCE)
				}
				ok = true
			} else {
				return sys.ERR_AUTH
			}
		} else {
			return sys.ERR_PARAMS
		}
	case sys.ORDER_BUSINESS, sys.ORDER_STREAM:
	default:
		if tm.OdType <= sys.ORDER_RESERVED {
			return sys.ERR_PARAMS
		}
	}
	if ok {
		_r = sys.TimMessageProcessor(tm, sys.TRANS_SOURCE)
	} else {
		return sys.ERR_PARAMS
	}
	return
}

func (this *timservice) presence(bs []byte, ws *tlnet.Websocket) (_r sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	tp := newTimPresence(bs)
	if tp == nil {
		return sys.ERR_PARAMS
	}
	if !checkTid(tp.ToTid) || !checkList(tp.ToList) {
		return sys.ERR_ACCOUNT
	}
	if wss, b := wsware.Get(ws); b {
		tp.FromTid = wss.tid
		if !existUser(tp.ToTid) || !existList(tp.ToList, tp.FromTid.Domain) {
			return sys.ERR_ACCOUNT
		}
		if tp.ToList != nil {
			sys.TimPresenceProcessor(tp, sys.TRANS_STAFF)
		} else if tp.ToTid != nil {
			sys.TimPresenceProcessor(tp, sys.TRANS_SOURCE)
		}
	}
	return
}

func (this *timservice) interrupt(tid *Tid) (err sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	if !wsware.hasUser(tid.Node) {
		if !sys.Conf.PresenceOfflineBlock {
			a := true
			if rs := data.Handler.Roster(tid.Node); rs != nil && len(rs) > 0 {
				rid := RandId()
				tp := &TimPresence{ID: &rid, FromTid: tid, ToList: rs, Offline: &a}
				sys.TimPresenceProcessor(tp, sys.TRANS_STAFF)
			}
			rid := RandId()
			tp := &TimPresence{ID: &rid, FromTid: tid, ToTid: tid, Offline: &a}
			sys.TimPresenceProcessor(tp, sys.TRANS_SOURCE)
		}
	}
	return
}

func (this *timservice) offlineMsg(ws *tlnet.Websocket) (err sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	if wss, ok := wsware.Get(ws); ok {
		if oblist, err := data.Handler.GetOfflineMessage(wss.tid, 10); err == nil && oblist != nil && len(oblist) > 0 {
			tmList := make([]*TimMessage, 0)
			isOff := true
			ids := make([]int64, 0)
			for _, ob := range oblist {
				ids = append(ids, ob.Id)
				if ob.Stanze != nil {
					if tm, err := TDecode(ob.Stanze, &TimMessage{}); err == nil {
						tm.IsOffline = &isOff
						tmList = append(tmList, tm)
						if ob.Mid > 0 {
							tm.Mid = &ob.Mid
						}
					}
				}
			}
			sort.Slice(tmList, func(i, j int) bool {
				return *tmList[i].Timestamp < *tmList[j].Timestamp
			})
			id := RandId()
			if wsware.SendWsWithAck(ws.Id, &TimMessageList{MessageList: tmList, ID: &id}, sys.TIMOFFLINEMSG) {
				if _r, err := data.Handler.DelOfflineMessage(util.NodeToUUID(wss.tid.Node), ids...); err == nil && _r > 0 {
					this.offlineMsg(ws)
				}
			}
		} else if err == nil {
			wsware.SendWs(ws.Id, nil, sys.TIMOFFLINEMSGEND)
		} else {
			return sys.ERR_DATABASE
		}
	}
	return
}

func (this *timservice) broadpresence(bs []byte, ws *tlnet.Websocket) (e sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	tp := newTimPresence(bs)
	if tp == nil {
		return sys.ERR_PARAMS
	}
	if wss, ok := wsware.Get(ws); ok {
		fid := wss.tid
		if tp.ToTid == nil && tp.ToList == nil {
			if rs := data.Handler.Roster(wss.tid.Node); rs != nil && len(rs) > 0 {
				for i := 0; i < len(rs); i++ {
					t := &TimPresence{FromTid: fid, ToTid: &Tid{Node: rs[i]}, SubStatus: tp.SubStatus, Show: tp.Show, Status: tp.Status, Extend: tp.Extend, Extra: tp.Extra}
					sys.TimPresenceProcessor(t, sys.TRANS_SOURCE)
				}
			}
		} else {
			tp.FromTid = fid
			if tp.ToTid != nil {
				tp.ToList = nil
				sys.TimPresenceProcessor(tp, sys.TRANS_SOURCE)
			} else if tp.ToList != nil {
				tp.ToTid = nil
				for _, u := range tp.ToList {
					t := &TimPresence{FromTid: fid, ToTid: &Tid{Node: u}, SubStatus: tp.SubStatus, Show: tp.Show, Status: tp.Status, Extend: tp.Extend, Extra: tp.Extra}
					sys.TimPresenceProcessor(t, sys.TRANS_SOURCE)
				}
			}
		}
	}
	return
}

func (this *timservice) pullmessage(bs []byte, ws *tlnet.Websocket) (err sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	tr := newTimReq(bs)
	if tr == nil || tr.Rtype == nil || tr.Node == nil || tr.ReqInt == nil || tr.ReqInt2 == nil || !checkNode(*tr.Node) {
		return sys.ERR_PARAMS
	}
	if wss, b := wsware.Get(ws); b {
		if *tr.Rtype == 2 {
			if !authGroup(*tr.Node, wss.tid.Node, wss.tid.Domain) {
				return sys.ERR_AUTH
			}
		}
		if oblist, err := data.Handler.GetMessage(wss.tid, int8(*tr.Rtype), *tr.Node, *tr.ReqInt, *tr.ReqInt2); err == nil && oblist != nil && len(oblist) > 0 {
			if oblist[0].Mid == tr.ReqInt {
				oblist = oblist[1:]
			}
			sort.Slice(oblist, func(i, j int) bool { return *oblist[i].Mid > *oblist[j].Mid })
			wsware.SendWs(ws.Id, &TimMessageList{MessageList: oblist}, sys.TIMPULLMESSAGE)
		}
	}
	return
}

func (this *timservice) osvroomprocess(node string, rtype int8) (_r string) {
	switch rtype {
	case 1:
		vnode := vgate.VGate.NewVRoom(node)
		if sys.CsVBean(&VBean{Rtype: 1, Vnode: vnode, FoundNode: &node}) {
			_r = vnode
		}
	}
	return
}

func (this *timservice) vroomprocess(bs []byte, ws *tlnet.Websocket) (err sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	tr := newTimReq(bs)
	if tr == nil || tr.Rtype == nil {
		return sys.ERR_PARAMS
	}
	if wss, b := wsware.Get(ws); b {
		t := int64(*tr.Rtype)
		switch t {
		case 1:
			vnode := vgate.VGate.NewVRoom(wss.tid.Node)
			if sys.CsVBean(&VBean{Rtype: 1, Vnode: vnode, FoundNode: &wss.tid.Node}) {
				wsware.SendWs(ws.Id, &TimAck{Ok: true, TimType: int8(sys.TIMVROOM), N: &vnode, T: &t}, sys.TIMACK)
			} else {
				return sys.ERR_UNDEFINED
			}
		case 2:
			if tr.Node == nil || !util.CheckNode(*tr.Node) {
				return sys.ERR_PARAMS
			}
			vgate.VGate.Remove(wss.tid.Node, *tr.Node)
			sys.CsVBean(&VBean{Rtype: 2, Vnode: *tr.Node, FoundNode: &wss.tid.Node})
			wsware.SendWs(ws.Id, &TimAck{Ok: true, TimType: int8(sys.TIMVROOM), N: tr.Node, T: &t}, sys.TIMACK)
		case 3:
			if tr.Node == nil || tr.Node2 == nil || !util.CheckNode(*tr.Node) || !checkNode(*tr.Node2) {
				return sys.ERR_PARAMS
			}
			vgate.VGate.AddAuth(*tr.Node, wss.tid.Node, *tr.Node2)
			sys.CsVBean(&VBean{Rtype: 3, Vnode: *tr.Node, FoundNode: &wss.tid.Node, Rnode: tr.Node2})
			wsware.SendWs(ws.Id, &TimAck{Ok: true, TimType: int8(sys.TIMVROOM), N: tr.Node2, T: &t}, sys.TIMACK)
		case 4:
			if tr.Node == nil || tr.Node2 == nil || !util.CheckNode(*tr.Node) || !util.CheckNode(*tr.Node2) {
				return sys.ERR_PARAMS
			}
			vgate.VGate.DelAuth(*tr.Node, wss.tid.Node, *tr.Node2)
			sys.CsVBean(&VBean{Rtype: 4, Vnode: *tr.Node, FoundNode: &wss.tid.Node, Rnode: tr.Node2})
			wsware.SendWs(ws.Id, &TimAck{Ok: true, TimType: int8(sys.TIMVROOM), N: tr.Node2, T: &t}, sys.TIMACK)
		case 5:
			if tr.Node == nil || !util.CheckNode(*tr.Node) {
				return sys.ERR_PARAMS
			}
			vgate.VGate.Sub(*tr.Node, sys.UUID, wss.ws.Id)
			if sys.CsVBean(&VBean{Rtype: 5, Vnode: *tr.Node, Rnode: &wss.tid.Node}) {
				wsware.SendWs(ws.Id, &TimAck{Ok: true, TimType: int8(sys.TIMVROOM), N: tr.Node, T: &t}, sys.TIMACK)
			} else {
				return sys.ERR_UNDEFINED
			}
		case 6:
			if tr.Node == nil || !util.CheckNode(*tr.Node) {
				return sys.ERR_PARAMS
			}
			if vgate.VGate.DelNode(*tr.Node, wss.ws.Id) == 0 {
				sys.CsVBean(&VBean{Rtype: 6, Vnode: *tr.Node})
			}
			wsware.SendWs(ws.Id, &TimAck{Ok: true, TimType: int8(sys.TIMVROOM), N: tr.Node, T: &t}, sys.TIMACK)
		default:
			return sys.ERR_PARAMS
		}
	}
	return
}

func (this *timservice) stream(bs []byte, ws *tlnet.Websocket) (err sys.ERROR) {
	defer util.Recover()
	sys.Stat.TxDo()
	defer sys.Stat.TxDone()
	ts := newTimStream(bs)
	if ts == nil || !util.CheckNode(ts.VNode) {
		return sys.ERR_PARAMS
	}
	if wss, b := wsware.Get(ws); b {
		if sys.CsNode(ts.VNode) == sys.UUID {
			auth := false
			if vr, ok := vgate.VGate.GetVroom(ts.VNode); ok {
				auth = vr.Auth(wss.tid.Node)
			}
			if !auth {
				wsware.SendWs(ws.Id, &TimAck{Ok: false, TimType: int8(sys.TIMSTREAM), Error: sys.ERR_AUTH.TimError(), N: &ts.VNode}, sys.TIMACK)
				return
			}
		}
		// vb := &VBean{Vnode: ts.VNode, Rnode: &wss.tid.Node, Body: ts.Body, Dtype: ts.Dtype, StreamId: &ts.ID}
		// go sys.TimSteamProcessor(vb)
		csvb := &VBean{Vnode: ts.VNode, Rnode: &wss.tid.Node, Body: ts.Body, Dtype: ts.Dtype, Rtype: 7, StreamId: &ts.ID}
		sys.CsVBean(csvb)
	}
	return
}
