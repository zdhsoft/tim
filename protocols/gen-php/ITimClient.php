<?php
/**
 * Autogenerated by Thrift Compiler (0.17.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
use Thrift\Base\TBase;
use Thrift\Type\TType;
use Thrift\Type\TMessageType;
use Thrift\Exception\TException;
use Thrift\Exception\TProtocolException;
use Thrift\Protocol\TProtocol;
use Thrift\Protocol\TBinaryProtocolAccelerated;
use Thrift\Exception\TApplicationException;

class ITimClient implements \ITimIf
{
    protected $input_ = null;
    protected $output_ = null;

    protected $seqid_ = 0;

    public function __construct($input, $output = null)
    {
        $this->input_ = $input;
        $this->output_ = $output ? $output : $input;
    }


    public function timStream(\TimParam $param)
    {
        $this->send_timStream($param);
    }

    public function send_timStream(\TimParam $param)
    {
        $args = new \ITim_timStream_args();
        $args->param = $param;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timStream',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timStream', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timStarttls()
    {
        $this->send_timStarttls();
    }

    public function send_timStarttls()
    {
        $args = new \ITim_timStarttls_args();
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timStarttls',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timStarttls', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timLogin(\Tid $tid, $pwd)
    {
        $this->send_timLogin($tid, $pwd);
    }

    public function send_timLogin(\Tid $tid, $pwd)
    {
        $args = new \ITim_timLogin_args();
        $args->tid = $tid;
        $args->pwd = $pwd;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timLogin',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timLogin', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timAck(\TimAckBean $ab)
    {
        $this->send_timAck($ab);
    }

    public function send_timAck(\TimAckBean $ab)
    {
        $args = new \ITim_timAck_args();
        $args->ab = $ab;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timAck',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timAck', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timPresence(\TimPBean $pbean)
    {
        $this->send_timPresence($pbean);
    }

    public function send_timPresence(\TimPBean $pbean)
    {
        $args = new \ITim_timPresence_args();
        $args->pbean = $pbean;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timPresence',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timPresence', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timMessage(\TimMBean $mbean)
    {
        $this->send_timMessage($mbean);
    }

    public function send_timMessage(\TimMBean $mbean)
    {
        $args = new \ITim_timMessage_args();
        $args->mbean = $mbean;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timMessage',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timMessage', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timPing($threadId)
    {
        $this->send_timPing($threadId);
    }

    public function send_timPing($threadId)
    {
        $args = new \ITim_timPing_args();
        $args->threadId = $threadId;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timPing',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timPing', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timError(\TimError $e)
    {
        $this->send_timError($e);
    }

    public function send_timError(\TimError $e)
    {
        $args = new \ITim_timError_args();
        $args->e = $e;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timError',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timError', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timLogout()
    {
        $this->send_timLogout();
    }

    public function send_timLogout()
    {
        $args = new \ITim_timLogout_args();
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timLogout',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timLogout', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timRegist(\Tid $tid, $auth)
    {
        $this->send_timRegist($tid, $auth);
    }

    public function send_timRegist(\Tid $tid, $auth)
    {
        $args = new \ITim_timRegist_args();
        $args->tid = $tid;
        $args->auth = $auth;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timRegist',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timRegist', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timRoser(\TimRoster $roster)
    {
        $this->send_timRoser($roster);
    }

    public function send_timRoser(\TimRoster $roster)
    {
        $args = new \ITim_timRoser_args();
        $args->roster = $roster;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timRoser',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timRoser', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timMessageList(\TimMBeanList $mbeanList)
    {
        $this->send_timMessageList($mbeanList);
    }

    public function send_timMessageList(\TimMBeanList $mbeanList)
    {
        $args = new \ITim_timMessageList_args();
        $args->mbeanList = $mbeanList;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timMessageList',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timMessageList', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timPresenceList(\TimPBeanList $pbeanList)
    {
        $this->send_timPresenceList($pbeanList);
    }

    public function send_timPresenceList(\TimPBeanList $pbeanList)
    {
        $args = new \ITim_timPresenceList_args();
        $args->pbeanList = $pbeanList;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timPresenceList',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timPresenceList', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timMessageIq(\TimMessageIq $timMsgIq, $iqType)
    {
        $this->send_timMessageIq($timMsgIq, $iqType);
    }

    public function send_timMessageIq(\TimMessageIq $timMsgIq, $iqType)
    {
        $args = new \ITim_timMessageIq_args();
        $args->timMsgIq = $timMsgIq;
        $args->iqType = $iqType;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timMessageIq',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timMessageIq', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timMessageResult(\TimMBean $mbean)
    {
        $this->send_timMessageResult($mbean);
    }

    public function send_timMessageResult(\TimMBean $mbean)
    {
        $args = new \ITim_timMessageResult_args();
        $args->mbean = $mbean;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timMessageResult',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timMessageResult', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timProperty(\TimPropertyBean $tpb)
    {
        $this->send_timProperty($tpb);
    }

    public function send_timProperty(\TimPropertyBean $tpb)
    {
        $args = new \ITim_timProperty_args();
        $args->tpb = $tpb;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timProperty',
                TMessageType::ONEWAY,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timProperty', TMessageType::ONEWAY, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function timRemoteUserAuth(\Tid $tid, $pwd, \TimAuth $auth)
    {
        $this->send_timRemoteUserAuth($tid, $pwd, $auth);
        return $this->recv_timRemoteUserAuth();
    }

    public function send_timRemoteUserAuth(\Tid $tid, $pwd, \TimAuth $auth)
    {
        $args = new \ITim_timRemoteUserAuth_args();
        $args->tid = $tid;
        $args->pwd = $pwd;
        $args->auth = $auth;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timRemoteUserAuth',
                TMessageType::CALL,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timRemoteUserAuth', TMessageType::CALL, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function recv_timRemoteUserAuth()
    {
        $bin_accel = ($this->input_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_read_binary');
        if ($bin_accel) {
            $result = thrift_protocol_read_binary(
                $this->input_,
                '\ITim_timRemoteUserAuth_result',
                $this->input_->isStrictRead()
            );
        } else {
            $rseqid = 0;
            $fname = null;
            $mtype = 0;

            $this->input_->readMessageBegin($fname, $mtype, $rseqid);
            if ($mtype == TMessageType::EXCEPTION) {
                $x = new TApplicationException();
                $x->read($this->input_);
                $this->input_->readMessageEnd();
                throw $x;
            }
            $result = new \ITim_timRemoteUserAuth_result();
            $result->read($this->input_);
            $this->input_->readMessageEnd();
        }
        if ($result->success !== null) {
            return $result->success;
        }
        throw new \Exception("timRemoteUserAuth failed: unknown result");
    }

    public function timRemoteUserGet(\Tid $tid, \TimAuth $auth)
    {
        $this->send_timRemoteUserGet($tid, $auth);
        return $this->recv_timRemoteUserGet();
    }

    public function send_timRemoteUserGet(\Tid $tid, \TimAuth $auth)
    {
        $args = new \ITim_timRemoteUserGet_args();
        $args->tid = $tid;
        $args->auth = $auth;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timRemoteUserGet',
                TMessageType::CALL,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timRemoteUserGet', TMessageType::CALL, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function recv_timRemoteUserGet()
    {
        $bin_accel = ($this->input_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_read_binary');
        if ($bin_accel) {
            $result = thrift_protocol_read_binary(
                $this->input_,
                '\ITim_timRemoteUserGet_result',
                $this->input_->isStrictRead()
            );
        } else {
            $rseqid = 0;
            $fname = null;
            $mtype = 0;

            $this->input_->readMessageBegin($fname, $mtype, $rseqid);
            if ($mtype == TMessageType::EXCEPTION) {
                $x = new TApplicationException();
                $x->read($this->input_);
                $this->input_->readMessageEnd();
                throw $x;
            }
            $result = new \ITim_timRemoteUserGet_result();
            $result->read($this->input_);
            $this->input_->readMessageEnd();
        }
        if ($result->success !== null) {
            return $result->success;
        }
        throw new \Exception("timRemoteUserGet failed: unknown result");
    }

    public function timRemoteUserEdit(\Tid $tid, \TimUserBean $ub, \TimAuth $auth)
    {
        $this->send_timRemoteUserEdit($tid, $ub, $auth);
        return $this->recv_timRemoteUserEdit();
    }

    public function send_timRemoteUserEdit(\Tid $tid, \TimUserBean $ub, \TimAuth $auth)
    {
        $args = new \ITim_timRemoteUserEdit_args();
        $args->tid = $tid;
        $args->ub = $ub;
        $args->auth = $auth;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timRemoteUserEdit',
                TMessageType::CALL,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timRemoteUserEdit', TMessageType::CALL, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function recv_timRemoteUserEdit()
    {
        $bin_accel = ($this->input_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_read_binary');
        if ($bin_accel) {
            $result = thrift_protocol_read_binary(
                $this->input_,
                '\ITim_timRemoteUserEdit_result',
                $this->input_->isStrictRead()
            );
        } else {
            $rseqid = 0;
            $fname = null;
            $mtype = 0;

            $this->input_->readMessageBegin($fname, $mtype, $rseqid);
            if ($mtype == TMessageType::EXCEPTION) {
                $x = new TApplicationException();
                $x->read($this->input_);
                $this->input_->readMessageEnd();
                throw $x;
            }
            $result = new \ITim_timRemoteUserEdit_result();
            $result->read($this->input_);
            $this->input_->readMessageEnd();
        }
        if ($result->success !== null) {
            return $result->success;
        }
        throw new \Exception("timRemoteUserEdit failed: unknown result");
    }

    public function timResponsePresence(\TimPBean $pbean, \TimAuth $auth)
    {
        $this->send_timResponsePresence($pbean, $auth);
        return $this->recv_timResponsePresence();
    }

    public function send_timResponsePresence(\TimPBean $pbean, \TimAuth $auth)
    {
        $args = new \ITim_timResponsePresence_args();
        $args->pbean = $pbean;
        $args->auth = $auth;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timResponsePresence',
                TMessageType::CALL,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timResponsePresence', TMessageType::CALL, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function recv_timResponsePresence()
    {
        $bin_accel = ($this->input_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_read_binary');
        if ($bin_accel) {
            $result = thrift_protocol_read_binary(
                $this->input_,
                '\ITim_timResponsePresence_result',
                $this->input_->isStrictRead()
            );
        } else {
            $rseqid = 0;
            $fname = null;
            $mtype = 0;

            $this->input_->readMessageBegin($fname, $mtype, $rseqid);
            if ($mtype == TMessageType::EXCEPTION) {
                $x = new TApplicationException();
                $x->read($this->input_);
                $this->input_->readMessageEnd();
                throw $x;
            }
            $result = new \ITim_timResponsePresence_result();
            $result->read($this->input_);
            $this->input_->readMessageEnd();
        }
        if ($result->success !== null) {
            return $result->success;
        }
        throw new \Exception("timResponsePresence failed: unknown result");
    }

    public function timResponseMessage(\TimMBean $mbean, \TimAuth $auth)
    {
        $this->send_timResponseMessage($mbean, $auth);
        return $this->recv_timResponseMessage();
    }

    public function send_timResponseMessage(\TimMBean $mbean, \TimAuth $auth)
    {
        $args = new \ITim_timResponseMessage_args();
        $args->mbean = $mbean;
        $args->auth = $auth;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timResponseMessage',
                TMessageType::CALL,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timResponseMessage', TMessageType::CALL, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function recv_timResponseMessage()
    {
        $bin_accel = ($this->input_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_read_binary');
        if ($bin_accel) {
            $result = thrift_protocol_read_binary(
                $this->input_,
                '\ITim_timResponseMessage_result',
                $this->input_->isStrictRead()
            );
        } else {
            $rseqid = 0;
            $fname = null;
            $mtype = 0;

            $this->input_->readMessageBegin($fname, $mtype, $rseqid);
            if ($mtype == TMessageType::EXCEPTION) {
                $x = new TApplicationException();
                $x->read($this->input_);
                $this->input_->readMessageEnd();
                throw $x;
            }
            $result = new \ITim_timResponseMessage_result();
            $result->read($this->input_);
            $this->input_->readMessageEnd();
        }
        if ($result->success !== null) {
            return $result->success;
        }
        throw new \Exception("timResponseMessage failed: unknown result");
    }

    public function timResponseMessageIq(\TimMessageIq $timMsgIq, $iqType, \TimAuth $auth)
    {
        $this->send_timResponseMessageIq($timMsgIq, $iqType, $auth);
        return $this->recv_timResponseMessageIq();
    }

    public function send_timResponseMessageIq(\TimMessageIq $timMsgIq, $iqType, \TimAuth $auth)
    {
        $args = new \ITim_timResponseMessageIq_args();
        $args->timMsgIq = $timMsgIq;
        $args->iqType = $iqType;
        $args->auth = $auth;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timResponseMessageIq',
                TMessageType::CALL,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timResponseMessageIq', TMessageType::CALL, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function recv_timResponseMessageIq()
    {
        $bin_accel = ($this->input_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_read_binary');
        if ($bin_accel) {
            $result = thrift_protocol_read_binary(
                $this->input_,
                '\ITim_timResponseMessageIq_result',
                $this->input_->isStrictRead()
            );
        } else {
            $rseqid = 0;
            $fname = null;
            $mtype = 0;

            $this->input_->readMessageBegin($fname, $mtype, $rseqid);
            if ($mtype == TMessageType::EXCEPTION) {
                $x = new TApplicationException();
                $x->read($this->input_);
                $this->input_->readMessageEnd();
                throw $x;
            }
            $result = new \ITim_timResponseMessageIq_result();
            $result->read($this->input_);
            $this->input_->readMessageEnd();
        }
        if ($result->success !== null) {
            return $result->success;
        }
        throw new \Exception("timResponseMessageIq failed: unknown result");
    }

    public function timResponsePresenceList(\TimPBeanList $pbeanList, \TimAuth $auth)
    {
        $this->send_timResponsePresenceList($pbeanList, $auth);
        return $this->recv_timResponsePresenceList();
    }

    public function send_timResponsePresenceList(\TimPBeanList $pbeanList, \TimAuth $auth)
    {
        $args = new \ITim_timResponsePresenceList_args();
        $args->pbeanList = $pbeanList;
        $args->auth = $auth;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timResponsePresenceList',
                TMessageType::CALL,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timResponsePresenceList', TMessageType::CALL, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function recv_timResponsePresenceList()
    {
        $bin_accel = ($this->input_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_read_binary');
        if ($bin_accel) {
            $result = thrift_protocol_read_binary(
                $this->input_,
                '\ITim_timResponsePresenceList_result',
                $this->input_->isStrictRead()
            );
        } else {
            $rseqid = 0;
            $fname = null;
            $mtype = 0;

            $this->input_->readMessageBegin($fname, $mtype, $rseqid);
            if ($mtype == TMessageType::EXCEPTION) {
                $x = new TApplicationException();
                $x->read($this->input_);
                $this->input_->readMessageEnd();
                throw $x;
            }
            $result = new \ITim_timResponsePresenceList_result();
            $result->read($this->input_);
            $this->input_->readMessageEnd();
        }
        if ($result->success !== null) {
            return $result->success;
        }
        throw new \Exception("timResponsePresenceList failed: unknown result");
    }

    public function timResponseMessageList(\TimMBeanList $mbeanList, \TimAuth $auth)
    {
        $this->send_timResponseMessageList($mbeanList, $auth);
        return $this->recv_timResponseMessageList();
    }

    public function send_timResponseMessageList(\TimMBeanList $mbeanList, \TimAuth $auth)
    {
        $args = new \ITim_timResponseMessageList_args();
        $args->mbeanList = $mbeanList;
        $args->auth = $auth;
        $bin_accel = ($this->output_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_write_binary');
        if ($bin_accel) {
            thrift_protocol_write_binary(
                $this->output_,
                'timResponseMessageList',
                TMessageType::CALL,
                $args,
                $this->seqid_,
                $this->output_->isStrictWrite()
            );
        } else {
            $this->output_->writeMessageBegin('timResponseMessageList', TMessageType::CALL, $this->seqid_);
            $args->write($this->output_);
            $this->output_->writeMessageEnd();
            $this->output_->getTransport()->flush();
        }
    }

    public function recv_timResponseMessageList()
    {
        $bin_accel = ($this->input_ instanceof TBinaryProtocolAccelerated) && function_exists('thrift_protocol_read_binary');
        if ($bin_accel) {
            $result = thrift_protocol_read_binary(
                $this->input_,
                '\ITim_timResponseMessageList_result',
                $this->input_->isStrictRead()
            );
        } else {
            $rseqid = 0;
            $fname = null;
            $mtype = 0;

            $this->input_->readMessageBegin($fname, $mtype, $rseqid);
            if ($mtype == TMessageType::EXCEPTION) {
                $x = new TApplicationException();
                $x->read($this->input_);
                $this->input_->readMessageEnd();
                throw $x;
            }
            $result = new \ITim_timResponseMessageList_result();
            $result->read($this->input_);
            $this->input_->readMessageEnd();
        }
        if ($result->success !== null) {
            return $result->success;
        }
        throw new \Exception("timResponseMessageList failed: unknown result");
    }
}