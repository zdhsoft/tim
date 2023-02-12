// Code generated by Thrift Compiler (0.17.0). DO NOT EDIT.

package main

import (
	"context"
	"flag"
	"fmt"
	"math"
	"net"
	"net/url"
	"os"
	"strconv"
	"strings"
	thrift "github.com/apache/thrift/lib/go/thrift"
	"protocol"
)

var _ = protocol.GoUnusedProtection__

func Usage() {
  fmt.Fprintln(os.Stderr, "Usage of ", os.Args[0], " [-h host:port] [-u url] [-f[ramed]] function [arg1 [arg2...]]:")
  flag.PrintDefaults()
  fmt.Fprintln(os.Stderr, "\nFunctions:")
  fmt.Fprintln(os.Stderr, "  void timStream(TimParam param)")
  fmt.Fprintln(os.Stderr, "  void timStarttls()")
  fmt.Fprintln(os.Stderr, "  void timLogin(Tid tid, string pwd)")
  fmt.Fprintln(os.Stderr, "  void timAck(TimAckBean ab)")
  fmt.Fprintln(os.Stderr, "  void timPresence(TimPBean pbean)")
  fmt.Fprintln(os.Stderr, "  void timMessage(TimMBean mbean)")
  fmt.Fprintln(os.Stderr, "  void timPing(string threadId)")
  fmt.Fprintln(os.Stderr, "  void timError(TimError e)")
  fmt.Fprintln(os.Stderr, "  void timLogout()")
  fmt.Fprintln(os.Stderr, "  void timRegist(Tid tid, string auth)")
  fmt.Fprintln(os.Stderr, "  void timRoser(TimRoster roster)")
  fmt.Fprintln(os.Stderr, "  void timMessageList(TimMBeanList mbeanList)")
  fmt.Fprintln(os.Stderr, "  void timPresenceList(TimPBeanList pbeanList)")
  fmt.Fprintln(os.Stderr, "  void timMessageIq(TimMessageIq timMsgIq, string iqType)")
  fmt.Fprintln(os.Stderr, "  void timMessageResult(TimMBean mbean)")
  fmt.Fprintln(os.Stderr, "  void timProperty(TimPropertyBean tpb)")
  fmt.Fprintln(os.Stderr, "  TimRemoteUserBean timRemoteUserAuth(Tid tid, string pwd, TimAuth auth)")
  fmt.Fprintln(os.Stderr, "  TimRemoteUserBean timRemoteUserGet(Tid tid, TimAuth auth)")
  fmt.Fprintln(os.Stderr, "  TimRemoteUserBean timRemoteUserEdit(Tid tid, TimUserBean ub, TimAuth auth)")
  fmt.Fprintln(os.Stderr, "  TimResponseBean timResponsePresence(TimPBean pbean, TimAuth auth)")
  fmt.Fprintln(os.Stderr, "  TimResponseBean timResponseMessage(TimMBean mbean, TimAuth auth)")
  fmt.Fprintln(os.Stderr, "  TimMBeanList timResponseMessageIq(TimMessageIq timMsgIq, string iqType, TimAuth auth)")
  fmt.Fprintln(os.Stderr, "  TimResponseBean timResponsePresenceList(TimPBeanList pbeanList, TimAuth auth)")
  fmt.Fprintln(os.Stderr, "  TimResponseBean timResponseMessageList(TimMBeanList mbeanList, TimAuth auth)")
  fmt.Fprintln(os.Stderr)
  os.Exit(0)
}

type httpHeaders map[string]string

func (h httpHeaders) String() string {
  var m map[string]string = h
  return fmt.Sprintf("%s", m)
}

func (h httpHeaders) Set(value string) error {
  parts := strings.Split(value, ": ")
  if len(parts) != 2 {
    return fmt.Errorf("header should be of format 'Key: Value'")
  }
  h[parts[0]] = parts[1]
  return nil
}

