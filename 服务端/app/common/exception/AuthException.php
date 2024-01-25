<?php
/**
 * Notes:
 * User: 王小明
 * Date: 2020/12/29
 * Time: 11:32
 */

namespace app\common\exception;

class AuthException extends BaseException
{
    public function __construct()
    {
        parent::__construct('登录失效', config('my.jwtExpireCode'));
    }
}
