<?php

namespace app\api\controller\home;

use app\api\controller\Base;
use app\common\exception\ParamException;
use app\common\exception\SystemException;
use app\common\model\MemberModel;
use app\common\model\TrainModel;
use support\Redis;
use think\facade\Db;

class Train extends Base
{
    function create()
    {
        $uuid = get_uuid();
        Redis::set('TRAIN:' . $this->uid, json_encode([
            'id' => $uuid,
            'type' => 'train',
            'create_time' => formatDate(),
            'time' => time(),
        ]), null, 10 * 60);
        return $this->success('SUCCESS', [
            'type' => 'train',
            'key' => $uuid,
            'time' => 300
        ]);
    }

    function finish()
    {
        $key = $this->request->param('key', '');
        if (!$key) {
            $this->success('数据不存在');
        }
        $data = Redis::get('TRAIN:' . $this->uid);
        if (!$data) {
            $this->success('数据不存在');
        }
        $data = json_decode($data, true);
        Redis::del('TRAIN:' . $this->uid);
        if ($data['type'] != 'train') {
            $this->success('数据不存在');
        }
        if ($this->user['data_physical'] < 1) {
            throw new ParamException('体力不足');
        }
        if (time() - $data['time'] < 300) {
            return $this->success('数据不存在');
        }
        if ($key != $data['id']) {
            return $this->success('数据不存在');
        }
        if (rate(20)) {
            MemberModel::where('uid', $this->uid)
                ->dec('data_physical')->update();
            $this->refreshUser($this->uid);
            return $this->success('感悟失败，没有失去也没有获得。');
        }
        $result = '感悟成功，获得 ';
        $model = MemberModel::where('uid', $this->uid)
            ->dec('data_physical');
        //$update[] = ['data_physical'=>Db::raw('data_physical')];
        //属性点
        if (rate(80)) {//金币
            $rand_gold = random_int(1, 10);
            $model->inc('data_gold_coin', $rand_gold);
            $result .= $rand_gold . " 枚金币、";
        }

        if (rate(80)) {//金币
            $rand_dot = random_int(1, 3);
            $model->inc('data_gold_coin', $rand_dot);
            $result .= $rand_dot . " 点属性、";
        }

        //经验、血量
        $rand_exp = random_int(2, 14);
        $model->inc('data_exp', $rand_exp)->inc('world_blood', $rand_exp)
            ->inc('world_blood_max', $rand_exp)->update();
        $result .= $rand_exp . " 点经验。";
        //随机捡到物品
        TrainModel::create([
            'member_uid' => $this->uid,
            'type' => 'train',
            'result' => $result
        ]);
        $this->refreshUser($this->uid);
        return $this->success($result);
    }
}