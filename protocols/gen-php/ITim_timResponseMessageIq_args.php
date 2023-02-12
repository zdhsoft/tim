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

class ITim_timResponseMessageIq_args
{
    static public $isValidate = false;

    static public $_TSPEC = array(
        1 => array(
            'var' => 'timMsgIq',
            'isRequired' => false,
            'type' => TType::STRUCT,
            'class' => '\TimMessageIq',
        ),
        2 => array(
            'var' => 'iqType',
            'isRequired' => false,
            'type' => TType::STRING,
        ),
        3 => array(
            'var' => 'auth',
            'isRequired' => false,
            'type' => TType::STRUCT,
            'class' => '\TimAuth',
        ),
    );

    /**
     * @var \TimMessageIq
     */
    public $timMsgIq = null;
    /**
     * @var string
     */
    public $iqType = null;
    /**
     * @var \TimAuth
     */
    public $auth = null;

    public function __construct($vals = null)
    {
        if (is_array($vals)) {
            if (isset($vals['timMsgIq'])) {
                $this->timMsgIq = $vals['timMsgIq'];
            }
            if (isset($vals['iqType'])) {
                $this->iqType = $vals['iqType'];
            }
            if (isset($vals['auth'])) {
                $this->auth = $vals['auth'];
            }
        }
    }

    public function getName()
    {
        return 'ITim_timResponseMessageIq_args';
    }


    public function read($input)
    {
        $xfer = 0;
        $fname = null;
        $ftype = 0;
        $fid = 0;
        $xfer += $input->readStructBegin($fname);
        while (true) {
            $xfer += $input->readFieldBegin($fname, $ftype, $fid);
            if ($ftype == TType::STOP) {
                break;
            }
            switch ($fid) {
                case 1:
                    if ($ftype == TType::STRUCT) {
                        $this->timMsgIq = new \TimMessageIq();
                        $xfer += $this->timMsgIq->read($input);
                    } else {
                        $xfer += $input->skip($ftype);
                    }
                    break;
                case 2:
                    if ($ftype == TType::STRING) {
                        $xfer += $input->readString($this->iqType);
                    } else {
                        $xfer += $input->skip($ftype);
                    }
                    break;
                case 3:
                    if ($ftype == TType::STRUCT) {
                        $this->auth = new \TimAuth();
                        $xfer += $this->auth->read($input);
                    } else {
                        $xfer += $input->skip($ftype);
                    }
                    break;
                default:
                    $xfer += $input->skip($ftype);
                    break;
            }
            $xfer += $input->readFieldEnd();
        }
        $xfer += $input->readStructEnd();
        return $xfer;
    }

    public function write($output)
    {
        $xfer = 0;
        $xfer += $output->writeStructBegin('ITim_timResponseMessageIq_args');
        if ($this->timMsgIq !== null) {
            if (!is_object($this->timMsgIq)) {
                throw new TProtocolException('Bad type in structure.', TProtocolException::INVALID_DATA);
            }
            $xfer += $output->writeFieldBegin('timMsgIq', TType::STRUCT, 1);
            $xfer += $this->timMsgIq->write($output);
            $xfer += $output->writeFieldEnd();
        }
        if ($this->iqType !== null) {
            $xfer += $output->writeFieldBegin('iqType', TType::STRING, 2);
            $xfer += $output->writeString($this->iqType);
            $xfer += $output->writeFieldEnd();
        }
        if ($this->auth !== null) {
            if (!is_object($this->auth)) {
                throw new TProtocolException('Bad type in structure.', TProtocolException::INVALID_DATA);
            }
            $xfer += $output->writeFieldBegin('auth', TType::STRUCT, 3);
            $xfer += $this->auth->write($output);
            $xfer += $output->writeFieldEnd();
        }
        $xfer += $output->writeFieldStop();
        $xfer += $output->writeStructEnd();
        return $xfer;
    }
}
