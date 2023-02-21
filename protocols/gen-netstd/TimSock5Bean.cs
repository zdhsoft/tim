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


public partial class TimSock5Bean : TBase
{
  private Dictionary<string, string> _extraMap;

  public Tid FromTid { get; set; }

  public Tid ToTid { get; set; }

  /// <summary>
  /// ip地址
  /// </summary>
  public string Addr { get; set; }

  /// <summary>
  /// 端口
  /// </summary>
  public int Port { get; set; }

  /// <summary>
  /// 传输类型  1:tcp 2:udp
  /// </summary>
  public short Transport { get; set; }

  /// <summary>
  /// 发布id 通过发布id 可以连接两个发布id相同的用户
  /// </summary>
  public string PubId { get; set; }

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
    public bool extraMap;
  }

  public TimSock5Bean()
  {
  }

  public TimSock5Bean(Tid fromTid, Tid toTid, string addr, int port, short transport, string pubId) : this()
  {
    this.FromTid = fromTid;
    this.ToTid = toTid;
    this.Addr = addr;
    this.Port = port;
    this.Transport = transport;
    this.PubId = pubId;
  }

  public TimSock5Bean DeepCopy()
  {
    var tmp202 = new TimSock5Bean();
    if((FromTid != null))
    {
      tmp202.FromTid = (Tid)this.FromTid.DeepCopy();
    }
    if((ToTid != null))
    {
      tmp202.ToTid = (Tid)this.ToTid.DeepCopy();
    }
    if((Addr != null))
    {
      tmp202.Addr = this.Addr;
    }
    tmp202.Port = this.Port;
    tmp202.Transport = this.Transport;
    if((PubId != null))
    {
      tmp202.PubId = this.PubId;
    }
    if((ExtraMap != null) && __isset.extraMap)
    {
      tmp202.ExtraMap = this.ExtraMap.DeepCopy();
    }
    tmp202.__isset.extraMap = this.__isset.extraMap;
    return tmp202;
  }

  public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      bool isset_fromTid = false;
      bool isset_toTid = false;
      bool isset_addr = false;
      bool isset_port = false;
      bool isset_transport = false;
      bool isset_pubId = false;
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
            if (field.Type == TType.Struct)
            {
              FromTid = new Tid();
              await FromTid.ReadAsync(iprot, cancellationToken);
              isset_fromTid = true;
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 2:
            if (field.Type == TType.Struct)
            {
              ToTid = new Tid();
              await ToTid.ReadAsync(iprot, cancellationToken);
              isset_toTid = true;
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 3:
            if (field.Type == TType.String)
            {
              Addr = await iprot.ReadStringAsync(cancellationToken);
              isset_addr = true;
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 4:
            if (field.Type == TType.I32)
            {
              Port = await iprot.ReadI32Async(cancellationToken);
              isset_port = true;
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 5:
            if (field.Type == TType.I16)
            {
              Transport = await iprot.ReadI16Async(cancellationToken);
              isset_transport = true;
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 6:
            if (field.Type == TType.String)
            {
              PubId = await iprot.ReadStringAsync(cancellationToken);
              isset_pubId = true;
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 7:
            if (field.Type == TType.Map)
            {
              {
                var _map203 = await iprot.ReadMapBeginAsync(cancellationToken);
                ExtraMap = new Dictionary<string, string>(_map203.Count);
                for(int _i204 = 0; _i204 < _map203.Count; ++_i204)
                {
                  string _key205;
                  string _val206;
                  _key205 = await iprot.ReadStringAsync(cancellationToken);
                  _val206 = await iprot.ReadStringAsync(cancellationToken);
                  ExtraMap[_key205] = _val206;
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
      if (!isset_fromTid)
      {
        throw new TProtocolException(TProtocolException.INVALID_DATA);
      }
      if (!isset_toTid)
      {
        throw new TProtocolException(TProtocolException.INVALID_DATA);
      }
      if (!isset_addr)
      {
        throw new TProtocolException(TProtocolException.INVALID_DATA);
      }
      if (!isset_port)
      {
        throw new TProtocolException(TProtocolException.INVALID_DATA);
      }
      if (!isset_transport)
      {
        throw new TProtocolException(TProtocolException.INVALID_DATA);
      }
      if (!isset_pubId)
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
      var tmp207 = new TStruct("TimSock5Bean");
      await oprot.WriteStructBeginAsync(tmp207, cancellationToken);
      var tmp208 = new TField();
      if((FromTid != null))
      {
        tmp208.Name = "fromTid";
        tmp208.Type = TType.Struct;
        tmp208.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp208, cancellationToken);
        await FromTid.WriteAsync(oprot, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((ToTid != null))
      {
        tmp208.Name = "toTid";
        tmp208.Type = TType.Struct;
        tmp208.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp208, cancellationToken);
        await ToTid.WriteAsync(oprot, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((Addr != null))
      {
        tmp208.Name = "addr";
        tmp208.Type = TType.String;
        tmp208.ID = 3;
        await oprot.WriteFieldBeginAsync(tmp208, cancellationToken);
        await oprot.WriteStringAsync(Addr, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      tmp208.Name = "port";
      tmp208.Type = TType.I32;
      tmp208.ID = 4;
      await oprot.WriteFieldBeginAsync(tmp208, cancellationToken);
      await oprot.WriteI32Async(Port, cancellationToken);
      await oprot.WriteFieldEndAsync(cancellationToken);
      tmp208.Name = "transport";
      tmp208.Type = TType.I16;
      tmp208.ID = 5;
      await oprot.WriteFieldBeginAsync(tmp208, cancellationToken);
      await oprot.WriteI16Async(Transport, cancellationToken);
      await oprot.WriteFieldEndAsync(cancellationToken);
      if((PubId != null))
      {
        tmp208.Name = "pubId";
        tmp208.Type = TType.String;
        tmp208.ID = 6;
        await oprot.WriteFieldBeginAsync(tmp208, cancellationToken);
        await oprot.WriteStringAsync(PubId, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((ExtraMap != null) && __isset.extraMap)
      {
        tmp208.Name = "extraMap";
        tmp208.Type = TType.Map;
        tmp208.ID = 7;
        await oprot.WriteFieldBeginAsync(tmp208, cancellationToken);
        await oprot.WriteMapBeginAsync(new TMap(TType.String, TType.String, ExtraMap.Count), cancellationToken);
        foreach (string _iter209 in ExtraMap.Keys)
        {
          await oprot.WriteStringAsync(_iter209, cancellationToken);
          await oprot.WriteStringAsync(ExtraMap[_iter209], cancellationToken);
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
    if (!(that is TimSock5Bean other)) return false;
    if (ReferenceEquals(this, other)) return true;
    return global::System.Object.Equals(FromTid, other.FromTid)
      && global::System.Object.Equals(ToTid, other.ToTid)
      && global::System.Object.Equals(Addr, other.Addr)
      && global::System.Object.Equals(Port, other.Port)
      && global::System.Object.Equals(Transport, other.Transport)
      && global::System.Object.Equals(PubId, other.PubId)
      && ((__isset.extraMap == other.__isset.extraMap) && ((!__isset.extraMap) || (TCollections.Equals(ExtraMap, other.ExtraMap))));
  }

  public override int GetHashCode() {
    int hashcode = 157;
    unchecked {
      if((FromTid != null))
      {
        hashcode = (hashcode * 397) + FromTid.GetHashCode();
      }
      if((ToTid != null))
      {
        hashcode = (hashcode * 397) + ToTid.GetHashCode();
      }
      if((Addr != null))
      {
        hashcode = (hashcode * 397) + Addr.GetHashCode();
      }
      hashcode = (hashcode * 397) + Port.GetHashCode();
      hashcode = (hashcode * 397) + Transport.GetHashCode();
      if((PubId != null))
      {
        hashcode = (hashcode * 397) + PubId.GetHashCode();
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
    var tmp210 = new StringBuilder("TimSock5Bean(");
    if((FromTid != null))
    {
      tmp210.Append(", FromTid: ");
      FromTid.ToString(tmp210);
    }
    if((ToTid != null))
    {
      tmp210.Append(", ToTid: ");
      ToTid.ToString(tmp210);
    }
    if((Addr != null))
    {
      tmp210.Append(", Addr: ");
      Addr.ToString(tmp210);
    }
    tmp210.Append(", Port: ");
    Port.ToString(tmp210);
    tmp210.Append(", Transport: ");
    Transport.ToString(tmp210);
    if((PubId != null))
    {
      tmp210.Append(", PubId: ");
      PubId.ToString(tmp210);
    }
    if((ExtraMap != null) && __isset.extraMap)
    {
      tmp210.Append(", ExtraMap: ");
      ExtraMap.ToString(tmp210);
    }
    tmp210.Append(')');
    return tmp210.ToString();
  }
}
