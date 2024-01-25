<?php
return [
    'successCode'       =>      200,
    'errorCode'         =>      201,
    'password_secret'	=> getenv('PASS_KEY'),			//密码加密秘钥

    'jwtExpireCode'			=> 888,					//jwt过期
    'jwtErrorCode'			=> 887,					//jwt无效

    'steam_api' => [
        'appid' => '',
        'secret' => '',
        'domain'=>''
    ]
];