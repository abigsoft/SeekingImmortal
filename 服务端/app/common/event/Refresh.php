<?php

namespace app\common\event;

use app\common\model\MemberModel;

class Refresh
{
    function member($uid): void
    {
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
        \support\Redis::set('user_info_' . $uid, json_encode($user_info));
        \support\Redis::hSet('task:member_list',$uid,json_encode($user_info));
    }
}