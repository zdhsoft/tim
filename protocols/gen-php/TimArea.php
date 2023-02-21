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

class TimArea
{
    static public $isValidate = false;

    static public $_TSPEC = array(
        1 => array(
            'var' => 'country',
            'isRequired' => false,
            'type' => TType::STRING,
        ),
        2 => array(
            'var' => 'province',
            'isRequired' => false,
            'type' => TType::STRING,
        ),
        3 => array(
            'var' => 'city',
            'isRequired' => false,
            'type' => TType::STRING,
        ),
        4 => array(
            'var' => 'extraList',
            'isRequired' => false,
            'type' => TType::LST,
            'etype' => TType::STRUCT,
            'elem' => array(
                'type' => TType::STRUCT,
                'class' => '\TimNode',
                ),
        ),
        5 => array(
            'var' => 'extraMap',
            'isRequired' => false,
            'type' => TType::MAP,
            'ktype' => TType::STRING,
            'vtype' => TType::STRING,
            'key' => array(
                'type' => TType::STRING,
            ),
            'val' => array(
                'type' => TType::STRING,
                ),
        ),
    );

    /**
     * 国家
     * 
     * @var string
     */
    public $country = null;
    /**
     * 省
     * 
     * @var string
     */
    public $province = null;
    /**
     * 市
     * 
     * @var string
     */
    public $city = null;
    /**
     * 附加信息：如区，镇，乡等
     * 
     * @var \TimNode[]
     */
    public $extraList = null;
    /**
     * @var array
     */
    public $extraMap = null;

    public function __construct($vals = null)
    {
        if (is_array($vals)) {
            if (isset($vals['country'])) {
                $this->country = $vals['country'];
            }
            if (isset($vals['province'])) {
                $this->province = $vals['province'];
            }
            if (isset($vals['city'])) {
                $this->city = $vals['city'];
            }
            if (isset($vals['extraList'])) {
                $this->extraList = $vals['extraList'];
            }
            if (isset($vals['extraMap'])) {
                $this->extraMap = $vals['extraMap'];
            }
        }
    }

    public function getName()
    {
        return 'TimArea';
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
                        $xfer += $input->readString($this->country);
                    } else {
                        $xfer += $input->skip($ftype);
                    }
                    break;
                case 2:
                    if ($ftype == TType::STRING) {
                        $xfer += $input->readString($this->province);
                    } else {
                        $xfer += $input->skip($ftype);
                    }
                    break;
                case 3:
                    if ($ftype == TType::STRING) {
                        $xfer += $input->readString($this->city);
                    } else {
                        $xfer += $input->skip($ftype);
                    }
                    break;
                case 4:
                    if ($ftype == TType::LST) {
                        $this->extraList = array();
                        $_size32 = 0;
                        $_etype35 = 0;
                        $xfer += $input->readListBegin($_etype35, $_size32);
                        for ($_i36 = 0; $_i36 < $_size32; ++$_i36) {
                            $elem37 = null;
                            $elem37 = new \TimNode();
                            $xfer += $elem37->read($input);
                            $this->extraList []= $elem37;
                        }
                        $xfer += $input->readListEnd();
                    } else {
                        $xfer += $input->skip($ftype);
                    }
                    break;
                case 5:
                    if ($ftype == TType::MAP) {
                        $this->extraMap = array();
                        $_size38 = 0;
                        $_ktype39 = 0;
                        $_vtype40 = 0;
                        $xfer += $input->readMapBegin($_ktype39, $_vtype40, $_size38);
                        for ($_i42 = 0; $_i42 < $_size38; ++$_i42) {
                            $key43 = '';
                            $val44 = '';
                            $xfer += $input->readString($key43);
                            $xfer += $input->readString($val44);
                            $this->extraMap[$key43] = $val44;
                        }
                        $xfer += $input->readMapEnd();
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
        $xfer += $output->writeStructBegin('TimArea');
        if ($this->country !== null) {
            $xfer += $output->writeFieldBegin('country', TType::STRING, 1);
            $xfer += $output->writeString($this->country);
            $xfer += $output->writeFieldEnd();
        }
        if ($this->province !== null) {
            $xfer += $output->writeFieldBegin('province', TType::STRING, 2);
            $xfer += $output->writeString($this->province);
            $xfer += $output->writeFieldEnd();
        }
        if ($this->city !== null) {
            $xfer += $output->writeFieldBegin('city', TType::STRING, 3);
            $xfer += $output->writeString($this->city);
            $xfer += $output->writeFieldEnd();
        }
        if ($this->extraList !== null) {
            if (!is_array($this->extraList)) {
                throw new TProtocolException('Bad type in structure.', TProtocolException::INVALID_DATA);
            }
            $xfer += $output->writeFieldBegin('extraList', TType::LST, 4);
            $output->writeListBegin(TType::STRUCT, count($this->extraList));
            foreach ($this->extraList as $iter45) {
                $xfer += $iter45->write($output);
            }
            $output->writeListEnd();
            $xfer += $output->writeFieldEnd();
        }
        if ($this->extraMap !== null) {
            if (!is_array($this->extraMap)) {
                throw new TProtocolException('Bad type in structure.', TProtocolException::INVALID_DATA);
            }
            $xfer += $output->writeFieldBegin('extraMap', TType::MAP, 5);
            $output->writeMapBegin(TType::STRING, TType::STRING, count($this->extraMap));
            foreach ($this->extraMap as $kiter46 => $viter47) {
                $xfer += $output->writeString($kiter46);
                $xfer += $output->writeString($viter47);
            }
            $output->writeMapEnd();
            $xfer += $output->writeFieldEnd();
        }
        $xfer += $output->writeFieldStop();
        $xfer += $output->writeStructEnd();
        return $xfer;
    }
}