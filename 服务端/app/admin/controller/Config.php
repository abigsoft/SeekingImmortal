<?php

namespace app\admin\controller;

use app\common\model\ConfigModel;

class Config extends Base
{
    function config()
    {
        $id = $this->request->param('group_id', 1);
        $list = ConfigModel::where('group', $id)
            ->where('status', 1)
            ->order('sort asc')
            ->select();
        if ($this->request->isGet()) {
            $this->assign([
                'type_list' => [
                    '1' => ['title' => '字符', 'desc' => 'input[type=text]'],
                    '2' => ['title' => '数字', 'desc' => 'input[type=number]'],
                    '3' => ['title' => '文本', 'desc' => 'textarea框'],
                    '4' => ['title' => '枚举', 'desc' => 'key:value->写入item 配置值为默认值 下拉选择框,一行代表一项'],
                    '5' => ['title' => '数组', 'desc' => 'value,value1 多个以逗号分隔,'],
                ],
                'group_list' => [
                    '1' => ['title' => '基本配置', 'icon' => 'gear', 'desc' => ''],
                    '2' => ['title' => '内容配置', 'icon' => 'tasks', 'desc' => ''],
                ],
                'group_id' => $id,
                'list' => $list
            ]);
            return view('config/config');
        }
        $data = $this->request->post();
        $info = ConfigModel::column('data', 'name');
        foreach ($data as $key => $value) {
            if (array_key_exists($key, $info)) {
                if ($value) {
                    $value = str_replace("\r\n", ',', $value);
                }
                ConfigModel::where(['name' => $key])
                    ->update([
                        'data' => $value
                    ]);
            }
        }
        cache('sys', null);
        buildConfig();
        return $this->success('保存成功');
    }

    function index()
    {
        if (!$this->request->isAjax()) {
            return view('index');
        } else {
            $limit = $this->request->post('limit');
            $offset = $this->request->post('offset');
            $page = floor($offset / $limit) + 1;

            $where = [];
            $where[] = ['name|title', 'like', $this->request->param('keywords')];
            $where[] = ['group', '=', $this->request->param('group')];

            $order = $this->request->post('order');    //排序字段 bootstrap-table 传入
            $sort = $this->request->post('sort');        //排序方式 desc 或 asc

            $order = ($sort && $order) ? $sort . ' ' . $order : 'id desc';
            $res = ConfigModel::where(formatWhere($where))
                ->order($order)
                ->paginate(['list_rows' => $limit, 'page' => $page])
                ->toArray();
            return json(['rows' => $res['data'], 'total' => $res['total']]);
        }
    }

    function update()
    {
        if (!$this->request->isPost()) {
            $id = $this->request->get('id');
            $this->assign('id', $id);
            $info = ConfigModel::find($id) ?: new ConfigModel();
            $this->assign('info', $info);
            return view('update');
        } else {
            $data = $this->request->param([
                'id' => 0,
                'name' => '',
                'type' => '',
                'title' => '',
                'group' => '',
                'extra' => '',
                'data' => '',
                'desc' => '',
                'status' => 1,
                'sort' => 50
            ]);
            $data['extra'] = str_replace("\r\n", "", $data['extra']);
            if (!$data['id']) {
                unset($data['id']);
                $res = ConfigModel::create($data);
            } else {
                $res = ConfigModel::update($data);
            }
            return $this->success('提交成功');
        }
    }

    function delete()
    {
        $idx = $this->request->post('id');
        if (!$idx) $this->error('参数错误');
        ConfigModel::destroy(['id' => explode(',', $idx)]);
        return $this->success('操作成功');
    }

    function clear()
    {
        cache('sys', null);
        buildConfig();
        $this->success('缓存清理成功');
    }
}