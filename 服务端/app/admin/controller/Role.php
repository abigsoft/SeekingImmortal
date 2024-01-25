<?php

namespace app\admin\controller;

use app\admin\model\AdminAuthGroupAccessModel;
use app\admin\model\AdminAuthGroupModel;
use app\admin\model\AdminAuthRuleModel;

class Role extends Base
{
    /*首页数据列表*/
    function index(){
        if (!$this->request->isAjax()){
            return view('role/index');
        }else{
            $limit  = $this->request->post('limit');
            $offset = $this->request->post('offset');
            $page   = floor($offset / $limit) +1 ;

            $where = [];
            $where[] = ['title','like',$this->request->param('keywords')];

            $order  = $this->request->post('order');	//排序字段 bootstrap-table 传入
            $sort  = $this->request->post('sort');		//排序方式 desc 或 asc

            $order = ($sort && $order) ? $sort.' '.$order : 'id desc';

            $res = AdminAuthGroupModel::where(formatWhere($where))
                ->order($order)
                ->paginate(['list_rows'=>$limit,'page'=>$page])
                ->toArray();
            return json(['rows'=>$res['data'],'total'=>$res['total']]);
        }
    }

    /*修改*/
    function update(){
        if (!$this->request->isPost()){
            $id = $this->request->param('id');
            $this->assign('id',$id);
            $info = AdminAuthGroupModel::find($id) ? : new AdminAuthGroupModel();
            $this->assign('info',$info);
            return view('role/update');
        }else{
            $data = $this->request->param([
                'id'=>0,
                'title'=>''
            ]);
            if(empty($data['id'])){
                $data['rules'] = '';
                unset($data['id']);
                AdminAuthGroupModel::create($data);
            }else{
                AdminAuthGroupModel::update($data);
            }
            return $this->success('保存成功');
        }
    }

    /*删除*/
    function delete(){
        $idx =  $this->request->post('id');
        if(!$idx) return $this->error('参数错误');
        AdminAuthGroupAccessModel::where('group_id','in',$idx)->delete();
        AdminAuthGroupModel::destroy(['id'=>explode(',',$idx)]);
        return $this->success('操作成功');
    }

    public function auth(){
        if (!$this->request->isAjax()){
            $id = $this->request->get('id','','intval');
            $info = AdminAuthGroupModel::find($id);
            $this->assign('id',$id);
            $nodes = $this->getNodes(0,$info);
            $this->assign('nodes',json_encode($nodes));
            return view('role/auth');
        }else{
            $id = $this->request->post('id','','intval');
            $idx = $this->request->param('idx',[]);
            $idx = array_unique($idx);
            AdminAuthGroupModel::where('id',$id)->update(['rules'=>implode(',',$idx)]);
            return $this->success('设置成功');
        }
    }

    public function getNodes($pid,$info){
        $list = AdminAuthRuleModel::where(['status'=>1,'pid'=>$pid])->order('sort asc')->select()->toArray();
        if($list){
            foreach($list as $key=>$val){
                $selectStatus = false;
                if(in_array($val['id'],explode(',',$info['rules']))){
                    $selectStatus = true;
                }
                $menus[$key]['text'] = $val['title'].' '.$val['name'];
                $menus[$key]['state'] = ['opened'=>true,'selected'=>$selectStatus];
                $menus[$key]['a_attr'] = ['data-id'=>$val['id']];
                $sublist = AdminAuthRuleModel::where(['status'=>1,'pid'=>$val['id']])->order('sort asc')->select()->toArray();
                if($sublist){
                    $menus[$key]['children'] = $this->getNodes($val['id'],$info);
                }
            }
        }
        return array_values($menus);
    }
}