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

class TimPropertyBean
{
    static public $isValidate = false;

    static public $_TSPEC = array(
        1 => array(
            'var' => 'threadId',
            'isRequired' => false,
            'type' => TType::STRING,
        ),
        2 => array(
            'var' => 'interflow',
            'isRequired' => false,
            'type' => TType::STRING,
        ),
        3 => array(
            'var' => 'tls',
            'isRequired' => false,
            'type' => TType::STRING,
        ),
    );

    /**
     * @var string
     */
    public $threadId = null;
    /**
     * 消息合流
     * 
     * @var string
     */
    public $interflow = null;
    /**
     * tls
     * 
     * @var string
     */
    public $tls = null;

    public function __construct($vals = null)
    {
        if (is_array($vals)) {
            if (isset($vals['threadId'])) {
                $this->threadId = $vals['threadId'];
            }
            if (isset($vals['interflow'])) {
                $this->interflow = $vals['interflow'];
            }
            if (isset($vals['tls'])) {
                $this->tls = $vals['tls'];
            }
        }
    }

    public function getName()
    {
        return 'TimPropertyBean';
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
                    if ($ftype == TType::STRING) {
                        $xfer += $input->readString($this->threadId);
                    } else {
                        $xfer += $input->skip($ftype);
                    }
                    break;
                case 2:
                    if ($ftype == TType::STRING) {
                        $xfer += $input->readString($this->interflow);
                    } else {
                        $xfer += $input->skip($ftype);
                    }
                    break;
                case 3:
                    if ($ftype == TType::STRING) {
                        $xfer += $input->readString($this->tls);
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
        $xfer += $output->writeStructBegin('TimPropertyBean');
        if ($this->threadId !== null) {
            $xfer += $output->writeFieldBegin('threadId', TType::STRING, 1);
            $xfer += $output->writeString($this->threadId);
            $xfer += $output->writeFieldEnd();
        }
        if ($this->interflow !== null) {
            $xfer += $output->writeFieldBegin('interflow', TType::STRING, 2);
            $xfer += $output->writeString($this->interflow);
            $xfer += $output->writeFieldEnd();
        }
        if ($this->tls !== null) {
            $xfer += $output->writeFieldBegin('tls', TType::STRING, 3);
            $xfer += $output->writeString($this->tls);
            $xfer += $output->writeFieldEnd();
        }
        $xfer += $output->writeFieldStop();
        $xfer += $output->writeStructEnd();
        return $xfer;
    }
}
