<?php
namespace app\api\controller\member;
use app\api\controller\Base;

class Info extends Base{
    function info(){
        $user_info = \Tinywan\Jwt\JwtToken::getUser();
        unset($user_info['password'],$user_info['delete_time']);
        return $this->success('SUCCESS',$user_info);
    }
}