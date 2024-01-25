<?php

namespace app\admin\controller;


use app\admin\model\AdminAuthRuleModel;
use app\admin\model\AdminModel;
use app\common\controller\BaseController;
use think\facade\Db;
use Tinywan\Jwt\JwtToken;

class Index extends Base
{
    public function index()
    {
        $user = [
            'id'  => 'abcdefg',
            'name'  => 'test',
            'client' => JwtToken::TOKEN_CLIENT_MOBILE
        ];
        $token = JwtToken::generateToken($user);
        d($token);
        $data = AdminAuthRuleModel::order('sort asc,id desc')
            ->where('is_show',1)
            ->where('status',1)
            ->select()->toArray();
        $data = list_to_tree($data);
        if ($this->admin_info['is_admin'] != 1) {
            foreach ($data as $k => $v) {
                //检查权限是否存在

                if (!in_array($v['name'],$this->admin_rule)) {
                    unset($data[$k]);
                } else {
                    if (isset($v['_child'])) {
                        foreach ($v['_child'] as $key => $value) {
                            if (!in_array($value['name'],$this->admin_rule)) {
                                unset($data[$k]['_child'][$key]);
                            }
                        }
                    }
                }
            }
        }
        $this->assign('menus',$data);
        $this->assign('admin_info',$this->admin_info);
        return view('index/index');
    }

    //后台首页框架内容
    public function main()
    {
        //会员总数
        $version = Db::query('SELECT VERSION() AS ver');
        $config = [
            'url' => $this->request->host(),
            'server_os' => PHP_OS,
            'server_port' => $this->request->getLocalPort(),
            'server_ip' => $this->request->getLocalIp(),
            'client_port' => $this->request->getRemotePort(),
            'client_ip' => $this->request->getRemoteIp(),
            'php_version' => PHP_VERSION,
            'mysql_version' => $version[0]['ver'],
            'max_upload_size' => ini_get('upload_max_filesize')
        ];
        $this->assign('config', $config);
        return view('index/main');
    }

    function password(){
        if(!$this->request->isAjax()){
            return view('password');
        }
        $password = $this->request->post('password');
        $old_pass = $this->request->post('old_pass');

        $old_pass = buildPass($old_pass);
        if($old_pass != (AdminModel::where('id',$this->admin_id)->value('password',''))){
            return $this->error('原密码输入不正确');
        }
        $password = buildPass($password);
        if($password == $old_pass){
            return $this->error('密码没有做修改');
        }
        AdminModel::where('id',$this->admin_info->id)->update(['password'=>$password]);
        return $this->success('修改成功');
    }
}