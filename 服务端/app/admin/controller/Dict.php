<?php

namespace app\admin\controller;

use app\common\model\DictModel;

class Dict extends Base
{
    function index(){
        if (!$this->request->isAjax()) {
            return view('dict/index');
        } else {
            $limit = $this->request->post('limit');
            $offset = $this->request->post('offset');
            $page = floor($offset / $limit) + 1;

            $where[] = ['title|name|desc|data', 'like', $this->request->param('keywords')];
            $where[] = ['status', '=', $this->request->param('status')];

            $order = $this->request->post('order');    //排序字段 bootstrap-table 传入
            $sort = $this->request->post('sort');        //排序方式 desc 或 asc

            $order = ($sort && $order) ? $sort . ' ' . $order : 'id desc';

            $res = DictModel::where(formatWhere($where))
                ->order($order)
                ->paginate(['list_rows' => $limit, 'page' => $page])
                ->toArray();
            return json(['rows' => $res['data'], 'total' => $res['total']]);
        }
    }

    function update(){
        $id = $this->request->get('id', 0);
        if (!$this->request->isPost()) {
            $this->assign('id', $id);
            $info = DictModel::find($id) ?: new DictModel();
            $this->assign('info', $info);
            return view('dict/update');
        } else {
            $data = $this->request->param([
                'name' => '',
                'title' => '',
                'status' => 1,
                'desc' => '',
                'type' => 1,
                'data' => '',
            ]);
            if($id){
                DictModel::update($data,[
                    'id' => $id
                ]);
            }else{
                DictModel::create($data);
            }
            return $this->success('提交成功');
        }
    }

    function status(){
        $postField = 'id,status';
        $data = $this->request->only(explode(',', $postField), 'param', null);
        if (!$data['id'])
            return $this->error('参数错误');
        DictModel::update($data);
        return $this->success('操作成功');
    }

    function delete(){
        $idx = $this->request->post('id');
        if (!$idx) return $this->error('参数错误');
        DictModel::destroy(['id' => explode(',', $idx)]);
        return $this->success('操作成功');
    }

    function refresh(){
        cache('dict', null);
        buildDict();
        return $this->success('操作成功');
    }
}