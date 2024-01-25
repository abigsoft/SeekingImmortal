<?php

namespace app\admin\controller;

use app\admin\service\BuildService;
use app\common\model\ModuleParamModel;
use app\common\model\QuestionModel;
use app\common\model\QuestionOptionModel;
use app\common\model\RegionModel;

class Common extends Base
{
    function area()
    {
        $pcode = input('param.pcode', 0);
        $data = RegionModel::where('parent_code', $pcode)
            ->column('region_code code,region_name name');
        return $this->suc('SUCCESS', $data);
    }

    function ajax_question_option(){
        $question_id = $this->request->param('id',0);
        $option_list = QuestionOptionModel::where('question_id',$question_id)
            ->where('status',1)
            ->order('sort asc')
            ->column('id,title,option');
        return $this->suc('SUCCESS',$option_list);
    }

    function ajax_format_code(): \think\response\Json
    {
        $module_id = $this->request->param('module_id',0);
        $value = $this->request->param('data','');
        $is_view = $this->request->param('is_view',0);
        $default_param = QuestionModel::where('module_id',$module_id)
            ->order('sort asc')
            ->column("id,title name,title,'default' type");
        $old_param = ModuleParamModel::where('module_id',$module_id)
            ->order('sort asc')
            ->column("id,name,title,'old' type");
        $data = BuildService::formatCode(array_merge($default_param,$old_param),$value,$is_view);
        return $this->suc('SUCCESS',$data);
    }
}