<?php
namespace app\api\controller\member;
use app\api\controller\Base;

class Info extends Base{
    function info(){
        $user_info = \Tinywan\Jwt\JwtToken::getUser();
        unset($user_info['password'],$user_info['delete_time']);
        $user_info['level_title'] = config('world.level_list')[$this->user['level_id']] ?? '未知生物';
        $user_info['data_fortune'] = "好运";
        return $this->success('SUCCESS',$user_info);
    }
}