<?php
/**
 * Notes:
 * User: 王小明
 * Date: 2020/12/29
 * Time: 11:32
 */

namespace app\common\exception;


class ParamException extends BaseException
{
    public function __construct($msg = '参数异常', $data = '')
    {
        parent::__construct($msg, 202, $data);
    }
}
