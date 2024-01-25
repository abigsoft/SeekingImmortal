<?php

namespace yzh52521\JwtAuth\facade;


/**
 * @see \yzh52521\JwtAuth\JwtAuth
 * @mixin \yzh52521\JwtAuth\JwtAuth
 * @method static token( $id, array $cliams ) 生成 Token
 * @method static verify( $token ) 检测Token合法性
 * @method static refresh() 刷新Token 返回新Token
 * @method static logout( $token ) 注销Token
 * @method static parseToken( $token ) 解析 Token
 * @method static getVerifyToken() 获取验证后的Token对象
 * @method static getUser() 获取登录用户对象
 * @method static getTokenExpirationTime( $token = null ) 获取Token动态有效时间
 * @method static getConfig( $store = null ) 获取 Token 配置
 * @method static removeBlackList( $token ) 移除黑名单Token
 * @method static clearBlackList() 清空所有的token缓存黑名单
 */
class JwtAuth
{
    protected static $_instance = [];

    public static function instance()
    {
        $app = \request()->app === '' ? 'default' : \request()->app;
        if ( !isset(static::$_instance[$app]) ) {
            static::$_instance[$app] = new \yzh52521\JwtAuth\JwtAuth($app);
        }
        return static::$_instance[$app];
    }


    /**
     * @param $name
     * @param $arguments
     * @return mixed
     */
    public static function __callStatic($name, $arguments)
    {
        return static::instance()->{$name}(... $arguments);
    }
}