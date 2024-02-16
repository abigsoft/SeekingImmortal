<?php

namespace app\api\controller\member;

use app\api\controller\Base;
use app\common\model\MemberJobModel;
use app\common\model\MemberModel;
use support\Redis;

class Dot extends Base
{
    function get(): \support\Response
    {
        $result = [
            'start' => 0,
            'way' => [
                'assassin' => [
                    'first' => 0,
                    'second' => 0,
                    'third' => 0,
                    'level' => 0
                ],
                'soldier' => [
                    'first' => 0,
                    'second' => 0,
                    'third' => 0,
                    'level' => 0
                ],
                'auxiliary' => [
                    'first' => 0,
                    'second' => 0,
                    'third' => 0,
                    'level' => 0
                ]
            ]
        ];
        $job_data = MemberJobModel::where('member_uid', $this->uid)
            ->column('id,job_way,job_data,level');
        if ($job_data) {
            foreach ($job_data as $v) {
                if($v['job_way'] == 0){
                    $result['start'] = 1;
                }
                if ($v['job_way'] == 1) {
                    if ($v['job_data'] & 1 > 0) {
                        $result['way']['assassin']['first'] = 1;
                    }
                    if ($v['job_data'] & 2 > 0) {
                        $result['way']['assassin']['second'] = 1;
                    }
                    if ($v['job_data'] & 4 > 0) {
                        $result['way']['assassin']['third'] = 1;
                    }
                    $result['way']['assassin']['way'] = $v['level'];
                }
                if ($v['job_way'] == 2) {
                    if ($v['job_data'] & 1 > 0) {
                        $result['way']['soldier']['first'] = 1;
                    }
                    if ($v['job_data'] & 2 > 0) {
                        $result['way']['soldier']['second'] = 1;
                    }
                    if ($v['job_data'] & 4 > 0) {
                        $result['way']['soldier']['third'] = 1;
                    }
                    $result['way']['soldier']['way'] = $v['level'];
                }
                if ($v['job_way'] == 3) {
                    if ($v['job_data'] & 1 > 0) {
                        $result['way']['auxiliary']['first'] = 1;
                    }
                    if ($v['job_data'] & 2 > 0) {
                        $result['way']['auxiliary']['second'] = 1;
                    }
                    if ($v['job_data'] & 4 > 0) {
                        $result['way']['auxiliary']['third'] = 1;
                    }
                    $result['way']['auxiliary']['way'] = $v['level'];
                }
            }
        }
        return $this->success('SUCCESS', [
            'job' => $result
        ]);
    }

    function common()
    {
        $type = $this->request->param('type', '');
        $number = $this->request->param('number', 1);

        if ($this->user['data_dot'] < $number) {
            return $this->error('可用属性点不足');
        }

        switch ($type) {
            case 'blood'://血量
                $res = MemberModel::where('uid', $this->uid)
                    ->where('data_dot', '>=', $number)
                    ->inc('world_blood', $number * 50)
                    ->inc('world_blood_max', $number * 50)
                    ->dec('data_dot', $number)
                    ->update();
                break;
            case 'attack_physics'://物攻
                $res = MemberModel::where('uid', $this->uid)
                    ->where('data_dot', '>=', $number)
                    ->inc('world_attack_physics', $number)
                    ->dec('data_dot', $number)
                    ->update();
                break;
            case 'attack_magic'://法攻
                $res = MemberModel::where('uid', $this->uid)
                    ->where('data_dot', '>=', $number)
                    ->inc('world_attack_magic', $number)
                    ->dec('data_dot', $number)
                    ->update();
                break;
            case 'defense_physics'://物防
                $res = MemberModel::where('uid', $this->uid)
                    ->where('data_dot', '>=', $number)
                    ->inc('world_defense_physics', $number)
                    ->dec('data_dot', $number)
                    ->update();
                break;
            case 'defense_magic'://法防
                $res = MemberModel::where('uid', $this->uid)
                    ->where('data_dot', '>=', $number)
                    ->inc('world_defense_magic', $number)
                    ->dec('data_dot', $number)
                    ->update();
                break;
            default:
                return $this->error();
        }
        if ($res <= 0) {
            return $this->error('操作失败，请稍后重试');
        }
        $this->refreshUser($this->uid);
        return $this->success();
    }

    function job()
    {
        $row = $this->request->param('row', 0);
        $col = $this->request->param('col', 0);
        if (Redis::get('API:DOT:JOB:' . $this->uid)) {
            return $this->error('服务器资源不足，请五秒后重试');
        }
        Redis::setEx('API:DOT:JOB:' . $this->uid, 5, 1);
        $job_data = MemberJobModel::where('member_uid', $this->uid)
            ->column('id,job_way,job_data,level');
        if($row == 0){

        }
        return $this->success();
    }
}