<?php

namespace app\admin\controller;

use app\common\model\TagsModel;
use app\exception\ParamException;
use think\exception\ValidateException;

class Tags extends Base
{
    function index(){
        if (!$this->request->isAjax()){
            return view('tags/index');
        }else{
            $limit  = $this->request->post('limit');
            $offset = $this->request->post('offset');
            $page   = floor($offset / $limit) +1 ;

            $where = [];
            $where[] = ['title|content','like',$this->request->param('keywords')];

            $order  = $this->request->post('order');	//排序字段 bootstrap-table 传入
            $sort  = $this->request->post('sort');		//排序方式 desc 或 asc

            $order = ($sort && $order) ? $sort.' '.$order : 'id desc';
            $res = TagsModel::where(formatWhere($where))
                ->order($order)
                ->paginate(['list_rows'=>$limit,'page'=>$page])
                ->toArray();
            return json(['rows'=>$res['data'],'total'=>$res['total']]);
        }
    }

    function update(){
        if (!$this->request->isPost()){
            $id = $this->request->get('id');
            $this->assign('id',$id);
            $info = TagsModel::find($id) ? : new TagsModel();
            $this->assign('info',$info);
            return view('tags/update');
        }else{
            $postField = 'id,head_img,area,key,keywords,title,content,sort,status';
            $data = $this->request->param(explode(',',$postField));
            try{
                $data['create_time'] = formatDate();
                if(!$data['id']){
                    $res = TagsModel::create($data);
                    $id = $res->id;
                    if(!$data['sort']){
                        TagsModel::update(['sort' => $id],['id' => $id]);
                    }
                }else{
                    $res = TagsModel::update($data);
                }
            }catch(ValidateException $e){
                throw new ValidateException ($e->getError());
            }catch(\Exception $e){
                throw new ValidateException($e->getMessage());
            }
            if(!$res){
                throw new ValidateException ('操作失败');
            }
            return $this->success('提交成功');
        }
    }

    /*删除*/
    function delete(){
        $idx =  $this->request->post('id');
        if(!$idx) return $this->error('参数错误');
        TagsModel::destroy(['id'=>explode(',',$idx)]);
        return $this->success();
    }

    function status(){
        $postField = 'id,status';
        $data = $this->request->only(explode(',', $postField), 'param', null);
        if (!$data['id'])
            return $this->error('参数错误');
        TagsModel::update($data);
        return $this->success('操作成功');
    }

    function arrow(){
        $postField = 'id,sort,type';
        $data = $this->request->only(explode(',',$postField),'post',null);
        if(empty($data['sort'])){
            return $this->error('操作失败，当前数据没有排序号');
        }
        if($data['type'] == 1){//上
            $info = TagsModel::where('sort','<',$data['sort'])->order('sort desc')->find();
        }else{
            $info = TagsModel::where('sort','>',$data['sort'])->order('sort desc')->find();
        }
        if(empty($info['sort'])){
            return $this->error('操作失败，目标位置没有排序号');
        }
        if($info){
            try{
                TagsModel::where('id',$data['id'])->update(['sort'=>$info['sort']]);
                TagsModel::where('id',$info['id'])->update(['sort'=>$data['sort']]);
            }catch(\Exception $e){
                throw new \think\exception\ValidateException ($e->getMessage());
            }
        }else{
            return $this->error('目标位置没有数据');
        }
        return $this->success('操作成功');
    }
}