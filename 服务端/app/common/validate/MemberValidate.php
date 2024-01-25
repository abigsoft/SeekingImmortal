<?php

namespace app\common\validate;

use taoser\Validate;

class MemberValidate extends Validate
{
    protected $rule = [
        'account'=>['require','unique:member,account','max:20','min:6'],
        'password'=>['require','alphaDash','max:20','min:6'],
        'nickname'=>['require','chsDash','unique:member,nickname','max:7','min:1'],
        'sex' => ['require','in:1,2'],
    ];

    protected $message = [
        'account.require'=>'登录账号不能为空',
        'account.unique'=>'登录账号已存在',
        'account.max'=>'登录账号不能超过20个字符',
        'account.min'=>'登录账号不能少于6个字符',
        'password.require'=>'登录密码不能为空',
        'password.max'=>'登录密码不能超过20个字符',
        'password.min'=>'登录密码不能少于6个字符',
        'password.alphaDash'=>'登录密码只能为字母和数字，下划线及破折号',
        'nickname.require'=>'角色名不能为空',
        'nickname.chsDash'=>'角色名只能为汉字、字母、数字和下划线_及破折号-',
        'nickname.max'=>'角色名不能超过7个字符',
        'nickname.min'=>'角色名不能少于1个字符',
        'nickname.unique'=>'角色名已存在',
        'sex.require'=>'请选择性别',
        'sex.in'=>'请选择性别',
    ];

    protected $scene  = [
        'reset_pass'=>['password'],
        'register'=>['account','password','nickname','sex'],
        'update' => ['nickname']
    ];
}