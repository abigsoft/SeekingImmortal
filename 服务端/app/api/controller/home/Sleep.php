<?php

namespace app\api\controller\home;

use app\api\controller\Base;
use app\common\exception\ParamException;
use app\common\exception\SystemException;
use app\common\model\MemberModel;
use app\common\model\TrainModel;
use support\Redis;
use think\facade\Db;

class Sleep extends Base
{
    function create()
    {
        $uuid = get_uuid();
        Redis::set('TRAIN:' . $this->uid, json_encode([
            'id' => $uuid,
            'type' => 'sleep',
            'create_time' => formatDate(),
            'time' => time(),
        ]), null, 10 * 60);
        return $this->success('SUCCESS', [
            'type' => 'sleep',
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
        if ($data['type'] != 'sleep') {
            $this->success('数据不存在');
        }
        if ($this->user['data_physical'] >= $this->user['data_physical_max']) {
            throw new ParamException('体力已满');
        }
        if (time() - $data['time'] < 600) {
            return $this->success('数据不存在');
        }
        if ($key != $data['id']) {
            return $this->success('数据不存在');
        }
        $result = '休息成功，获得 1 点体力';
        $res = MemberModel::where('uid', $this->uid)
            ->where('data_physical < data_physical_max')
            ->inc('data_physical')->update();
        if($res <= 0){
            throw new ParamException('体力已满');
        }
        //随机捡到物品
        TrainModel::create([
            'member_uid' => $this->uid,
            'type' => 'sleep',
            'result' => $result
        ]);
        $this->refreshUser($this->uid);
        return $this->success($result);
    }
}