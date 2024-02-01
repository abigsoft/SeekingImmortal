<?php

namespace app\common\task;

use app\common\model\MemberModel;
use GatewayWorker\Lib\Gateway;
use support\Redis;
use Webman\Event\Event;
use Workerman\Timer;

class MemberOnline
{
    public function onWorkerStart()
    {
        $redis = Redis::connection('default');
        //初始化用户列表
        if (!$redis->exists('task:member_list')) {
            foreach (MemberModel::column('uid,nickname,sex,steam_id,level_id,data_physical,data_physical_max,world_online_time') as $member) {
                $redis->hSet('task:member_list', $member['uid'], json_encode($member));
            }
        }
        Timer::add(3600, function () use ($redis) {
            $member_list = $redis->hGetAll('task:member_list');
            foreach ($member_list as $uid => $member) {
                //上次在不在线
                $last_online = false;
                if ($redis->get('task:member_online_last:' . $uid)) {
                    $last_online = true;
                }
                $online = Gateway::isUidOnline($uid);
                if($online){
                    $redis->set('task:member_online_last:' . $uid, "1");
                    if ($last_online) {
                        MemberModel::where('uid', $uid)->inc('world_online_time')->update();
                        /**
                        Event::emit('refresh.member',$uid);
                        Gateway::sendToUid($uid,json_encode([
                            'type'=>'system',
                            'data'=>[
                                'type' => 'init',
                                'data' => 'user',
                            ]
                        ]));**/
                    }
                }else{
                    $redis->set('task:member_online_last:' . $uid, "0");
                }
            }
        });
    }
}