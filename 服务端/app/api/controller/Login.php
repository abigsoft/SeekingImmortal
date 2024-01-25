<?php

namespace app\api\controller;

use app\common\controller\BaseController;
use app\common\exception\ParamException;
use app\common\model\MemberModel;
use Tinywan\Jwt\JwtToken;

class Login extends BaseController
{
    protected function makeToken($uid,$name = ''): string
    {
        $user = [
            'id'  => $uid,
            'name'  => $name,
            'client' => JwtToken::TOKEN_CLIENT_MOBILE
        ];
        /**
         * "token_type": "Bearer",
         * "expires_in": 36000,
         * "access_token": "eyJ0eXAiOiJAUR-Gqtnk9LUPO8IDrLK7tjCwQZ7CI...",
         * "refresh_token": "eyJ0eXAiOiJIEGkKprvcccccQvsTJaOyNy8yweZc..."
         */
        return JwtToken::generateToken($user)['access_token'];
    }

    function account(){
        $account = $this->request->param('account','');
        $password = $this->request->param('password','');
        if(!$account || !$password){
            throw new ParamException('账号或密码不能为空');
        }

        $user_info = MemberModel::where('account',$account)->field('uid,account,password,nickname,account_status')->find()->toArray();
        if(!$user_info){
            throw new ParamException('账号或密码错误');
        }
        if($user_info['password'] != buildPass($password)){
            throw new ParamException('账号或密码错误');
        }

        if($user_info['account_status'] != 1){
            throw new ParamException('角色已被禁用');
        }
        $token = $this->makeToken($user_info['uid'],$user_info['nickname']);
        return $this->success('登录成功',$token);
    }

}