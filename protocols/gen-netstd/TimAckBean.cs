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


public partial class TimAckBean : TBase
{
  private string _id;
  private string _ackType;
  private string _ackStatus;
  private List<TimNode> _extraList;
  private TimError _err;
  private Dictionary<string, string> _extraMap;

  /// <summary>
  /// id，返回所要回执协议的线程id
  /// </summary>
  public string Id
  {
    get
    {
      return _id;
    }
    set
    {
      __isset.id = true;
      this._id = value;
    }
  }

  /// <summary>
  /// 类型，自定义 如：ping，message等
  /// </summary>
  public string AckType
  {
    get
    {
      return _ackType;
    }
    set
    {
      __isset.ackType = true;
      this._ackType = value;
    }
  }

  /// <summary>
  /// 状态，如成功，失败等
  /// </summary>
  public string AckStatus
  {
    get
    {
      return _ackStatus;
    }
    set
    {
      __isset.ackStatus = true;
      this._ackStatus = value;
    }
  }

  /// <summary>
  /// 附加信息
  /// </summary>
  public List<TimNode> ExtraList
  {
    get
    {
      return _extraList;
    }
    set
    {
      __isset.extraList = true;
      this._extraList = value;
    }
  }

  /// <summary>
  /// 错误信息
  /// </summary>
  public TimError Err
  {
    get
    {
      return _err;
    }
    set
    {
      __isset.err = true;
      this._err = value;
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
    public bool id;
    public bool ackType;
    public bool ackStatus;
    public bool extraList;
    public bool err;
    public bool extraMap;
  }

  public TimAckBean()
  {
  }

  public TimAckBean DeepCopy()
  {
    var tmp10 = new TimAckBean();
    if((Id != null) && __isset.id)
    {
      tmp10.Id = this.Id;
    }
    tmp10.__isset.id = this.__isset.id;
    if((AckType != null) && __isset.ackType)
    {
      tmp10.AckType = this.AckType;
    }
    tmp10.__isset.ackType = this.__isset.ackType;
    if((AckStatus != null) && __isset.ackStatus)
    {
      tmp10.AckStatus = this.AckStatus;
    }
    tmp10.__isset.ackStatus = this.__isset.ackStatus;
    if((ExtraList != null) && __isset.extraList)
    {
      tmp10.ExtraList = this.ExtraList.DeepCopy();
    }
    tmp10.__isset.extraList = this.__isset.extraList;
    if((Err != null) && __isset.err)
    {
      tmp10.Err = (TimError)this.Err.DeepCopy();
    }
    tmp10.__isset.err = this.__isset.err;
    if((ExtraMap != null) && __isset.extraMap)
    {
      tmp10.ExtraMap = this.ExtraMap.DeepCopy();
    }
    tmp10.__isset.extraMap = this.__isset.extraMap;
    return tmp10;
  }

  public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
  {
    iprot.IncrementRecursionDepth();
    try
    {
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
              Id = await iprot.ReadStringAsync(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 2:
            if (field.Type == TType.String)
            {
              AckType = await iprot.ReadStringAsync(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 3:
            if (field.Type == TType.String)
            {
              AckStatus = await iprot.ReadStringAsync(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 4:
            if (field.Type == TType.List)
            {
              {
                var _list11 = await iprot.ReadListBeginAsync(cancellationToken);
                ExtraList = new List<TimNode>(_list11.Count);
                for(int _i12 = 0; _i12 < _list11.Count; ++_i12)
                {
                  TimNode _elem13;
                  _elem13 = new TimNode();
                  await _elem13.ReadAsync(iprot, cancellationToken);
                  ExtraList.Add(_elem13);
                }
                await iprot.ReadListEndAsync(cancellationToken);
              }
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 5:
            if (field.Type == TType.Struct)
            {
              Err = new TimError();
              await Err.ReadAsync(iprot, cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 6:
            if (field.Type == TType.Map)
            {
              {
                var _map14 = await iprot.ReadMapBeginAsync(cancellationToken);
                ExtraMap = new Dictionary<string, string>(_map14.Count);
                for(int _i15 = 0; _i15 < _map14.Count; ++_i15)
                {
                  string _key16;
                  string _val17;
                  _key16 = await iprot.ReadStringAsync(cancellationToken);
                  _val17 = await iprot.ReadStringAsync(cancellationToken);
                  ExtraMap[_key16] = _val17;
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
      var tmp18 = new TStruct("TimAckBean");
      await oprot.WriteStructBeginAsync(tmp18, cancellationToken);
      var tmp19 = new TField();
      if((Id != null) && __isset.id)
      {
        tmp19.Name = "id";
        tmp19.Type = TType.String;
        tmp19.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp19, cancellationToken);
        await oprot.WriteStringAsync(Id, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((AckType != null) && __isset.ackType)
      {
        tmp19.Name = "ackType";
        tmp19.Type = TType.String;
        tmp19.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp19, cancellationToken);
        await oprot.WriteStringAsync(AckType, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((AckStatus != null) && __isset.ackStatus)
      {
        tmp19.Name = "ackStatus";
        tmp19.Type = TType.String;
        tmp19.ID = 3;
        await oprot.WriteFieldBeginAsync(tmp19, cancellationToken);
        await oprot.WriteStringAsync(AckStatus, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((ExtraList != null) && __isset.extraList)
      {
        tmp19.Name = "extraList";
        tmp19.Type = TType.List;
        tmp19.ID = 4;
        await oprot.WriteFieldBeginAsync(tmp19, cancellationToken);
        await oprot.WriteListBeginAsync(new TList(TType.Struct, ExtraList.Count), cancellationToken);
        foreach (TimNode _iter20 in ExtraList)
        {
          await _iter20.WriteAsync(oprot, cancellationToken);
        }
        await oprot.WriteListEndAsync(cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((Err != null) && __isset.err)
      {
        tmp19.Name = "err";
        tmp19.Type = TType.Struct;
        tmp19.ID = 5;
        await oprot.WriteFieldBeginAsync(tmp19, cancellationToken);
        await Err.WriteAsync(oprot, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((ExtraMap != null) && __isset.extraMap)
      {
        tmp19.Name = "extraMap";
        tmp19.Type = TType.Map;
        tmp19.ID = 6;
        await oprot.WriteFieldBeginAsync(tmp19, cancellationToken);
        await oprot.WriteMapBeginAsync(new TMap(TType.String, TType.String, ExtraMap.Count), cancellationToken);
        foreach (string _iter21 in ExtraMap.Keys)
        {
          await oprot.WriteStringAsync(_iter21, cancellationToken);
          await oprot.WriteStringAsync(ExtraMap[_iter21], cancellationToken);
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
    if (!(that is TimAckBean other)) return false;
    if (ReferenceEquals(this, other)) return true;
    return ((__isset.id == other.__isset.id) && ((!__isset.id) || (global::System.Object.Equals(Id, other.Id))))
      && ((__isset.ackType == other.__isset.ackType) && ((!__isset.ackType) || (global::System.Object.Equals(AckType, other.AckType))))
      && ((__isset.ackStatus == other.__isset.ackStatus) && ((!__isset.ackStatus) || (global::System.Object.Equals(AckStatus, other.AckStatus))))
      && ((__isset.extraList == other.__isset.extraList) && ((!__isset.extraList) || (TCollections.Equals(ExtraList, other.ExtraList))))
      && ((__isset.err == other.__isset.err) && ((!__isset.err) || (global::System.Object.Equals(Err, other.Err))))
      && ((__isset.extraMap == other.__isset.extraMap) && ((!__isset.extraMap) || (TCollections.Equals(ExtraMap, other.ExtraMap))));
  }

  public override int GetHashCode() {
    int hashcode = 157;
    unchecked {
      if((Id != null) && __isset.id)
      {
        hashcode = (hashcode * 397) + Id.GetHashCode();
      }
      if((AckType != null) && __isset.ackType)
      {
        hashcode = (hashcode * 397) + AckType.GetHashCode();
      }
      if((AckStatus != null) && __isset.ackStatus)
      {
        hashcode = (hashcode * 397) + AckStatus.GetHashCode();
      }
      if((ExtraList != null) && __isset.extraList)
      {
        hashcode = (hashcode * 397) + TCollections.GetHashCode(ExtraList);
      }
      if((Err != null) && __isset.err)
      {
        hashcode = (hashcode * 397) + Err.GetHashCode();
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
    var tmp22 = new StringBuilder("TimAckBean(");
    int tmp23 = 0;
    if((Id != null) && __isset.id)
    {
      if(0 < tmp23++) { tmp22.Append(", "); }
      tmp22.Append("Id: ");
      Id.ToString(tmp22);
    }
    if((AckType != null) && __isset.ackType)
    {
      if(0 < tmp23++) { tmp22.Append(", "); }
      tmp22.Append("AckType: ");
      AckType.ToString(tmp22);
    }
    if((AckStatus != null) && __isset.ackStatus)
    {
      if(0 < tmp23++) { tmp22.Append(", "); }
      tmp22.Append("AckStatus: ");
      AckStatus.ToString(tmp22);
    }
    if((ExtraList != null) && __isset.extraList)
    {
      if(0 < tmp23++) { tmp22.Append(", "); }
      tmp22.Append("ExtraList: ");
      ExtraList.ToString(tmp22);
    }
    if((Err != null) && __isset.err)
    {
      if(0 < tmp23++) { tmp22.Append(", "); }
      tmp22.Append("Err: ");
      Err.ToString(tmp22);
    }
    if((ExtraMap != null) && __isset.extraMap)
    {
      if(0 < tmp23++) { tmp22.Append(", "); }
      tmp22.Append("ExtraMap: ");
      ExtraMap.ToString(tmp22);
    }
    tmp22.Append(')');
    return tmp22.ToString();
  }
}

