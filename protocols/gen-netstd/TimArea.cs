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


public partial class TimArea : TBase
{
  private string _country;
  private string _province;
  private string _city;
  private List<TimNode> _extraList;
  private Dictionary<string, string> _extraMap;

  /// <summary>
  /// 国家
  /// </summary>
  public string Country
  {
    get
    {
      return _country;
    }
    set
    {
      __isset.country = true;
      this._country = value;
    }
  }

  /// <summary>
  /// 省
  /// </summary>
  public string Province
  {
    get
    {
      return _province;
    }
    set
    {
      __isset.province = true;
      this._province = value;
    }
  }

  /// <summary>
  /// 市
  /// </summary>
  public string City
  {
    get
    {
      return _city;
    }
    set
    {
      __isset.city = true;
      this._city = value;
    }
  }

  /// <summary>
  /// 附加信息：如区，镇，乡等
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
    public bool country;
    public bool province;
    public bool city;
    public bool extraList;
    public bool extraMap;
  }

  public TimArea()
  {
  }

  public TimArea DeepCopy()
  {
    var tmp48 = new TimArea();
    if((Country != null) && __isset.country)
    {
      tmp48.Country = this.Country;
    }
    tmp48.__isset.country = this.__isset.country;
    if((Province != null) && __isset.province)
    {
      tmp48.Province = this.Province;
    }
    tmp48.__isset.province = this.__isset.province;
    if((City != null) && __isset.city)
    {
      tmp48.City = this.City;
    }
    tmp48.__isset.city = this.__isset.city;
    if((ExtraList != null) && __isset.extraList)
    {
      tmp48.ExtraList = this.ExtraList.DeepCopy();
    }
    tmp48.__isset.extraList = this.__isset.extraList;
    if((ExtraMap != null) && __isset.extraMap)
    {
      tmp48.ExtraMap = this.ExtraMap.DeepCopy();
    }
    tmp48.__isset.extraMap = this.__isset.extraMap;
    return tmp48;
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
              Country = await iprot.ReadStringAsync(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 2:
            if (field.Type == TType.String)
            {
              Province = await iprot.ReadStringAsync(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 3:
            if (field.Type == TType.String)
            {
              City = await iprot.ReadStringAsync(cancellationToken);
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
                var _list49 = await iprot.ReadListBeginAsync(cancellationToken);
                ExtraList = new List<TimNode>(_list49.Count);
                for(int _i50 = 0; _i50 < _list49.Count; ++_i50)
                {
                  TimNode _elem51;
                  _elem51 = new TimNode();
                  await _elem51.ReadAsync(iprot, cancellationToken);
                  ExtraList.Add(_elem51);
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
            if (field.Type == TType.Map)
            {
              {
                var _map52 = await iprot.ReadMapBeginAsync(cancellationToken);
                ExtraMap = new Dictionary<string, string>(_map52.Count);
                for(int _i53 = 0; _i53 < _map52.Count; ++_i53)
                {
                  string _key54;
                  string _val55;
                  _key54 = await iprot.ReadStringAsync(cancellationToken);
                  _val55 = await iprot.ReadStringAsync(cancellationToken);
                  ExtraMap[_key54] = _val55;
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
      var tmp56 = new TStruct("TimArea");
      await oprot.WriteStructBeginAsync(tmp56, cancellationToken);
      var tmp57 = new TField();
      if((Country != null) && __isset.country)
      {
        tmp57.Name = "country";
        tmp57.Type = TType.String;
        tmp57.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp57, cancellationToken);
        await oprot.WriteStringAsync(Country, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((Province != null) && __isset.province)
      {
        tmp57.Name = "province";
        tmp57.Type = TType.String;
        tmp57.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp57, cancellationToken);
        await oprot.WriteStringAsync(Province, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((City != null) && __isset.city)
      {
        tmp57.Name = "city";
        tmp57.Type = TType.String;
        tmp57.ID = 3;
        await oprot.WriteFieldBeginAsync(tmp57, cancellationToken);
        await oprot.WriteStringAsync(City, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((ExtraList != null) && __isset.extraList)
      {
        tmp57.Name = "extraList";
        tmp57.Type = TType.List;
        tmp57.ID = 4;
        await oprot.WriteFieldBeginAsync(tmp57, cancellationToken);
        await oprot.WriteListBeginAsync(new TList(TType.Struct, ExtraList.Count), cancellationToken);
        foreach (TimNode _iter58 in ExtraList)
        {
          await _iter58.WriteAsync(oprot, cancellationToken);
        }
        await oprot.WriteListEndAsync(cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if((ExtraMap != null) && __isset.extraMap)
      {
        tmp57.Name = "extraMap";
        tmp57.Type = TType.Map;
        tmp57.ID = 5;
        await oprot.WriteFieldBeginAsync(tmp57, cancellationToken);
        await oprot.WriteMapBeginAsync(new TMap(TType.String, TType.String, ExtraMap.Count), cancellationToken);
        foreach (string _iter59 in ExtraMap.Keys)
        {
          await oprot.WriteStringAsync(_iter59, cancellationToken);
          await oprot.WriteStringAsync(ExtraMap[_iter59], cancellationToken);
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
    if (!(that is TimArea other)) return false;
    if (ReferenceEquals(this, other)) return true;
    return ((__isset.country == other.__isset.country) && ((!__isset.country) || (global::System.Object.Equals(Country, other.Country))))
      && ((__isset.province == other.__isset.province) && ((!__isset.province) || (global::System.Object.Equals(Province, other.Province))))
      && ((__isset.city == other.__isset.city) && ((!__isset.city) || (global::System.Object.Equals(City, other.City))))
      && ((__isset.extraList == other.__isset.extraList) && ((!__isset.extraList) || (TCollections.Equals(ExtraList, other.ExtraList))))
      && ((__isset.extraMap == other.__isset.extraMap) && ((!__isset.extraMap) || (TCollections.Equals(ExtraMap, other.ExtraMap))));
  }

  public override int GetHashCode() {
    int hashcode = 157;
    unchecked {
      if((Country != null) && __isset.country)
      {
        hashcode = (hashcode * 397) + Country.GetHashCode();
      }
      if((Province != null) && __isset.province)
      {
        hashcode = (hashcode * 397) + Province.GetHashCode();
      }
      if((City != null) && __isset.city)
      {
        hashcode = (hashcode * 397) + City.GetHashCode();
      }
      if((ExtraList != null) && __isset.extraList)
      {
        hashcode = (hashcode * 397) + TCollections.GetHashCode(ExtraList);
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
    var tmp60 = new StringBuilder("TimArea(");
    int tmp61 = 0;
    if((Country != null) && __isset.country)
    {
      if(0 < tmp61++) { tmp60.Append(", "); }
      tmp60.Append("Country: ");
      Country.ToString(tmp60);
    }
    if((Province != null) && __isset.province)
    {
      if(0 < tmp61++) { tmp60.Append(", "); }
      tmp60.Append("Province: ");
      Province.ToString(tmp60);
    }
    if((City != null) && __isset.city)
    {
      if(0 < tmp61++) { tmp60.Append(", "); }
      tmp60.Append("City: ");
      City.ToString(tmp60);
    }
    if((ExtraList != null) && __isset.extraList)
    {
      if(0 < tmp61++) { tmp60.Append(", "); }
      tmp60.Append("ExtraList: ");
      ExtraList.ToString(tmp60);
    }
    if((ExtraMap != null) && __isset.extraMap)
    {
      if(0 < tmp61++) { tmp60.Append(", "); }
      tmp60.Append("ExtraMap: ");
      ExtraMap.ToString(tmp60);
    }
    tmp60.Append(')');
    return tmp60.ToString();
  }
}
