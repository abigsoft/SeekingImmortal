<?php

namespace app\api\controller;

use app\common\controller\BaseController;
use app\common\exception\AuthException;
use app\common\model\MemberModel;
use support\Request;

class Base extends BaseController
{
    protected string $uid = "0";
    protected array $user = ['uid'=>0,'name'=>''];
    function beforeAction(Request $request)
    {
        parent::beforeAction($request); // TODO: Change the autogenerated stub
        $uid = \Tinywan\Jwt\JwtToken::getCurrentId();
        if(!$uid){
            throw new AuthException();
        }
        $this->uid = $uid;
        $this->user = \Tinywan\Jwt\JwtToken::getUser();
    }



}