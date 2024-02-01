<?php

namespace app\api\controller\home;

use app\api\controller\Base;
use app\common\exception\ParamException;
use app\common\model\MemberModel;
use app\common\model\TrainModel;
use support\Redis;

class Mining extends Base
{
    function create()
    {
        $uuid = get_uuid();
        Redis::set('TRAIN:' . $this->uid, json_encode([
            'id' => $uuid,
            'type' => 'mining',
            'create_time' => formatDate(),
            'time' => time(),
        ]), null, 10 * 60);
        return $this->success('SUCCESS', [
            'type' => 'mining',
            'key' => $uuid,
            'time' => 600
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
        if ($data['type'] != 'mining') {
            $this->success('数据不存在');
        }
        if ($this->user['data_physical'] < 1) {
            throw new ParamException('体力不足');
        }
        if (time() - $data['time'] < 600) {
            return $this->success('数据不存在');
        }
        if ($key != $data['id']) {
            return $this->success('数据不存在');
        }
        if (rate(60)) {
            MemberModel::where('uid', $this->uid)
                ->dec('data_physical')->update();
            $this->refreshUser($this->uid);
            return $this->success('挖矿失败，没有失去也没有获得。');
        }
        $result = '挖矿成功，获得 ';
        $model = MemberModel::where('uid', $this->uid)
            ->dec('data_physical');
        //$update[] = ['data_physical'=>Db::raw('data_physical')];
        if (rate(60)) {//金币
            //经验、血量
            $rand_stone = random_int(1, 3);
            $model->inc('data_spirit_stone', $rand_stone)->update();
            $result .= $rand_stone . " 块灵石、";
        }
        $rand_gold = random_int(1, 10);
        $model->inc('data_gold_coin', $rand_gold);
        $result .= $rand_gold . " 枚金币。";
        //随机捡到物品
        TrainModel::create([
            'member_uid' => $this->uid,
            'type' => 'mining',
            'result' => $result
        ]);
        $this->refreshUser($this->uid);
        return $this->success($result);
    }
}