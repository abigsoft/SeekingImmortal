<?php

namespace app\api\controller\market;

use app\api\controller\Base;
use app\common\exception\ParamException;
use app\common\model\MemberModel;
use app\common\model\MemberSignModel;
use support\Redis;
use think\facade\Db;

class Sign extends Base
{
    function create()
    {
        if (Redis::get('SIGN:' . $this->uid) == date('Y-m-d')) {
            return $this->error('今日已祈福');
        }
        $result = "祈福成功,获得 ";
        Redis::set("SIGN:" . $this->uid, date('Y-m-d'),null,86400);
        if(rate(10)){
            $reset_physical = $this->user['data_physical_max'];
            $model = MemberModel::where('uid', $this->uid)
                ->inc('data_physical',$reset_physical);
            $result .= $reset_physical . " 点体力。";
        }else{
            MemberModel::where('uid', $this->uid)->update([
                'data_physical' => Db::raw('data_physical_max')
            ]);
            $result .= "体力恢复、";
            $model = MemberModel::where('uid', $this->uid);
        }

        //金币
        $rand_coin = random_int(50, 200);
        $model->inc('data_gold_coin', $rand_coin);
        $result .= $rand_coin . " 个金币。";

        $model->update();
        $this->refreshUser($this->uid);
        return $this->success($result);
    }
}