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


public partial class TimRemoteUserBean : TBase
{
  private TimError _error;
  private TimUserBean _ub;
  private Dictionary<string, string> _extraMap;

  /// <summary>
  /// 错误码
  /// </summary>
  public TimError Error
  {
    get
    {
      return _error;
    }
    set
    {
      __isset.error = true;
      this._error = value;
    }
  }

  /// <summary>
  /// 远程用户信息
  /// </summary>
  public TimUserBean Ub
  {
    get
    {
      return _ub;
    }
    set
    {
      __isset.ub = true;
      this._ub = value;
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
    public bool error;
    public bool ub;
    public bool extraMap;
  }

  public TimRemoteUserBean()
  {
  }

  public TimRemoteUserBean DeepCopy()
  {
    var tmp168 = new TimRemoteUserBean();
    if((Error != null) && __isset.error)
    {
      tmp168.Error = (TimError)this.Error.DeepCopy();
    }
    tmp168.__isset.error = this.__isset.error;
    if((Ub != null) && __isset.ub)
    {
      tmp168.Ub = (TimUserBean)this.Ub.DeepCopy();
    }
    tmp168.__isset.ub = this.__isset.ub;
    if((ExtraMap != null) && __isset.extraMap)
    {
      tmp168.ExtraMap = this.ExtraMap.DeepCopy();
    }
    tmp168.__isset.extraMap = this.__isset.extraMap;
    return tmp168;
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
            if (field.Type == TType.Struct)
            {
              Error = new TimError();
              await Error.ReadAsync(iprot, cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 2:
            if (field.Type == TType.Struct)
            {
              Ub = new TimUserBean();
              await Ub.ReadAsync(iprot, cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 3:
            if (field.Type == TType.Map)
            {
              {
                var _map169 = await iprot.ReadMapBeginAsync(cancellationToken);
                ExtraMap = new Dictionary<string, string>(_map169.Count);
                for(int _i170 = 0; _i170 < _map169.Count; ++_i170)
                {
                  string _key171;
                  string _val172;
                  _key171 = await iprot.ReadStringAsync(cancellationToken);
                  _val172 = await iprot.ReadStringAsync(cancellationToken);
                  ExtraMap[_key171] = _val172;
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
      var tmp173 = new TStruct("TimRemoteUserBean");
      await oprot.WriteStructBeginAsync(tmp173, cancellationToken);
      var tmp174 = new TField();
      if((Error != null) && __isset.error)
      {
        tmp174.Name = "error";
        tmp174.Type = TType.Struct;
        tmp174.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp174, cancellationToken);
        await Error.WriteAsync(oprot, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((Ub != null) && __isset.ub)
      {
        tmp174.Name = "ub";
        tmp174.Type = TType.Struct;
        tmp174.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp174, cancellationToken);
        await Ub.WriteAsync(oprot, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((ExtraMap != null) && __isset.extraMap)
      {
        tmp174.Name = "extraMap";
        tmp174.Type = TType.Map;
        tmp174.ID = 3;
        await oprot.WriteFieldBeginAsync(tmp174, cancellationToken);
        await oprot.WriteMapBeginAsync(new TMap(TType.String, TType.String, ExtraMap.Count), cancellationToken);
        foreach (string _iter175 in ExtraMap.Keys)
        {
          await oprot.WriteStringAsync(_iter175, cancellationToken);
          await oprot.WriteStringAsync(ExtraMap[_iter175], cancellationToken);
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
    if (!(that is TimRemoteUserBean other)) return false;
    if (ReferenceEquals(this, other)) return true;
    return ((__isset.error == other.__isset.error) && ((!__isset.error) || (global::System.Object.Equals(Error, other.Error))))
      && ((__isset.ub == other.__isset.ub) && ((!__isset.ub) || (global::System.Object.Equals(Ub, other.Ub))))
      && ((__isset.extraMap == other.__isset.extraMap) && ((!__isset.extraMap) || (TCollections.Equals(ExtraMap, other.ExtraMap))));
  }

  public override int GetHashCode() {
    int hashcode = 157;
    unchecked {
      if((Error != null) && __isset.error)
      {
        hashcode = (hashcode * 397) + Error.GetHashCode();
      }
      if((Ub != null) && __isset.ub)
      {
        hashcode = (hashcode * 397) + Ub.GetHashCode();
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
    var tmp176 = new StringBuilder("TimRemoteUserBean(");
    int tmp177 = 0;
    if((Error != null) && __isset.error)
    {
      if(0 < tmp177++) { tmp176.Append(", "); }
      tmp176.Append("Error: ");
      Error.ToString(tmp176);
    }
    if((Ub != null) && __isset.ub)
    {
      if(0 < tmp177++) { tmp176.Append(", "); }
      tmp176.Append("Ub: ");
      Ub.ToString(tmp176);
    }
    if((ExtraMap != null) && __isset.extraMap)
    {
      if(0 < tmp177++) { tmp176.Append(", "); }
      tmp176.Append("ExtraMap: ");
      ExtraMap.ToString(tmp176);
    }
    tmp176.Append(')');
    return tmp176.ToString();
  }
}

