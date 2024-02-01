<?php

namespace app\api\controller;

use app\common\controller\BaseController;
use app\common\exception\ParamException;
use app\common\model\MemberModel;
use app\common\validate\MemberValidate;
use Tinywan\Jwt\JwtToken;
use Webman\Event\Event;

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
        $uuid = get_uuid();
        MemberModel::create([
            'uid' => $uuid,
            'account' => $param['account'],
            'password' => buildPass($param['password']),
            'nickname' => $param['nickname'],
            'sex' => $param['sex'],
            'steam_id' => '',
            'account_status' => 1,
            'character_status' => 1,
            'level_id' => 0,
            'data_exp' => 0,
            'data_insight' => 0,
            'data_fortune' => 0,
            'data_physical' => 0,
            'data_physical_max' => 0,
            'data_gold_coin' => 0,
            'data_spirit_stone' => 0,
            'equip_super_id' => 0,
            'equip_head_id' => 0,
            'equip_weapon_id' => 0,
            'equip_tops_id' => 0,
            'equip_pants_id' => 0,
            'equip_shoes_id' => 0,
            'equip_jewelry_id' => 0,
            'mask_title_id' => 0,
            'mask_title_name' => 0,
            'world_blood' => 0,
            'world_blood_max' => 0,
            'world_attack_physics' => 0,
            'world_attack_magic' => 0,
            'world_defense_physics' => 0,
            'world_defense_magic' => 0,
            'world_speed' => 1,
            'world_critical_rate' => 0,
            'world_critical_data' => 0,
            'world_sure' => 0,
            'world_evade' => 0,
            'world_online_time' => 0,
        ]);
        $token = $this->makeToken($uuid, $param['nickname']);
        Event::emit('refresh.member',$uuid);
        return $this->success('注册成功', $token);
    }

    protected function makeToken($uid, $name = ''): string
    {
        $user = [
            'id' => $uid,
            'name' => $name,
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