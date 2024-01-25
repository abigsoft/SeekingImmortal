<?php

namespace app\common\controller;

use support\Request;
use support\Cache;
use support\View;

class BaseController
{
    protected $request;
    protected $config;
    protected int $successCode;
    protected int $errorCode;

    public function __construct()
    {
        // 控制器初始化
        $this->initialize();
    }

    public function beforeAction(Request $request){
        $this->request = $request;
        $app = $this->request->app;
        $controller = $this->request->controller;

        $action = $this->request->action;

        $config = Cache::get('sys');
        $this->config = $config;

        View::assign(['config' => $config]);

    }

    // 初始化
    protected function initialize(): void
    {

        $this->successCode = config('my.successCode');
        $this->errorCode = config('my.errorCode');

        buildConfig();
        buildDict();
    }

    protected function success($message = '操作成功',$data = []): \support\Response
    {
        return json([
            'status'=>config('my.successCode'),
            'msg'=> $message,
            'data' => $data
        ]);
    }

    protected function error($message = '操作失败',$data = []): \support\Response
    {
        return json([
            'status'=>config('my.errorCode'),
            'msg'=> $message,
            'data' => $data
        ]);
    }

    protected function assign(...$vars)
    {
        View::assign(...$vars);
    }
}