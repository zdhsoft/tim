/**
 * Autogenerated by Thrift Compiler (0.17.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
module tim_constants;

import thrift.base;
import thrift.codegen.base;
import thrift.util.hashset;

import tim_types;

/**
  内部版本号
*/
immutable(int) protocolversion;
/**
  外部版本号
*/
immutable(string) protocolversionName;
/**
  状态码：成功
*/
immutable(string) TIM_SC_SUCCESS;
/**
  状态码：失败
*/
immutable(string) TIM_SC_FAILED;

shared static this() {
  protocolversion = 4;

  protocolversionName = "1.1.0";

  TIM_SC_SUCCESS = "200";

  TIM_SC_FAILED = "400";
}
