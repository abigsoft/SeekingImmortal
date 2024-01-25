<?php

namespace app\api\middleware;
use app\common\exception\AuthException;
use ReflectionClass;
use Webman\Http\Request;
use Webman\Http\Response;
use Webman\MiddlewareInterface;

class JwtMiddleware implements MiddlewareInterface
{
    public function process(Request $request, callable $handler) : Response
    {
        // 访问的方法需要登录
        if (!in_array($request->getController(), ['login','version','register'])) {
            $uid = \Tinywan\Jwt\JwtToken::getCurrentId();
            if(!$uid){
                throw new AuthException();
            }
        }
        // 不需要登录，请求继续向洋葱芯穿越
        return $handler($request);
    }
}