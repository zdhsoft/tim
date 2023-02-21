/**
 * <auto-generated>
 * Autogenerated by Thrift Compiler (0.17.0)
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 * </auto-generated>
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;


#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE0017  // object init can be simplified
#pragma warning disable IDE0028  // collection init can be simplified
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable CA1822   // empty DeepCopy() methods still non-static
#pragma warning disable IDE0083  // pattern matching "that is not SomeType" requires net5.0 but we still support earlier versions


public partial class TimPBeanList : TBase
{
  private List<TimPBean> _timPBeanList;
  private string _reqType;
  private Dictionary<string, string> _extraMap;

  public string ThreadId { get; set; }

  /// <summary>
  /// 状态信息列表
  /// </summary>
  public List<TimPBean> TimPBeanList_
  {
    get
    {
      return _timPBeanList;
    }
    set
    {
      __isset.timPBeanList = true;
      this._timPBeanList = value;
    }
  }

  /// <summary>
  /// 类型
  /// </summary>
  public string ReqType
  {
    get
    {
      return _reqType;
    }
    set
    {
      __isset.reqType = true;
      this._reqType = value;
    }
  }

  public Dictionary<string, string> ExtraMap
  {
    get
    {
      return _extraMap;
    }
    set
    {
      __isset.extraMap = true;
      this._extraMap = value;
    }
  }


  public Isset __isset;
  public struct Isset
  {
    public bool timPBeanList;
    public bool reqType;
    public bool extraMap;
  }

  public TimPBeanList()
  {
  }

  public TimPBeanList(string threadId) : this()
  {
    this.ThreadId = threadId;
  }

  public TimPBeanList DeepCopy()
  {
    var tmp273 = new TimPBeanList();
    if((ThreadId != null))
    {
      tmp273.ThreadId = this.ThreadId;
    }
    if((TimPBeanList_ != null) && __isset.timPBeanList)
    {
      tmp273.TimPBeanList_ = this.TimPBeanList_.DeepCopy();
    }
    tmp273.__isset.timPBeanList = this.__isset.timPBeanList;
    if((ReqType != null) && __isset.reqType)
    {
      tmp273.ReqType = this.ReqType;
    }
    tmp273.__isset.reqType = this.__isset.reqType;
    if((ExtraMap != null) && __isset.extraMap)
    {
      tmp273.ExtraMap = this.ExtraMap.DeepCopy();
    }
    tmp273.__isset.extraMap = this.__isset.extraMap;
    return tmp273;
  }

  public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_threadId = false;
      TField field;
      await iprot.ReadStructBeginAsync(cancellationToken);
      while (true)
      {
        field = await iprot.ReadFieldBeginAsync(cancellationToken);
        if (field.Type == TType.Stop)
        {
          break;
        }

        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String)
            {
              ThreadId = await iprot.ReadStringAsync(cancellationToken);
              isset_threadId = true;
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 2:
            if (field.Type == TType.List)
            {
              {
                var _list274 = await iprot.ReadListBeginAsync(cancellationToken);
                TimPBeanList_ = new List<TimPBean>(_list274.Count);
                for(int _i275 = 0; _i275 < _list274.Count; ++_i275)
                {
                  TimPBean _elem276;
                  _elem276 = new TimPBean();
                  await _elem276.ReadAsync(iprot, cancellationToken);
                  TimPBeanList_.Add(_elem276);
                }
                await iprot.ReadListEndAsync(cancellationToken);
              }
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 3:
            if (field.Type == TType.String)
            {
              ReqType = await iprot.ReadStringAsync(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 4:
            if (field.Type == TType.Map)
            {
              {
                var _map277 = await iprot.ReadMapBeginAsync(cancellationToken);
                ExtraMap = new Dictionary<string, string>(_map277.Count);
                for(int _i278 = 0; _i278 < _map277.Count; ++_i278)
                {
                  string _key279;
                  string _val280;
                  _key279 = await iprot.ReadStringAsync(cancellationToken);
                  _val280 = await iprot.ReadStringAsync(cancellationToken);
                  ExtraMap[_key279] = _val280;
                }
                await iprot.ReadMapEndAsync(cancellationToken);
              }
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          default: 
            await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            break;
        }

        await iprot.ReadFieldEndAsync(cancellationToken);
      }

      await iprot.ReadStructEndAsync(cancellationToken);
      if (!isset_threadId)
      {
        throw new TProtocolException(TProtocolException.INVALID_DATA);
      }
    }
    finally
    {
      iprot.DecrementRecursionDepth();
    }
  }

  public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
  {
    oprot.IncrementRecursionDepth();
    try
    {
      var tmp281 = new TStruct("TimPBeanList");
      await oprot.WriteStructBeginAsync(tmp281, cancellationToken);
      var tmp282 = new TField();
      if((ThreadId != null))
      {
        tmp282.Name = "threadId";
        tmp282.Type = TType.String;
        tmp282.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp282, cancellationToken);
        await oprot.WriteStringAsync(ThreadId, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((TimPBeanList_ != null) && __isset.timPBeanList)
      {
        tmp282.Name = "timPBeanList";
        tmp282.Type = TType.List;
        tmp282.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp282, cancellationToken);
        await oprot.WriteListBeginAsync(new TList(TType.Struct, TimPBeanList_.Count), cancellationToken);
        foreach (TimPBean _iter283 in TimPBeanList_)
        {
          await _iter283.WriteAsync(oprot, cancellationToken);
        }
        await oprot.WriteListEndAsync(cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((ReqType != null) && __isset.reqType)
      {
        tmp282.Name = "reqType";
        tmp282.Type = TType.String;
        tmp282.ID = 3;
        await oprot.WriteFieldBeginAsync(tmp282, cancellationToken);
        await oprot.WriteStringAsync(ReqType, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((ExtraMap != null) && __isset.extraMap)
      {
        tmp282.Name = "extraMap";
        tmp282.Type = TType.Map;
        tmp282.ID = 4;
        await oprot.WriteFieldBeginAsync(tmp282, cancellationToken);
        await oprot.WriteMapBeginAsync(new TMap(TType.String, TType.String, ExtraMap.Count), cancellationToken);
        foreach (string _iter284 in ExtraMap.Keys)
        {
          await oprot.WriteStringAsync(_iter284, cancellationToken);
          await oprot.WriteStringAsync(ExtraMap[_iter284], cancellationToken);
        }
        await oprot.WriteMapEndAsync(cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      await oprot.WriteFieldStopAsync(cancellationToken);
      await oprot.WriteStructEndAsync(cancellationToken);
    }
    finally
    {
      oprot.DecrementRecursionDepth();
    }
  }

  public override bool Equals(object that)
  {
    if (!(that is TimPBeanList other)) return false;
    if (ReferenceEquals(this, other)) return true;
    return global::System.Object.Equals(ThreadId, other.ThreadId)
      && ((__isset.timPBeanList == other.__isset.timPBeanList) && ((!__isset.timPBeanList) || (TCollections.Equals(TimPBeanList_, other.TimPBeanList_))))
      && ((__isset.reqType == other.__isset.reqType) && ((!__isset.reqType) || (global::System.Object.Equals(ReqType, other.ReqType))))
      && ((__isset.extraMap == other.__isset.extraMap) && ((!__isset.extraMap) || (TCollections.Equals(ExtraMap, other.ExtraMap))));
  }

  public override int GetHashCode() {
    int hashcode = 157;
    unchecked {
      if((ThreadId != null))
      {
        hashcode = (hashcode * 397) + ThreadId.GetHashCode();
      }
      if((TimPBeanList_ != null) && __isset.timPBeanList)
      {
        hashcode = (hashcode * 397) + TCollections.GetHashCode(TimPBeanList_);
      }
      if((ReqType != null) && __isset.reqType)
      {
        hashcode = (hashcode * 397) + ReqType.GetHashCode();
      }
      if((ExtraMap != null) && __isset.extraMap)
      {
        hashcode = (hashcode * 397) + TCollections.GetHashCode(ExtraMap);
      }
    }
    return hashcode;
  }

  public override string ToString()
  {
    var tmp285 = new StringBuilder("TimPBeanList(");
    if((ThreadId != null))
    {
      tmp285.Append(", ThreadId: ");
      ThreadId.ToString(tmp285);
    }
    if((TimPBeanList_ != null) && __isset.timPBeanList)
    {
      tmp285.Append(", TimPBeanList_: ");
      TimPBeanList_.ToString(tmp285);
    }
    if((ReqType != null) && __isset.reqType)
    {
      tmp285.Append(", ReqType: ");
      ReqType.ToString(tmp285);
    }
    if((ExtraMap != null) && __isset.extraMap)
    {
      tmp285.Append(", ExtraMap: ");
      ExtraMap.ToString(tmp285);
    }
    tmp285.Append(')');
    return tmp285.ToString();
  }
}
