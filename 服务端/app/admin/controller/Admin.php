<?php

namespace app\admin\controller;

use app\admin\model\AdminAuthGroupAccessModel;
use app\admin\model\AdminAuthGroupModel;
use app\admin\model\AdminModel;

class Admin extends Base
{
    /*首页数据列表*/
    function index()
    {
        if (!$this->request->isAjax()) {
            $this->assign('role_list', AdminAuthGroupModel::select());
            return view('admin/index');
        } else {
            $limit = $this->request->post('limit');
            $offset = $this->request->post('offset');
            $page = floor($offset / $limit) + 1;

            $where = [];

            $where[] = ['username|fullname', 'like', $this->request->param('keywords', '')];
            $where[] = ['status', '=', $this->request->param('status')];
            if ($this->admin_info['is_admin'] == 0) {
                $where['is_admin'] = ['=', 0];
            }
            $order = $this->request->post('order');    //排序字段 bootstrap-table 传入
            $sort = $this->request->post('sort');        //排序方式 desc 或 asc

            $order = ($sort && $order) ? $sort . ' ' . $order : 'id desc';

            $res = AdminModel::where(formatWhere($where))
                ->where('id', '>', 1)
                ->order($order)
                ->paginate(['list_rows' => $limit, 'page' => $page])
                ->toArray();
            return json(['rows' => $res['data'], 'total' => $res['total']]);
        }
    }

    /*修改排序开关按钮操作*/
    function status()
    {
        $postField = 'id,status';
        $data = $this->request->only(explode(',', $postField), 'param', null);
        if (!$data['id'])
            return $this->error('参数错误');
        AdminModel::update($data);
        return $this->success('操作成功');
    }

    /*修改*/
    function update()
    {
        if (!$this->request->isPost()) {
            $id = $this->request->get('id');
            $this->assign('id', $id);
            $info = AdminModel::find($id) ?: new AdminModel();
            $info['role_id'] = AdminAuthGroupAccessModel::where('uid', $info['id'])->value('group_id', 0);
            $this->assign('role_list', AdminAuthGroupModel::select());
            $this->assign('info', $info);
            return view('admin/update');
        } else {
            $data = $this->request->param([
                'id' => 0,
                'username' => '',
                'fullname' => '',
                'status' => 1,
                'password' => '',
                'is_admin' => 0
            ]);
            $role_id = $this->request->param('role_id');
            if ($data['id']) {//编辑
                if ($this->admin_info['is_admin'] == 0) {
                    unset($data['is_admin']);
                }
                unset($data['password']);
                AdminModel::where('id', $data['id'])->update($data);
            } else {
                if ($this->admin_info['is_admin'] == 0) {
                    $data['is_admin'] = 0;
                }
                unset($data['id']);
                $data['password'] = buildPass($data['password']);
                $res = AdminModel::create($data);
                $data['id'] = $res->id;
            }
            $id = $data['id'];
            AdminAuthGroupAccessModel::destroy(['uid'=>$id],true);
            if($role_id){
                AdminAuthGroupAccessModel::create([
                    'uid' => $id,
                    'group_id' => $role_id
                ]);
            }

            return $this->success('提交成功');
        }
    }

    /*删除*/
    function delete()
    {
        $idx = $this->request->post('id');
        if (!$idx) return $this->error('参数错误');
        AdminAuthGroupAccessModel::where('uid', 'in', $idx)->delete();
        AdminModel::destroy(['id' => explode(',', $idx)]);
        return $this->success('操作成功');
    }

    function password()
    {
        if (!$this->request->isPost()) {
            $id = $this->request->param('id', '');
            $this->assign('id', $id);
            return view('admin/password');
        } else {
            $postField = 'id,password';
            $data = $this->request->only(explode(',', $postField), 'param', null);
            if (empty($data['id'])) return $this->error('参数错误');
            AdminModel::where('id', $data['id'])
                ->update([
                    'password' => buildPass($data['password']),
                ]);
            return $this->success('操作成功');
        }
    }
}