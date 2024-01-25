<?php

namespace app\admin\controller;
use Abigsoft\LikeWebmanTp\facade\Url;
use app\admin\model\AdminModel;
use app\common\controller\BaseController;
use app\common\exception\ParamException;
use support\Request;
use think\exception\ValidateException;
use think\facade\Db;
use Webman\Captcha\CaptchaBuilder;
use Webman\Captcha\PhraseBuilder;
use Webman\Route;

class Login extends BaseController
{
    protected array $noNeedLogin = ['index','verify','logout'];
    //用户登录
    public function index()
    {
        if (!$this->request->isPost()) {
            return view('login/index');
        } else {
            $data = $this->request->param([
                'account' => '',
                'password' => '',
                'verify' => '',
            ]);
            if(session('captcha','') != $data['verify']){
                throw new ValidateException('验证码错误');
            }
            $hasUser = AdminModel::where('username',$data['account'])->find();
            if(empty($hasUser)){
                throw new ValidateException("请检查用户名或者密码");
            }
            $hasUser = $hasUser->toArray();
            if(buildPass($data['password']) != $hasUser['password']){
                throw new ParamException("请检查用户名或者密码");
            }

            if(1 != $hasUser['status']){
                throw new ParamException("该账号被禁用");
            }

            session('admin_id',$hasUser['id']);
            session('admin', $hasUser);
            session('admin_sign', data_auth_sign($hasUser));
            session('admin_auth', getAdminAuth($hasUser['id']));

            AdminModel::where('id', $hasUser['id'])
                ->update([
                    'login_times'=>Db::raw('login_times + 1'),
                    'last_login_ip'=>$this->request->getRemoteIp(),
                    'last_login_time'=>formatDate(),
                ]);
            return $this->success('登录成功', url('index/index'));
        }
    }

    //验证码
    public function verify()
    {
        $captcha = new PhraseBuilder(4, '0123456789');
        $builder = new CaptchaBuilder(null, $captcha);
        $builder->build(128,38);
        session('captcha',$builder->getPhrase());
        $img_content = $builder->get();
        return response($img_content, 200, ['Content-Type' => 'image/jpeg']);
    }

    //退出
    public function logout()
    {
        session('admin_id', null);
        session('admin', null);
        session('admin_sign', null);
        session('admin_auth',null);
        return redirect(url('login/index'));
    }
}