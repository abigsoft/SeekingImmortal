<?php

namespace app\api\controller;

use app\common\controller\BaseController;
use app\common\exception\ParamException;
use app\common\model\MemberModel;
use app\common\validate\MemberValidate;
use Tinywan\Jwt\JwtToken;

class Register extends BaseController
{
    function account()
    {
        $param = $this->request->param([
            'account' => '',
            'password' => '',
            'nickname' => '',
            'sex' => 0
        ]);
        $validate = new MemberValidate;
        if (!$validate->scene('register')->check($param)) {
            throw new ParamException($validate->getError());
        }

        $nature = $this->request->param('nature',0);
        if(!in_array($nature,[0,1,2,3])){
            throw new ParamException('性格错误');
        }

        $uuid = get_uuid();
        MemberModel::create([
            'uid' => $uuid,
            'account' => $param['account'],
            'password' => buildPass($param['password']),
            'nickname' => $param['nickname'],
            'callname' => '主人',
            'sex' => $param['sex'],
            'steam_id' => '',
            'is_clever' => $nature == 1 ? 1 : 0,//是否聪明
            'is_kindness' => $nature == 2 ? 1 : 0,//是否善良
            'is_brave' => $nature == 3 ? 1 : 0,//是否勇敢
        ]);
        $token = $this->makeToken($uuid,$param['nickname']);
        return $this->success('注册成功',$token);
    }

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
}