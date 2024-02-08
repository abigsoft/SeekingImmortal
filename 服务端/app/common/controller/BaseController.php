<?php

namespace app\common\controller;

use app\common\model\MemberModel;
use support\Request;
use support\Cache;
use support\View;
use Webman\Event\Event;

class BaseController
{
    protected $request;
    protected $config;
    protected int $successCode;
    protected int $errorCode;

    public function __construct()
    {
        // 控制器初始化
        $this->initialize();
    }

    public function beforeAction(Request $request){
        $this->request = $request;
        $app = $this->request->app;
        $controller = $this->request->controller;

        $action = $this->request->action;

        $config = Cache::get('sys');
        $this->config = $config;

        View::assign(['config' => $config]);

    }

    // 初始化
    protected function initialize(): void
    {

        $this->successCode = config('my.successCode');
        $this->errorCode = config('my.errorCode');

        buildConfig();
        buildDict();
    }

    protected function success($message = '操作成功',$data = []): \support\Response
    {
        return json([
            'status'=>config('my.successCode'),
            'msg'=> $message,
            'data' => $data
        ]);
    }

    protected function error($message = '操作失败',$data = []): \support\Response
    {
        return json([
            'status'=>config('my.errorCode'),
            'msg'=> $message,
            'data' => $data
        ]);
    }

    protected function assign(...$vars)
    {
        View::assign(...$vars);
    }

    protected function refreshUser($uid): void
    {
        Event::emit('refresh.member',$uid);
        /*
        $user_info = MemberModel::where('uid',$uid)->field('uid,account,password,nickname,
            sex,steam_id,account_status,character_status,level_id,data_exp,
            data_insight,data_fortune,data_physical,data_physical_max,
            data_gold_coin,data_spirit_stone,equip_super_id,equip_head_id,
            equip_weapon_id,equip_tops_id,equip_pants_id,equip_shoes_id,
            equip_jewelry_id,mask_title_id,mask_title_name,world_blood,
            world_blood_max,world_attack_physics,world_attack_magic,
            world_defense_physics,world_defense_magic,world_speed,
            world_critical_rate,world_critical_data,world_sure,world_evade,
            world_online_time,data_dot')->find();
        \support\Redis::set('user_info_' . $uid, $user_info);
        \support\Redis::hSet('task:member_list',$uid,$user_info);*/
    }
}