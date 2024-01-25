<?php
/**
 * Notes:
 * User: 王小明
 * Date: 2020/12/29
 * Time: 11:32
 */

namespace app\common\exception;


class SystemException extends BaseException
{
    public function __construct($msg = '当前操作人数太多,请点击重试',$data = [])
    {
        parent::__construct($msg, 500, $data);
    }
}
