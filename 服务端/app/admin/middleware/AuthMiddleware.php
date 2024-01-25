<?php

namespace app\admin\middleware;
use app\admin\model\AdminAuthGroupAccessModel;
use app\admin\model\AdminAuthGroupModel;
use app\admin\model\AdminAuthRuleModel;
use app\admin\model\AdminModel;
use ReflectionClass;
use Webman\MiddlewareInterface;
use Webman\Http\Response;
use Webman\Http\Request;

class AuthMiddleware implements MiddlewareInterface
{
    public function process(Request $request, callable $handler) : Response
    {
        // 通过反射获取控制器哪些方法不需要登录
        $controller = new ReflectionClass($request->controller);

        $noNeedLogin = $controller->getDefaultProperties()['noNeedLogin'] ?? [];

        $admin = session('admin');
        $admin_id = session('admin_sign') == data_auth_sign($admin) ? session('admin_id') : 0;

        if( !$admin_id && !in_array(strtolower($request->getController()),['login','callback','upload','common'])){
            return redirect('/admin/login/index');
        }
        if(!in_array($request->action, $noNeedLogin)){
            $admin_info = AdminModel::where('id', $admin_id)->find();
            $url =  $request->path();

            if ($admin_info['is_admin'] != 1) {
                if(!in_array($url,getAdminAuth($admin_id))){
                    return redirect('/404.html');
                }
            }
        }
        // 不需要登录，请求继续向洋葱芯穿越
        return $handler($request);
    }
}