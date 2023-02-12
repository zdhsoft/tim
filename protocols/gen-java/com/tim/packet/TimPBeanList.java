/**
 * Autogenerated by Thrift Compiler (0.17.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
package com.tim.packet;

@SuppressWarnings({"cast", "rawtypes", "serial", "unchecked", "unused"})
@javax.annotation.Generated(value = "Autogenerated by Thrift Compiler (0.17.0)", date = "2023-02-11")
public class TimPBeanList implements org.apache.thrift.TBase<TimPBeanList, TimPBeanList._Fields>, java.io.Serializable, Cloneable, Comparable<TimPBeanList> {
  private static final org.apache.thrift.protocol.TStruct STRUCT_DESC = new org.apache.thrift.protocol.TStruct("TimPBeanList");

  private static final org.apache.thrift.protocol.TField THREAD_ID_FIELD_DESC = new org.apache.thrift.protocol.TField("threadId", org.apache.thrift.protocol.TType.STRING, (short)1);
  private static final org.apache.thrift.protocol.TField TIM_PBEAN_LIST_FIELD_DESC = new org.apache.thrift.protocol.TField("timPBeanList", org.apache.thrift.protocol.TType.LIST, (short)2);
  private static final org.apache.thrift.protocol.TField REQ_TYPE_FIELD_DESC = new org.apache.thrift.protocol.TField("reqType", org.apache.thrift.protocol.TType.STRING, (short)3);
  private static final org.apache.thrift.protocol.TField EXTRA_MAP_FIELD_DESC = new org.apache.thrift.protocol.TField("extraMap", org.apache.thrift.protocol.TType.MAP, (short)4);

  private static final org.apache.thrift.scheme.SchemeFactory STANDARD_SCHEME_FACTORY = new TimPBeanListStandardSchemeFactory();
  private static final org.apache.thrift.scheme.SchemeFactory TUPLE_SCHEME_FACTORY = new TimPBeanListTupleSchemeFactory();

  public @org.apache.thrift.annotation.Nullable java.lang.String threadId; // required
  /**
   * 状态信息列表
   */
  public @org.apache.thrift.annotation.Nullable java.util.List<TimPBean> timPBeanList; // optional
  /**
   * 类型
   */
  public @org.apache.thrift.annotation.Nullable java.lang.String reqType; // optional
  public @org.apache.thrift.annotation.Nullable java.util.Map<java.lang.String,java.lang.String> extraMap; // optional

  /** The set of fields this struct contains, along with convenience methods for finding and manipulating them. */
  public enum _Fields implements org.apache.thrift.TFieldIdEnum {
    THREAD_ID((short)1, "threadId"),
    /**
     * 状态信息列表
     */
    TIM_PBEAN_LIST((short)2, "timPBeanList"),
    /**
     * 类型
     */
    REQ_TYPE((short)3, "reqType"),
    EXTRA_MAP((short)4, "extraMap");

    private static final java.util.Map<java.lang.String, _Fields> byName = new java.util.HashMap<java.lang.String, _Fields>();

    static {
      for (_Fields field : java.util.EnumSet.allOf(_Fields.class)) {
        byName.put(field.getFieldName(), field);
      }
    }

    /**
     * Find the _Fields constant that matches fieldId, or null if its not found.
     */
    @org.apache.thrift.annotation.Nullable
    public static _Fields findByThriftId(int fieldId) {
      switch(fieldId) {
        case 1: // THREAD_ID
          return THREAD_ID;
        case 2: // TIM_PBEAN_LIST
          return TIM_PBEAN_LIST;
        case 3: // REQ_TYPE
          return REQ_TYPE;
        case 4: // EXTRA_MAP
          return EXTRA_MAP;
        default:
          return null;
      }
    }

    /**
     * Find the _Fields constant that matches fieldId, throwing an exception
     * if it is not found.
     */
    public static _Fields findByThriftIdOrThrow(int fieldId) {
      _Fields fields = findByThriftId(fieldId);
      if (fields == null) throw new java.lang.IllegalArgumentException("Field " + fieldId + " doesn't exist!");
      return fields;
    }

    /**
     * Find the _Fields constant that matches name, or null if its not found.
     */
    @org.apache.thrift.annotation.Nullable
    public static _Fields findByName(java.lang.String name) {
      return byName.get(name);
    }

    private final short _thriftId;
    private final java.lang.String _fieldName;

    _Fields(short thriftId, java.lang.String fieldName) {
      _thriftId = thriftId;
      _fieldName = fieldName;
    }

    @Override
    public short getThriftFieldId() {
      return _thriftId;
    }

    @Override
    public java.lang.String getFieldName() {
      return _fieldName;
    }
  }

  // isset id assignments
  private static final _Fields optionals[] = {_Fields.TIM_PBEAN_LIST,_Fields.REQ_TYPE,_Fields.EXTRA_MAP};
  public static final java.util.Map<_Fields, org.apache.thrift.meta_data.FieldMetaData> metaDataMap;
  static {
    java.util.Map<_Fields, org.apache.thrift.meta_data.FieldMetaData> tmpMap = new java.util.EnumMap<_Fields, org.apache.thrift.meta_data.FieldMetaData>(_Fields.class);
    tmpMap.put(_Fields.THREAD_ID, new org.apache.thrift.meta_data.FieldMetaData("threadId", org.apache.thrift.TFieldRequirementType.REQUIRED, 
        new org.apache.thrift.meta_data.FieldValueMetaData(org.apache.thrift.protocol.TType.STRING)));
    tmpMap.put(_Fields.TIM_PBEAN_LIST, new org.apache.thrift.meta_data.FieldMetaData("timPBeanList", org.apache.thrift.TFieldRequirementType.OPTIONAL, 
        new org.apache.thrift.meta_data.ListMetaData(org.apache.thrift.protocol.TType.LIST, 
            new org.apache.thrift.meta_data.StructMetaData(org.apache.thrift.protocol.TType.STRUCT, TimPBean.class))));
    tmpMap.put(_Fields.REQ_TYPE, new org.apache.thrift.meta_data.FieldMetaData("reqType", org.apache.thrift.TFieldRequirementType.OPTIONAL, 
        new org.apache.thrift.meta_data.FieldValueMetaData(org.apache.thrift.protocol.TType.STRING)));
    tmpMap.put(_Fields.EXTRA_MAP, new org.apache.thrift.meta_data.FieldMetaData("extraMap", org.apache.thrift.TFieldRequirementType.OPTIONAL, 
        new org.apache.thrift.meta_data.MapMetaData(org.apache.thrift.protocol.TType.MAP, 
            new org.apache.thrift.meta_data.FieldValueMetaData(org.apache.thrift.protocol.TType.STRING), 
            new org.apache.thrift.meta_data.FieldValueMetaData(org.apache.thrift.protocol.TType.STRING))));
    metaDataMap = java.util.Collections.unmodifiableMap(tmpMap);
    org.apache.thrift.meta_data.FieldMetaData.addStructMetaDataMap(TimPBeanList.class, metaDataMap);
  }

  public TimPBeanList() {
  }

  public TimPBeanList(
    java.lang.String threadId)
  {
    this();
    this.threadId = threadId;
  }

  /**
   * Performs a deep copy on <i>other</i>.
   */
  public TimPBeanList(TimPBeanList other) {
    if (other.isSetThreadId()) {
      this.threadId = other.threadId;
    }
    if (other.isSetTimPBeanList()) {
      java.util.List<TimPBean> __this__timPBeanList = new java.util.ArrayList<TimPBean>(other.timPBeanList.size());
      for (TimPBean other_element : other.timPBeanList) {
        __this__timPBeanList.add(new TimPBean(other_element));
      }
      this.timPBeanList = __this__timPBeanList;
    }
    if (other.isSetReqType()) {
      this.reqType = other.reqType;
    }
    if (other.isSetExtraMap()) {
      java.util.Map<java.lang.String,java.lang.String> __this__extraMap = new java.util.HashMap<java.lang.String,java.lang.String>(other.extraMap);
      this.extraMap = __this__extraMap;
    }
  }

  @Override
  public TimPBeanList deepCopy() {
    return new TimPBeanList(this);
  }

  @Override
  public void clear() {
    this.threadId = null;
    this.timPBeanList = null;
    this.reqType = null;
    this.extraMap = null;
  }

  @org.apache.thrift.annotation.Nullable
  public java.lang.String getThreadId() {
    return this.threadId;
  }

  public TimPBeanList setThreadId(@org.apache.thrift.annotation.Nullable java.lang.String threadId) {
    this.threadId = threadId;
    return this;
  }

  public void unsetThreadId() {
    this.threadId = null;
  }

  /** Returns true if field threadId is set (has been assigned a value) and false otherwise */
  public boolean isSetThreadId() {
    return this.threadId != null;
  }

  public void setThreadIdIsSet(boolean value) {
    if (!value) {
      this.threadId = null;
    }
  }

  public int getTimPBeanListSize() {
    return (this.timPBeanList == null) ? 0 : this.timPBeanList.size();
  }

  @org.apache.thrift.annotation.Nullable
  public java.util.Iterator<TimPBean> getTimPBeanListIterator() {
    return (this.timPBeanList == null) ? null : this.timPBeanList.iterator();
  }

  public void addToTimPBeanList(TimPBean elem) {
    if (this.timPBeanList == null) {
      this.timPBeanList = new java.util.ArrayList<TimPBean>();
    }
    this.timPBeanList.add(elem);
  }

  /**
   * 状态信息列表
   */
  @org.apache.thrift.annotation.Nullable
  public java.util.List<TimPBean> getTimPBeanList() {
    return this.timPBeanList;
  }

  /**
   * 状态信息列表
   */
  public TimPBeanList setTimPBeanList(@org.apache.thrift.annotation.Nullable java.util.List<TimPBean> timPBeanList) {
    this.timPBeanList = timPBeanList;
    return this;
  }

  public void unsetTimPBeanList() {
    this.timPBeanList = null;
  }

  /** Returns true if field timPBeanList is set (has been assigned a value) and false otherwise */
  public boolean isSetTimPBeanList() {
    return this.timPBeanList != null;
  }

  public void setTimPBeanListIsSet(boolean value) {
    if (!value) {
      this.timPBeanList = null;
    }
  }

  /**
   * 类型
   */
  @org.apache.thrift.annotation.Nullable
  public java.lang.String getReqType() {
    return this.reqType;
  }

  /**
   * 类型
   */
  public TimPBeanList setReqType(@org.apache.thrift.annotation.Nullable java.lang.String reqType) {
    this.reqType = reqType;
    return this;
  }

  public void unsetReqType() {
    this.reqType = null;
  }

  /** Returns true if field reqType is set (has been assigned a value) and false otherwise */
  public boolean isSetReqType() {
    return this.reqType != null;
  }

  public void setReqTypeIsSet(boolean value) {
    if (!value) {
      this.reqType = null;
    }
  }

  public int getExtraMapSize() {
    return (this.extraMap == null) ? 0 : this.extraMap.size();
  }

  public void putToExtraMap(java.lang.String key, java.lang.String val) {
    if (this.extraMap == null) {
      this.extraMap = new java.util.HashMap<java.lang.String,java.lang.String>();
    }
    this.extraMap.put(key, val);
  }

  @org.apache.thrift.annotation.Nullable
  public java.util.Map<java.lang.String,java.lang.String> getExtraMap() {
    return this.extraMap;
  }

  public TimPBeanList setExtraMap(@org.apache.thrift.annotation.Nullable java.util.Map<java.lang.String,java.lang.String> extraMap) {
    this.extraMap = extraMap;
    return this;
  }

  public void unsetExtraMap() {
    this.extraMap = null;
  }

  /** Returns true if field extraMap is set (has been assigned a value) and false otherwise */
  public boolean isSetExtraMap() {
    return this.extraMap != null;
  }

  public void setExtraMapIsSet(boolean value) {
    if (!value) {
      this.extraMap = null;
    }
  }

  @Override
  public void setFieldValue(_Fields field, @org.apache.thrift.annotation.Nullable java.lang.Object value) {
    switch (field) {
    case THREAD_ID:
      if (value == null) {
        unsetThreadId();
      } else {
        setThreadId((java.lang.String)value);
      }
      break;

    case TIM_PBEAN_LIST:
      if (value == null) {
        unsetTimPBeanList();
      } else {
        setTimPBeanList((java.util.List<TimPBean>)value);
      }
      break;

    case REQ_TYPE:
      if (value == null) {
        unsetReqType();
      } else {
        setReqType((java.lang.String)value);
      }
      break;

    case EXTRA_MAP:
      if (value == null) {
        unsetExtraMap();
      } else {
        setExtraMap((java.util.Map<java.lang.String,java.lang.String>)value);
      }
      break;

    }
  }

  @org.apache.thrift.annotation.Nullable
  @Override
  public java.lang.Object getFieldValue(_Fields field) {
    switch (field) {
    case THREAD_ID:
      return getThreadId();

    case TIM_PBEAN_LIST:
      return getTimPBeanList();

    case REQ_TYPE:
      return getReqType();

    case EXTRA_MAP:
      return getExtraMap();

    }
    throw new java.lang.IllegalStateException();
  }

  /** Returns true if field corresponding to fieldID is set (has been assigned a value) and false otherwise */
  @Override
  public boolean isSet(_Fields field) {
    if (field == null) {
      throw new java.lang.IllegalArgumentException();
    }

    switch (field) {
    case THREAD_ID:
      return isSetThreadId();
    case TIM_PBEAN_LIST:
      return isSetTimPBeanList();
    case REQ_TYPE:
      return isSetReqType();
    case EXTRA_MAP:
      return isSetExtraMap();
    }
    throw new java.lang.IllegalStateException();
  }

  @Override
  public boolean equals(java.lang.Object that) {
    if (that instanceof TimPBeanList)
      return this.equals((TimPBeanList)that);
    return false;
  }

  public boolean equals(TimPBeanList that) {
    if (that == null)
      return false;
    if (this == that)
      return true;

    boolean this_present_threadId = true && this.isSetThreadId();
    boolean that_present_threadId = true && that.isSetThreadId();
    if (this_present_threadId || that_present_threadId) {
      if (!(this_present_threadId && that_present_threadId))
        return false;
      if (!this.threadId.equals(that.threadId))
        return false;
    }

    boolean this_present_timPBeanList = true && this.isSetTimPBeanList();
    boolean that_present_timPBeanList = true && that.isSetTimPBeanList();
    if (this_present_timPBeanList || that_present_timPBeanList) {
      if (!(this_present_timPBeanList && that_present_timPBeanList))
        return false;
      if (!this.timPBeanList.equals(that.timPBeanList))
        return false;
    }

    boolean this_present_reqType = true && this.isSetReqType();
    boolean that_present_reqType = true && that.isSetReqType();
    if (this_present_reqType || that_present_reqType) {
      if (!(this_present_reqType && that_present_reqType))
        return false;
      if (!this.reqType.equals(that.reqType))
        return false;
    }

    boolean this_present_extraMap = true && this.isSetExtraMap();
    boolean that_present_extraMap = true && that.isSetExtraMap();
    if (this_present_extraMap || that_present_extraMap) {
      if (!(this_present_extraMap && that_present_extraMap))
        return false;
      if (!this.extraMap.equals(that.extraMap))
        return false;
    }

    return true;
  }

  @Override
  public int hashCode() {
    int hashCode = 1;

    hashCode = hashCode * 8191 + ((isSetThreadId()) ? 131071 : 524287);
    if (isSetThreadId())
      hashCode = hashCode * 8191 + threadId.hashCode();

    hashCode = hashCode * 8191 + ((isSetTimPBeanList()) ? 131071 : 524287);
    if (isSetTimPBeanList())
      hashCode = hashCode * 8191 + timPBeanList.hashCode();

    hashCode = hashCode * 8191 + ((isSetReqType()) ? 131071 : 524287);
    if (isSetReqType())
      hashCode = hashCode * 8191 + reqType.hashCode();

    hashCode = hashCode * 8191 + ((isSetExtraMap()) ? 131071 : 524287);
    if (isSetExtraMap())
      hashCode = hashCode * 8191 + extraMap.hashCode();

    return hashCode;
  }

  @Override
  public int compareTo(TimPBeanList other) {
    if (!getClass().equals(other.getClass())) {
      return getClass().getName().compareTo(other.getClass().getName());
    }

    int lastComparison = 0;

    lastComparison = java.lang.Boolean.compare(isSetThreadId(), other.isSetThreadId());
    if (lastComparison != 0) {
      return lastComparison;
    }
    if (isSetThreadId()) {
      lastComparison = org.apache.thrift.TBaseHelper.compareTo(this.threadId, other.threadId);
      if (lastComparison != 0) {
        return lastComparison;
      }
    }
    lastComparison = java.lang.Boolean.compare(isSetTimPBeanList(), other.isSetTimPBeanList());
    if (lastComparison != 0) {
      return lastComparison;
    }
    if (isSetTimPBeanList()) {
      lastComparison = org.apache.thrift.TBaseHelper.compareTo(this.timPBeanList, other.timPBeanList);
      if (lastComparison != 0) {
        return lastComparison;
      }
    }
    lastComparison = java.lang.Boolean.compare(isSetReqType(), other.isSetReqType());
    if (lastComparison != 0) {
      return lastComparison;
    }
    if (isSetReqType()) {
      lastComparison = org.apache.thrift.TBaseHelper.compareTo(this.reqType, other.reqType);
      if (lastComparison != 0) {
        return lastComparison;
      }
    }
    lastComparison = java.lang.Boolean.compare(isSetExtraMap(), other.isSetExtraMap());
    if (lastComparison != 0) {
      return lastComparison;
    }
    if (isSetExtraMap()) {
      lastComparison = org.apache.thrift.TBaseHelper.compareTo(this.extraMap, other.extraMap);
      if (lastComparison != 0) {
        return lastComparison;
      }
    }
    return 0;
  }

  @org.apache.thrift.annotation.Nullable
  @Override
  public _Fields fieldForId(int fieldId) {
    return _Fields.findByThriftId(fieldId);
  }

  @Override
  public void read(org.apache.thrift.protocol.TProtocol iprot) throws org.apache.thrift.TException {
    scheme(iprot).read(iprot, this);
  }

  @Override
  public void write(org.apache.thrift.protocol.TProtocol oprot) throws org.apache.thrift.TException {
    scheme(oprot).write(oprot, this);
  }

  @Override
  public java.lang.String toString() {
    java.lang.StringBuilder sb = new java.lang.StringBuilder("TimPBeanList(");
    boolean first = true;

    sb.append("threadId:");
    if (this.threadId == null) {
      sb.append("null");
    } else {
      sb.append(this.threadId);
    }
    first = false;
    if (isSetTimPBeanList()) {
      if (!first) sb.append(", ");
      sb.append("timPBeanList:");
      if (this.timPBeanList == null) {
        sb.append("null");
      } else {
        sb.append(this.timPBeanList);
      }
      first = false;
    }
    if (isSetReqType()) {
      if (!first) sb.append(", ");
      sb.append("reqType:");
      if (this.reqType == null) {
        sb.append("null");
      } else {
        sb.append(this.reqType);
      }
      first = false;
    }
    if (isSetExtraMap()) {
      if (!first) sb.append(", ");
      sb.append("extraMap:");
      if (this.extraMap == null) {
        sb.append("null");
      } else {
        sb.append(this.extraMap);
      }
      first = false;
    }
    sb.append(")");
    return sb.toString();
  }

  public void validate() throws org.apache.thrift.TException {
    // check for required fields
    if (threadId == null) {
      throw new org.apache.thrift.protocol.TProtocolException("Required field 'threadId' was not present! Struct: " + toString());
    }
    // check for sub-struct validity
  }

  private void writeObject(java.io.ObjectOutputStream out) throws java.io.IOException {
    try {
      write(new org.apache.thrift.protocol.TCompactProtocol(new org.apache.thrift.transport.TIOStreamTransport(out)));
    } catch (org.apache.thrift.TException te) {
      throw new java.io.IOException(te);
    }
  }

  private void readObject(java.io.ObjectInputStream in) throws java.io.IOException, java.lang.ClassNotFoundException {
    try {
      read(new org.apache.thrift.protocol.TCompactProtocol(new org.apache.thrift.transport.TIOStreamTransport(in)));
    } catch (org.apache.thrift.TException te) {
      throw new java.io.IOException(te);
    }
  }

  private static class TimPBeanListStandardSchemeFactory implements org.apache.thrift.scheme.SchemeFactory {
    @Override
    public TimPBeanListStandardScheme getScheme() {
      return new TimPBeanListStandardScheme();
    }
  }

  private static class TimPBeanListStandardScheme extends org.apache.thrift.scheme.StandardScheme<TimPBeanList> {

    @Override
    public void read(org.apache.thrift.protocol.TProtocol iprot, TimPBeanList struct) throws org.apache.thrift.TException {
      org.apache.thrift.protocol.TField schemeField;
      iprot.readStructBegin();
      while (true)
      {
        schemeField = iprot.readFieldBegin();
        if (schemeField.type == org.apache.thrift.protocol.TType.STOP) { 
          break;
        }
        switch (schemeField.id) {
          case 1: // THREAD_ID
            if (schemeField.type == org.apache.thrift.protocol.TType.STRING) {
              struct.threadId = iprot.readString();
              struct.setThreadIdIsSet(true);
            } else { 
              org.apache.thrift.protocol.TProtocolUtil.skip(iprot, schemeField.type);
            }
            break;
          case 2: // TIM_PBEAN_LIST
            if (schemeField.type == org.apache.thrift.protocol.TType.LIST) {
              {
                org.apache.thrift.protocol.TList _list316 = iprot.readListBegin();
                struct.timPBeanList = new java.util.ArrayList<TimPBean>(_list316.size);
                @org.apache.thrift.annotation.Nullable TimPBean _elem317;
                for (int _i318 = 0; _i318 < _list316.size; ++_i318)
                {
                  _elem317 = new TimPBean();
                  _elem317.read(iprot);
                  struct.timPBeanList.add(_elem317);
                }
                iprot.readListEnd();
              }
              struct.setTimPBeanListIsSet(true);
            } else { 
              org.apache.thrift.protocol.TProtocolUtil.skip(iprot, schemeField.type);
            }
            break;
          case 3: // REQ_TYPE
            if (schemeField.type == org.apache.thrift.protocol.TType.STRING) {
              struct.reqType = iprot.readString();
              struct.setReqTypeIsSet(true);
            } else { 
              org.apache.thrift.protocol.TProtocolUtil.skip(iprot, schemeField.type);
            }
            break;
          case 4: // EXTRA_MAP
            if (schemeField.type == org.apache.thrift.protocol.TType.MAP) {
              {
                org.apache.thrift.protocol.TMap _map319 = iprot.readMapBegin();
                struct.extraMap = new java.util.HashMap<java.lang.String,java.lang.String>(2*_map319.size);
                @org.apache.thrift.annotation.Nullable java.lang.String _key320;
                @org.apache.thrift.annotation.Nullable java.lang.String _val321;
                for (int _i322 = 0; _i322 < _map319.size; ++_i322)
                {
                  _key320 = iprot.readString();
                  _val321 = iprot.readString();
                  struct.extraMap.put(_key320, _val321);
                }
                iprot.readMapEnd();
              }
              struct.setExtraMapIsSet(true);
            } else { 
              org.apache.thrift.protocol.TProtocolUtil.skip(iprot, schemeField.type);
            }
            break;
          default:
            org.apache.thrift.protocol.TProtocolUtil.skip(iprot, schemeField.type);
        }
        iprot.readFieldEnd();
      }
      iprot.readStructEnd();

      // check for required fields of primitive type, which can't be checked in the validate method
      struct.validate();
    }

    @Override
    public void write(org.apache.thrift.protocol.TProtocol oprot, TimPBeanList struct) throws org.apache.thrift.TException {
      struct.validate();

      oprot.writeStructBegin(STRUCT_DESC);
      if (struct.threadId != null) {
        oprot.writeFieldBegin(THREAD_ID_FIELD_DESC);
        oprot.writeString(struct.threadId);
        oprot.writeFieldEnd();
      }
      if (struct.timPBeanList != null) {
        if (struct.isSetTimPBeanList()) {
          oprot.writeFieldBegin(TIM_PBEAN_LIST_FIELD_DESC);
          {
            oprot.writeListBegin(new org.apache.thrift.protocol.TList(org.apache.thrift.protocol.TType.STRUCT, struct.timPBeanList.size()));
            for (TimPBean _iter323 : struct.timPBeanList)
            {
              _iter323.write(oprot);
            }
            oprot.writeListEnd();
          }
          oprot.writeFieldEnd();
        }
      }
      if (struct.reqType != null) {
        if (struct.isSetReqType()) {
          oprot.writeFieldBegin(REQ_TYPE_FIELD_DESC);
          oprot.writeString(struct.reqType);
          oprot.writeFieldEnd();
        }
      }
      if (struct.extraMap != null) {
        if (struct.isSetExtraMap()) {
          oprot.writeFieldBegin(EXTRA_MAP_FIELD_DESC);
          {
            oprot.writeMapBegin(new org.apache.thrift.protocol.TMap(org.apache.thrift.protocol.TType.STRING, org.apache.thrift.protocol.TType.STRING, struct.extraMap.size()));
            for (java.util.Map.Entry<java.lang.String, java.lang.String> _iter324 : struct.extraMap.entrySet())
            {
              oprot.writeString(_iter324.getKey());
              oprot.writeString(_iter324.getValue());
            }
            oprot.writeMapEnd();
          }
          oprot.writeFieldEnd();
        }
      }
      oprot.writeFieldStop();
      oprot.writeStructEnd();
    }

  }

  private static class TimPBeanListTupleSchemeFactory implements org.apache.thrift.scheme.SchemeFactory {
    @Override
    public TimPBeanListTupleScheme getScheme() {
      return new TimPBeanListTupleScheme();
    }
  }

  private static class TimPBeanListTupleScheme extends org.apache.thrift.scheme.TupleScheme<TimPBeanList> {

    @Override
    public void write(org.apache.thrift.protocol.TProtocol prot, TimPBeanList struct) throws org.apache.thrift.TException {
      org.apache.thrift.protocol.TTupleProtocol oprot = (org.apache.thrift.protocol.TTupleProtocol) prot;
      oprot.writeString(struct.threadId);
      java.util.BitSet optionals = new java.util.BitSet();
      if (struct.isSetTimPBeanList()) {
        optionals.set(0);
      }
      if (struct.isSetReqType()) {
        optionals.set(1);
      }
      if (struct.isSetExtraMap()) {
        optionals.set(2);
      }
      oprot.writeBitSet(optionals, 3);
      if (struct.isSetTimPBeanList()) {
        {
          oprot.writeI32(struct.timPBeanList.size());
          for (TimPBean _iter325 : struct.timPBeanList)
          {
            _iter325.write(oprot);
          }
        }
      }
      if (struct.isSetReqType()) {
        oprot.writeString(struct.reqType);
      }
      if (struct.isSetExtraMap()) {
        {
          oprot.writeI32(struct.extraMap.size());
          for (java.util.Map.Entry<java.lang.String, java.lang.String> _iter326 : struct.extraMap.entrySet())
          {
            oprot.writeString(_iter326.getKey());
            oprot.writeString(_iter326.getValue());
          }
        }
      }
    }

    @Override
    public void read(org.apache.thrift.protocol.TProtocol prot, TimPBeanList struct) throws org.apache.thrift.TException {
      org.apache.thrift.protocol.TTupleProtocol iprot = (org.apache.thrift.protocol.TTupleProtocol) prot;
      struct.threadId = iprot.readString();
      struct.setThreadIdIsSet(true);
      java.util.BitSet incoming = iprot.readBitSet(3);
      if (incoming.get(0)) {
        {
          org.apache.thrift.protocol.TList _list327 = iprot.readListBegin(org.apache.thrift.protocol.TType.STRUCT);
          struct.timPBeanList = new java.util.ArrayList<TimPBean>(_list327.size);
          @org.apache.thrift.annotation.Nullable TimPBean _elem328;
          for (int _i329 = 0; _i329 < _list327.size; ++_i329)
          {
            _elem328 = new TimPBean();
            _elem328.read(iprot);
            struct.timPBeanList.add(_elem328);
          }
        }
        struct.setTimPBeanListIsSet(true);
      }
      if (incoming.get(1)) {
        struct.reqType = iprot.readString();
        struct.setReqTypeIsSet(true);
      }
      if (incoming.get(2)) {
        {
          org.apache.thrift.protocol.TMap _map330 = iprot.readMapBegin(org.apache.thrift.protocol.TType.STRING, org.apache.thrift.protocol.TType.STRING); 
          struct.extraMap = new java.util.HashMap<java.lang.String,java.lang.String>(2*_map330.size);
          @org.apache.thrift.annotation.Nullable java.lang.String _key331;
          @org.apache.thrift.annotation.Nullable java.lang.String _val332;
          for (int _i333 = 0; _i333 < _map330.size; ++_i333)
          {
            _key331 = iprot.readString();
            _val332 = iprot.readString();
            struct.extraMap.put(_key331, _val332);
          }
        }
        struct.setExtraMapIsSet(true);
      }
    }
  }

  private static <S extends org.apache.thrift.scheme.IScheme> S scheme(org.apache.thrift.protocol.TProtocol proto) {
    return (org.apache.thrift.scheme.StandardScheme.class.equals(proto.getScheme()) ? STANDARD_SCHEME_FACTORY : TUPLE_SCHEME_FACTORY).getScheme();
  }
}