func main() {
  flag.Usage = Usage
  var host string
  var port int
  var protocol string
  var urlString string
  var framed bool
  var useHttp bool
  headers := make(httpHeaders)
  var parsedUrl *url.URL
  var trans thrift.TTransport
  _ = strconv.Atoi
  _ = math.Abs
  flag.Usage = Usage
  flag.StringVar(&host, "h", "localhost", "Specify host and port")
  flag.IntVar(&port, "p", 9090, "Specify port")
  flag.StringVar(&protocol, "P", "binary", "Specify the protocol (binary, compact, simplejson, json)")
  flag.StringVar(&urlString, "u", "", "Specify the url")
  flag.BoolVar(&framed, "framed", false, "Use framed transport")
  flag.BoolVar(&useHttp, "http", false, "Use http")
  flag.Var(headers, "H", "Headers to set on the http(s) request (e.g. -H \"Key: Value\")")
  flag.Parse()
  
  if len(urlString) > 0 {
    var err error
    parsedUrl, err = url.Parse(urlString)
    if err != nil {
      fmt.Fprintln(os.Stderr, "Error parsing URL: ", err)
      flag.Usage()
    }
    host = parsedUrl.Host
    useHttp = len(parsedUrl.Scheme) <= 0 || parsedUrl.Scheme == "http" || parsedUrl.Scheme == "https"
  } else if useHttp {
    _, err := url.Parse(fmt.Sprint("http://", host, ":", port))
    if err != nil {
      fmt.Fprintln(os.Stderr, "Error parsing URL: ", err)
      flag.Usage()
    }
  }
  
  cmd := flag.Arg(0)
  var err error
  var cfg *thrift.TConfiguration = nil
  if useHttp {
    trans, err = thrift.NewTHttpClient(parsedUrl.String())
    if len(headers) > 0 {
      httptrans := trans.(*thrift.THttpClient)
      for key, value := range headers {
        httptrans.SetHeader(key, value)
      }
    }
  } else {
    portStr := fmt.Sprint(port)
    if strings.Contains(host, ":") {
           host, portStr, err = net.SplitHostPort(host)
           if err != nil {
                   fmt.Fprintln(os.Stderr, "error with host:", err)
                   os.Exit(1)
           }
    }
    trans = thrift.NewTSocketConf(net.JoinHostPort(host, portStr), cfg)
    if err != nil {
      fmt.Fprintln(os.Stderr, "error resolving address:", err)
      os.Exit(1)
    }
    if framed {
      trans = thrift.NewTFramedTransportConf(trans, cfg)
    }
  }
  if err != nil {
    fmt.Fprintln(os.Stderr, "Error creating transport", err)
    os.Exit(1)
  }
  defer trans.Close()
  var protocolFactory thrift.TProtocolFactory
  switch protocol {
  case "compact":
    protocolFactory = thrift.NewTCompactProtocolFactoryConf(cfg)
    break
  case "simplejson":
    protocolFactory = thrift.NewTSimpleJSONProtocolFactoryConf(cfg)
    break
  case "json":
    protocolFactory = thrift.NewTJSONProtocolFactory()
    break
  case "binary", "":
    protocolFactory = thrift.NewTBinaryProtocolFactoryConf(cfg)
    break
  default:
    fmt.Fprintln(os.Stderr, "Invalid protocol specified: ", protocol)
    Usage()
    os.Exit(1)
  }
  iprot := protocolFactory.GetProtocol(trans)
  oprot := protocolFactory.GetProtocol(trans)
  client := protocol.NewITimClient(thrift.NewTStandardClient(iprot, oprot))
  if err := trans.Open(); err != nil {
    fmt.Fprintln(os.Stderr, "Error opening socket to ", host, ":", port, " ", err)
    os.Exit(1)
  }
  
  switch cmd {
  case "timStream":
    if flag.NArg() - 1 != 1 {
      fmt.Fprintln(os.Stderr, "TimStream requires 1 args")
      flag.Usage()
    }
    arg159 := flag.Arg(1)
    mbTrans160 := thrift.NewTMemoryBufferLen(len(arg159))
    defer mbTrans160.Close()
    _, err161 := mbTrans160.WriteString(arg159)
    if err161 != nil {
      Usage()
      return
    }
    factory162 := thrift.NewTJSONProtocolFactory()
    jsProt163 := factory162.GetProtocol(mbTrans160)
    argvalue0 := protocol.NewTimParam()
    err164 := argvalue0.Read(context.Background(), jsProt163)
    if err164 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    fmt.Print(client.TimStream(context.Background(), value0))
    fmt.Print("\n")
    break
  case "timStarttls":
    if flag.NArg() - 1 != 0 {
      fmt.Fprintln(os.Stderr, "TimStarttls requires 0 args")
      flag.Usage()
    }
    fmt.Print(client.TimStarttls(context.Background()))
    fmt.Print("\n")
    break
  case "timLogin":
    if flag.NArg() - 1 != 2 {
      fmt.Fprintln(os.Stderr, "TimLogin requires 2 args")
      flag.Usage()
    }
    arg165 := flag.Arg(1)
    mbTrans166 := thrift.NewTMemoryBufferLen(len(arg165))
    defer mbTrans166.Close()
    _, err167 := mbTrans166.WriteString(arg165)
    if err167 != nil {
      Usage()
      return
    }
    factory168 := thrift.NewTJSONProtocolFactory()
    jsProt169 := factory168.GetProtocol(mbTrans166)
    argvalue0 := protocol.NewTid()
    err170 := argvalue0.Read(context.Background(), jsProt169)
    if err170 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    argvalue1 := flag.Arg(2)
    value1 := argvalue1
    fmt.Print(client.TimLogin(context.Background(), value0, value1))
    fmt.Print("\n")
    break
  case "timAck":
    if flag.NArg() - 1 != 1 {
      fmt.Fprintln(os.Stderr, "TimAck requires 1 args")
      flag.Usage()
    }
    arg172 := flag.Arg(1)
    mbTrans173 := thrift.NewTMemoryBufferLen(len(arg172))
    defer mbTrans173.Close()
    _, err174 := mbTrans173.WriteString(arg172)
    if err174 != nil {
      Usage()
      return
    }
    factory175 := thrift.NewTJSONProtocolFactory()
    jsProt176 := factory175.GetProtocol(mbTrans173)
    argvalue0 := protocol.NewTimAckBean()
    err177 := argvalue0.Read(context.Background(), jsProt176)
    if err177 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    fmt.Print(client.TimAck(context.Background(), value0))
    fmt.Print("\n")
    break
  case "timPresence":
    if flag.NArg() - 1 != 1 {
      fmt.Fprintln(os.Stderr, "TimPresence requires 1 args")
      flag.Usage()
    }
    arg178 := flag.Arg(1)
    mbTrans179 := thrift.NewTMemoryBufferLen(len(arg178))
    defer mbTrans179.Close()
    _, err180 := mbTrans179.WriteString(arg178)
    if err180 != nil {
      Usage()
      return
    }
    factory181 := thrift.NewTJSONProtocolFactory()
    jsProt182 := factory181.GetProtocol(mbTrans179)
    argvalue0 := protocol.NewTimPBean()
    err183 := argvalue0.Read(context.Background(), jsProt182)
    if err183 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    fmt.Print(client.TimPresence(context.Background(), value0))
    fmt.Print("\n")
    break
  case "timMessage":
    if flag.NArg() - 1 != 1 {
      fmt.Fprintln(os.Stderr, "TimMessage requires 1 args")
      flag.Usage()
    }
    arg184 := flag.Arg(1)
    mbTrans185 := thrift.NewTMemoryBufferLen(len(arg184))
    defer mbTrans185.Close()
    _, err186 := mbTrans185.WriteString(arg184)
    if err186 != nil {
      Usage()
      return
    }
    factory187 := thrift.NewTJSONProtocolFactory()
    jsProt188 := factory187.GetProtocol(mbTrans185)
    argvalue0 := protocol.NewTimMBean()
    err189 := argvalue0.Read(context.Background(), jsProt188)
    if err189 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    fmt.Print(client.TimMessage(context.Background(), value0))
    fmt.Print("\n")
    break
  case "timPing":
    if flag.NArg() - 1 != 1 {
      fmt.Fprintln(os.Stderr, "TimPing requires 1 args")
      flag.Usage()
    }
    argvalue0 := flag.Arg(1)
    value0 := argvalue0
    fmt.Print(client.TimPing(context.Background(), value0))
    fmt.Print("\n")
    break
  case "timError":
    if flag.NArg() - 1 != 1 {
      fmt.Fprintln(os.Stderr, "TimError requires 1 args")
      flag.Usage()
    }
    arg191 := flag.Arg(1)
    mbTrans192 := thrift.NewTMemoryBufferLen(len(arg191))
    defer mbTrans192.Close()
    _, err193 := mbTrans192.WriteString(arg191)
    if err193 != nil {
      Usage()
      return
    }
    factory194 := thrift.NewTJSONProtocolFactory()
    jsProt195 := factory194.GetProtocol(mbTrans192)
    argvalue0 := protocol.NewTimError()
    err196 := argvalue0.Read(context.Background(), jsProt195)
    if err196 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    fmt.Print(client.TimError(context.Background(), value0))
    fmt.Print("\n")
    break
  case "timLogout":
    if flag.NArg() - 1 != 0 {
      fmt.Fprintln(os.Stderr, "TimLogout requires 0 args")
      flag.Usage()
    }
    fmt.Print(client.TimLogout(context.Background()))
    fmt.Print("\n")
    break
  case "timRegist":
    if flag.NArg() - 1 != 2 {
      fmt.Fprintln(os.Stderr, "TimRegist requires 2 args")
      flag.Usage()
    }
    arg197 := flag.Arg(1)
    mbTrans198 := thrift.NewTMemoryBufferLen(len(arg197))
    defer mbTrans198.Close()
    _, err199 := mbTrans198.WriteString(arg197)
    if err199 != nil {
      Usage()
      return
    }
    factory200 := thrift.NewTJSONProtocolFactory()
    jsProt201 := factory200.GetProtocol(mbTrans198)
    argvalue0 := protocol.NewTid()
    err202 := argvalue0.Read(context.Background(), jsProt201)
    if err202 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    argvalue1 := flag.Arg(2)
    value1 := argvalue1
    fmt.Print(client.TimRegist(context.Background(), value0, value1))
    fmt.Print("\n")
    break
  case "timRoser":
    if flag.NArg() - 1 != 1 {
      fmt.Fprintln(os.Stderr, "TimRoser requires 1 args")
      flag.Usage()
    }
    arg204 := flag.Arg(1)
    mbTrans205 := thrift.NewTMemoryBufferLen(len(arg204))
    defer mbTrans205.Close()
    _, err206 := mbTrans205.WriteString(arg204)
    if err206 != nil {
      Usage()
      return
    }
    factory207 := thrift.NewTJSONProtocolFactory()
    jsProt208 := factory207.GetProtocol(mbTrans205)
    argvalue0 := protocol.NewTimRoster()
    err209 := argvalue0.Read(context.Background(), jsProt208)
    if err209 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    fmt.Print(client.TimRoser(context.Background(), value0))
    fmt.Print("\n")
    break
  case "timMessageList":
    if flag.NArg() - 1 != 1 {
      fmt.Fprintln(os.Stderr, "TimMessageList requires 1 args")
      flag.Usage()
    }
    arg210 := flag.Arg(1)
    mbTrans211 := thrift.NewTMemoryBufferLen(len(arg210))
    defer mbTrans211.Close()
    _, err212 := mbTrans211.WriteString(arg210)
    if err212 != nil {
      Usage()
      return
    }
    factory213 := thrift.NewTJSONProtocolFactory()
    jsProt214 := factory213.GetProtocol(mbTrans211)
    argvalue0 := protocol.NewTimMBeanList()
    err215 := argvalue0.Read(context.Background(), jsProt214)
    if err215 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    fmt.Print(client.TimMessageList(context.Background(), value0))
    fmt.Print("\n")
    break
  case "timPresenceList":
    if flag.NArg() - 1 != 1 {
      fmt.Fprintln(os.Stderr, "TimPresenceList requires 1 args")
      flag.Usage()
    }
    arg216 := flag.Arg(1)
    mbTrans217 := thrift.NewTMemoryBufferLen(len(arg216))
    defer mbTrans217.Close()
    _, err218 := mbTrans217.WriteString(arg216)
    if err218 != nil {
      Usage()
      return
    }
    factory219 := thrift.NewTJSONProtocolFactory()
    jsProt220 := factory219.GetProtocol(mbTrans217)
    argvalue0 := protocol.NewTimPBeanList()
    err221 := argvalue0.Read(context.Background(), jsProt220)
    if err221 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    fmt.Print(client.TimPresenceList(context.Background(), value0))
    fmt.Print("\n")
    break
  case "timMessageIq":
    if flag.NArg() - 1 != 2 {
      fmt.Fprintln(os.Stderr, "TimMessageIq requires 2 args")
      flag.Usage()
    }
    arg222 := flag.Arg(1)
    mbTrans223 := thrift.NewTMemoryBufferLen(len(arg222))
    defer mbTrans223.Close()
    _, err224 := mbTrans223.WriteString(arg222)
    if err224 != nil {
      Usage()
      return
    }
    factory225 := thrift.NewTJSONProtocolFactory()
    jsProt226 := factory225.GetProtocol(mbTrans223)
    argvalue0 := protocol.NewTimMessageIq()
    err227 := argvalue0.Read(context.Background(), jsProt226)
    if err227 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    argvalue1 := flag.Arg(2)
    value1 := argvalue1
    fmt.Print(client.TimMessageIq(context.Background(), value0, value1))
    fmt.Print("\n")
    break
  case "timMessageResult":
    if flag.NArg() - 1 != 1 {
      fmt.Fprintln(os.Stderr, "TimMessageResult_ requires 1 args")
      flag.Usage()
    }
    arg229 := flag.Arg(1)
    mbTrans230 := thrift.NewTMemoryBufferLen(len(arg229))
    defer mbTrans230.Close()
    _, err231 := mbTrans230.WriteString(arg229)
    if err231 != nil {
      Usage()
      return
    }
    factory232 := thrift.NewTJSONProtocolFactory()
    jsProt233 := factory232.GetProtocol(mbTrans230)
    argvalue0 := protocol.NewTimMBean()
    err234 := argvalue0.Read(context.Background(), jsProt233)
    if err234 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    fmt.Print(client.TimMessageResult_(context.Background(), value0))
    fmt.Print("\n")
    break
  case "timProperty":
    if flag.NArg() - 1 != 1 {
      fmt.Fprintln(os.Stderr, "TimProperty requires 1 args")
      flag.Usage()
    }
    arg235 := flag.Arg(1)
    mbTrans236 := thrift.NewTMemoryBufferLen(len(arg235))
    defer mbTrans236.Close()
    _, err237 := mbTrans236.WriteString(arg235)
    if err237 != nil {
      Usage()
      return
    }
    factory238 := thrift.NewTJSONProtocolFactory()
    jsProt239 := factory238.GetProtocol(mbTrans236)
    argvalue0 := protocol.NewTimPropertyBean()
    err240 := argvalue0.Read(context.Background(), jsProt239)
    if err240 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    fmt.Print(client.TimProperty(context.Background(), value0))
    fmt.Print("\n")
    break
  case "timRemoteUserAuth":
    if flag.NArg() - 1 != 3 {
      fmt.Fprintln(os.Stderr, "TimRemoteUserAuth requires 3 args")
      flag.Usage()
    }
    arg241 := flag.Arg(1)
    mbTrans242 := thrift.NewTMemoryBufferLen(len(arg241))
    defer mbTrans242.Close()
    _, err243 := mbTrans242.WriteString(arg241)
    if err243 != nil {
      Usage()
      return
    }
    factory244 := thrift.NewTJSONProtocolFactory()
    jsProt245 := factory244.GetProtocol(mbTrans242)
    argvalue0 := protocol.NewTid()
    err246 := argvalue0.Read(context.Background(), jsProt245)
    if err246 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    argvalue1 := flag.Arg(2)
    value1 := argvalue1
    arg248 := flag.Arg(3)
    mbTrans249 := thrift.NewTMemoryBufferLen(len(arg248))
    defer mbTrans249.Close()
    _, err250 := mbTrans249.WriteString(arg248)
    if err250 != nil {
      Usage()
      return
    }
    factory251 := thrift.NewTJSONProtocolFactory()
    jsProt252 := factory251.GetProtocol(mbTrans249)
    argvalue2 := protocol.NewTimAuth()
    err253 := argvalue2.Read(context.Background(), jsProt252)
    if err253 != nil {
      Usage()
      return
    }
    value2 := argvalue2
    fmt.Print(client.TimRemoteUserAuth(context.Background(), value0, value1, value2))
    fmt.Print("\n")
    break
  case "timRemoteUserGet":
    if flag.NArg() - 1 != 2 {
      fmt.Fprintln(os.Stderr, "TimRemoteUserGet requires 2 args")
      flag.Usage()
    }
    arg254 := flag.Arg(1)
    mbTrans255 := thrift.NewTMemoryBufferLen(len(arg254))
    defer mbTrans255.Close()
    _, err256 := mbTrans255.WriteString(arg254)
    if err256 != nil {
      Usage()
      return
    }
    factory257 := thrift.NewTJSONProtocolFactory()
    jsProt258 := factory257.GetProtocol(mbTrans255)
    argvalue0 := protocol.NewTid()
    err259 := argvalue0.Read(context.Background(), jsProt258)
    if err259 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    arg260 := flag.Arg(2)
    mbTrans261 := thrift.NewTMemoryBufferLen(len(arg260))
    defer mbTrans261.Close()
    _, err262 := mbTrans261.WriteString(arg260)
    if err262 != nil {
      Usage()
      return
    }
    factory263 := thrift.NewTJSONProtocolFactory()
    jsProt264 := factory263.GetProtocol(mbTrans261)
    argvalue1 := protocol.NewTimAuth()
    err265 := argvalue1.Read(context.Background(), jsProt264)
    if err265 != nil {
      Usage()
      return
    }
    value1 := argvalue1
    fmt.Print(client.TimRemoteUserGet(context.Background(), value0, value1))
    fmt.Print("\n")
    break
  case "timRemoteUserEdit":
    if flag.NArg() - 1 != 3 {
      fmt.Fprintln(os.Stderr, "TimRemoteUserEdit requires 3 args")
      flag.Usage()
    }
    arg266 := flag.Arg(1)
    mbTrans267 := thrift.NewTMemoryBufferLen(len(arg266))
    defer mbTrans267.Close()
    _, err268 := mbTrans267.WriteString(arg266)
    if err268 != nil {
      Usage()
      return
    }
    factory269 := thrift.NewTJSONProtocolFactory()
    jsProt270 := factory269.GetProtocol(mbTrans267)
    argvalue0 := protocol.NewTid()
    err271 := argvalue0.Read(context.Background(), jsProt270)
    if err271 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    arg272 := flag.Arg(2)
    mbTrans273 := thrift.NewTMemoryBufferLen(len(arg272))
    defer mbTrans273.Close()
    _, err274 := mbTrans273.WriteString(arg272)
    if err274 != nil {
      Usage()
      return
    }
    factory275 := thrift.NewTJSONProtocolFactory()
    jsProt276 := factory275.GetProtocol(mbTrans273)
    argvalue1 := protocol.NewTimUserBean()
    err277 := argvalue1.Read(context.Background(), jsProt276)
    if err277 != nil {
      Usage()
      return
    }
    value1 := argvalue1
    arg278 := flag.Arg(3)
    mbTrans279 := thrift.NewTMemoryBufferLen(len(arg278))
    defer mbTrans279.Close()
    _, err280 := mbTrans279.WriteString(arg278)
    if err280 != nil {
      Usage()
      return
    }
    factory281 := thrift.NewTJSONProtocolFactory()
    jsProt282 := factory281.GetProtocol(mbTrans279)
    argvalue2 := protocol.NewTimAuth()
    err283 := argvalue2.Read(context.Background(), jsProt282)
    if err283 != nil {
      Usage()
      return
    }
    value2 := argvalue2
    fmt.Print(client.TimRemoteUserEdit(context.Background(), value0, value1, value2))
    fmt.Print("\n")
    break
  case "timResponsePresence":
    if flag.NArg() - 1 != 2 {
      fmt.Fprintln(os.Stderr, "TimResponsePresence requires 2 args")
      flag.Usage()
    }
    arg284 := flag.Arg(1)
    mbTrans285 := thrift.NewTMemoryBufferLen(len(arg284))
    defer mbTrans285.Close()
    _, err286 := mbTrans285.WriteString(arg284)
    if err286 != nil {
      Usage()
      return
    }
    factory287 := thrift.NewTJSONProtocolFactory()
    jsProt288 := factory287.GetProtocol(mbTrans285)
    argvalue0 := protocol.NewTimPBean()
    err289 := argvalue0.Read(context.Background(), jsProt288)
    if err289 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    arg290 := flag.Arg(2)
    mbTrans291 := thrift.NewTMemoryBufferLen(len(arg290))
    defer mbTrans291.Close()
    _, err292 := mbTrans291.WriteString(arg290)
    if err292 != nil {
      Usage()
      return
    }
    factory293 := thrift.NewTJSONProtocolFactory()
    jsProt294 := factory293.GetProtocol(mbTrans291)
    argvalue1 := protocol.NewTimAuth()
    err295 := argvalue1.Read(context.Background(), jsProt294)
    if err295 != nil {
      Usage()
      return
    }
    value1 := argvalue1
    fmt.Print(client.TimResponsePresence(context.Background(), value0, value1))
    fmt.Print("\n")
    break
  case "timResponseMessage":
    if flag.NArg() - 1 != 2 {
      fmt.Fprintln(os.Stderr, "TimResponseMessage requires 2 args")
      flag.Usage()
    }
    arg296 := flag.Arg(1)
    mbTrans297 := thrift.NewTMemoryBufferLen(len(arg296))
    defer mbTrans297.Close()
    _, err298 := mbTrans297.WriteString(arg296)
    if err298 != nil {
      Usage()
      return
    }
    factory299 := thrift.NewTJSONProtocolFactory()
    jsProt300 := factory299.GetProtocol(mbTrans297)
    argvalue0 := protocol.NewTimMBean()
    err301 := argvalue0.Read(context.Background(), jsProt300)
    if err301 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    arg302 := flag.Arg(2)
    mbTrans303 := thrift.NewTMemoryBufferLen(len(arg302))
    defer mbTrans303.Close()
    _, err304 := mbTrans303.WriteString(arg302)
    if err304 != nil {
      Usage()
      return
    }
    factory305 := thrift.NewTJSONProtocolFactory()
    jsProt306 := factory305.GetProtocol(mbTrans303)
    argvalue1 := protocol.NewTimAuth()
    err307 := argvalue1.Read(context.Background(), jsProt306)
    if err307 != nil {
      Usage()
      return
    }
    value1 := argvalue1
    fmt.Print(client.TimResponseMessage(context.Background(), value0, value1))
    fmt.Print("\n")
    break
  case "timResponseMessageIq":
    if flag.NArg() - 1 != 3 {
      fmt.Fprintln(os.Stderr, "TimResponseMessageIq requires 3 args")
      flag.Usage()
    }
    arg308 := flag.Arg(1)
    mbTrans309 := thrift.NewTMemoryBufferLen(len(arg308))
    defer mbTrans309.Close()
    _, err310 := mbTrans309.WriteString(arg308)
    if err310 != nil {
      Usage()
      return
    }
    factory311 := thrift.NewTJSONProtocolFactory()
    jsProt312 := factory311.GetProtocol(mbTrans309)
    argvalue0 := protocol.NewTimMessageIq()
    err313 := argvalue0.Read(context.Background(), jsProt312)
    if err313 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    argvalue1 := flag.Arg(2)
    value1 := argvalue1
    arg315 := flag.Arg(3)
    mbTrans316 := thrift.NewTMemoryBufferLen(len(arg315))
    defer mbTrans316.Close()
    _, err317 := mbTrans316.WriteString(arg315)
    if err317 != nil {
      Usage()
      return
    }
    factory318 := thrift.NewTJSONProtocolFactory()
    jsProt319 := factory318.GetProtocol(mbTrans316)
    argvalue2 := protocol.NewTimAuth()
    err320 := argvalue2.Read(context.Background(), jsProt319)
    if err320 != nil {
      Usage()
      return
    }
    value2 := argvalue2
    fmt.Print(client.TimResponseMessageIq(context.Background(), value0, value1, value2))
    fmt.Print("\n")
    break
  case "timResponsePresenceList":
    if flag.NArg() - 1 != 2 {
      fmt.Fprintln(os.Stderr, "TimResponsePresenceList requires 2 args")
      flag.Usage()
    }
    arg321 := flag.Arg(1)
    mbTrans322 := thrift.NewTMemoryBufferLen(len(arg321))
    defer mbTrans322.Close()
    _, err323 := mbTrans322.WriteString(arg321)
    if err323 != nil {
      Usage()
      return
    }
    factory324 := thrift.NewTJSONProtocolFactory()
    jsProt325 := factory324.GetProtocol(mbTrans322)
    argvalue0 := protocol.NewTimPBeanList()
    err326 := argvalue0.Read(context.Background(), jsProt325)
    if err326 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    arg327 := flag.Arg(2)
    mbTrans328 := thrift.NewTMemoryBufferLen(len(arg327))
    defer mbTrans328.Close()
    _, err329 := mbTrans328.WriteString(arg327)
    if err329 != nil {
      Usage()
      return
    }
    factory330 := thrift.NewTJSONProtocolFactory()
    jsProt331 := factory330.GetProtocol(mbTrans328)
    argvalue1 := protocol.NewTimAuth()
    err332 := argvalue1.Read(context.Background(), jsProt331)
    if err332 != nil {
      Usage()
      return
    }
    value1 := argvalue1
    fmt.Print(client.TimResponsePresenceList(context.Background(), value0, value1))
    fmt.Print("\n")
    break
  case "timResponseMessageList":
    if flag.NArg() - 1 != 2 {
      fmt.Fprintln(os.Stderr, "TimResponseMessageList requires 2 args")
      flag.Usage()
    }
    arg333 := flag.Arg(1)
    mbTrans334 := thrift.NewTMemoryBufferLen(len(arg333))
    defer mbTrans334.Close()
    _, err335 := mbTrans334.WriteString(arg333)
    if err335 != nil {
      Usage()
      return
    }
    factory336 := thrift.NewTJSONProtocolFactory()
    jsProt337 := factory336.GetProtocol(mbTrans334)
    argvalue0 := protocol.NewTimMBeanList()
    err338 := argvalue0.Read(context.Background(), jsProt337)
    if err338 != nil {
      Usage()
      return
    }
    value0 := argvalue0
    arg339 := flag.Arg(2)
    mbTrans340 := thrift.NewTMemoryBufferLen(len(arg339))
    defer mbTrans340.Close()
    _, err341 := mbTrans340.WriteString(arg339)
    if err341 != nil {
      Usage()
      return
    }
    factory342 := thrift.NewTJSONProtocolFactory()
    jsProt343 := factory342.GetProtocol(mbTrans340)
    argvalue1 := protocol.NewTimAuth()
    err344 := argvalue1.Read(context.Background(), jsProt343)
    if err344 != nil {
      Usage()
      return
    }
    value1 := argvalue1
    fmt.Print(client.TimResponseMessageList(context.Background(), value0, value1))
    fmt.Print("\n")
    break
  case "":
    Usage()
    break
  default:
    fmt.Fprintln(os.Stderr, "Invalid function ", cmd)
  }
}
