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


public partial class TimNode : TBase
{
  private string _key;
  private string _value;

  /// <summary>
  /// 键
  /// </summary>
  public string Key
  {
    get
    {
      return _key;
    }
    set
    {
      __isset.key = true;
      this._key = value;
    }
  }

  /// <summary>
  /// 值
  /// </summary>
  public string Value
  {
    get
    {
      return _value;
    }
    set
    {
      __isset.@value = true;
      this._value = value;
    }
  }


  public Isset __isset;
  public struct Isset
  {
    public bool key;
    public bool @value;
  }

  public TimNode()
  {
  }

  public TimNode DeepCopy()
  {
    var tmp5 = new TimNode();
    if((Key != null) && __isset.key)
    {
      tmp5.Key = this.Key;
    }
    tmp5.__isset.key = this.__isset.key;
    if((Value != null) && __isset.@value)
    {
      tmp5.Value = this.Value;
    }
    tmp5.__isset.@value = this.__isset.@value;
    return tmp5;
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
              Key = await iprot.ReadStringAsync(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 2:
            if (field.Type == TType.String)
            {
              Value = await iprot.ReadStringAsync(cancellationToken);
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
      var tmp6 = new TStruct("TimNode");
      await oprot.WriteStructBeginAsync(tmp6, cancellationToken);
      var tmp7 = new TField();
      if((Key != null) && __isset.key)
      {
        tmp7.Name = "key";
        tmp7.Type = TType.String;
        tmp7.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp7, cancellationToken);
        await oprot.WriteStringAsync(Key, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((Value != null) && __isset.@value)
      {
        tmp7.Name = "value";
        tmp7.Type = TType.String;
        tmp7.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp7, cancellationToken);
        await oprot.WriteStringAsync(Value, cancellationToken);
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
    if (!(that is TimNode other)) return false;
    if (ReferenceEquals(this, other)) return true;
    return ((__isset.key == other.__isset.key) && ((!__isset.key) || (global::System.Object.Equals(Key, other.Key))))
      && ((__isset.@value == other.__isset.@value) && ((!__isset.@value) || (global::System.Object.Equals(Value, other.Value))));
  }

  public override int GetHashCode() {
    int hashcode = 157;
    unchecked {
      if((Key != null) && __isset.key)
      {
        hashcode = (hashcode * 397) + Key.GetHashCode();
      }
      if((Value != null) && __isset.@value)
      {
        hashcode = (hashcode * 397) + Value.GetHashCode();
      }
    }
    return hashcode;
  }

  public override string ToString()
  {
    var tmp8 = new StringBuilder("TimNode(");
    int tmp9 = 0;
    if((Key != null) && __isset.key)
    {
      if(0 < tmp9++) { tmp8.Append(", "); }
      tmp8.Append("Key: ");
      Key.ToString(tmp8);
    }
    if((Value != null) && __isset.@value)
    {
      if(0 < tmp9++) { tmp8.Append(", "); }
      tmp8.Append("Value: ");
      Value.ToString(tmp8);
    }
    tmp8.Append(')');
    return tmp8.ToString();
  }
}

