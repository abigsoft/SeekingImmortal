<?php

namespace app\admin\controller;

use app\common\exception\ParamException;
use think\facade\Db;
use yzh52521\Task\Client;

class Task extends Base
{
    /*首页数据列表*/
    function index()
    {
        if (!$this->request->isAjax()) {
            return view('task/index');
        } else {
            $limit = $this->request->post('limit');
            $offset = $this->request->post('offset');
            $page = floor($offset / $limit) + 1;

            $res = Client::instance()->request([
                'method' => 'crontabIndex',//计划任务列表
                'args' => ['limit' => $limit, 'page' => $page]//参数
            ]);
            if($res->code == 200){
                $res = $res->data;
                return json(['rows' => $res->data, 'total' => $res->total]);
            }
            throw new ParamException($res['msg']);
        }
    }

    function log()
    {
        $id = $this->request->param('id');
        if (!$this->request->isAjax()) {
            return view('task/log');
        } else {
            $limit = $this->request->post('limit');
            $offset = $this->request->post('offset');
            $page = floor($offset / $limit) + 1;

            $res = Client::instance()->request([
                'method' => 'crontabLog',//计划任务列表
                'args' => ['limit' => $limit, 'page' => $page, 'crontab_id' => $id]//参数
            ]);
            if($res->code == 200){
                $res = $res->data;
                return json(['rows' => $res->data, 'total' => $res->total]);
            }
            throw new ParamException($res['msg']);

        }
    }

    /*修改排序开关按钮操作*/
    function restart()
    {
        $id = $this->request->param('id',0);
        if (!$id)
            return $this->error('参数错误');
        $res = Client::instance()->request([
            'method' => 'crontabReload',
            'args' => ['id' => $id]//参数
        ]);

        if($res->code == 200){
            $res = $res->data;
            if($res->code){
                return $this->success('启动成功');
            }else{
                return $this->error('启动失败');
            }
        }
        throw new ParamException($res['msg']);
    }

    /*修改*/
    function update()
    {
        $id = $this->request->get('id');
        if (!$this->request->isPost()) {
            $this->assign('id', $id);
            $info = Db::table('system_crontab')->find($id) ?: [
                'title' => '',
                'type' => 1,
                'rule' => '',
                'target' => '',
                'parameter' => '',
                'status' => 0,
                'remark' => '',
                'sort' => 50,
                'singleton' => 0
            ];
            $this->assign('info', $info);
            return view('task/update');
        } else {
            $param = $this->request->param([
                'title' => '',
                'type' => 1,
                'rule' => '',
                'target' => '',
                'parameter' => '{}',
                'status' => 0,
                'remark' => '',
                'sort' => 50,
                'singleton' => 0
            ]);
            if(!$param['parameter']){
                $param['parameter'] = '{}';
            }
            if (!$id) {
                $res = Client::instance()->request([
                    'method' => 'crontabCreate',
                    'args' => $param
                ]);
                if($res->code == 200){
                    return $this->success('提交成功');
                }else{
                    return $this->error('提交失败');
                }
            } else {
                $param['id'] = $id;
                $res = Client::instance()->request([
                    'method' => 'crontabUpdate',
                    'args' => $param
                ]);
                if($res->code == 200){
                    $res = $res->data;
                    if($res->code){
                        return $this->success('提交成功');
                    }else{
                        return $this->error('提交失败');
                    }
                }
            }

            return $this->success('提交成功');
        }
    }

    /*删除*/
    function delete()
    {
        $id = $this->request->param('id',0);
        if (!$id)
            return $this->error('参数错误');
        $res = Client::instance()->request([
            'method' => 'crontabDelete',
            'args' => ['id' => $id]//参数
        ]);
        if($res->code == 200){
            $res = $res->data;
            if($res->code){
                return $this->success('启动成功');
            }else{
                return $this->error('启动失败');
            }
        }
        throw new ParamException($res['msg']);
    }
}