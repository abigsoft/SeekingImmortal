<?php

namespace plugin\webman\gateway;

use app\common\service\MessageService;
use GatewayWorker\Lib\Gateway;
use Webman\RedisQueue\Client;

class Events
{
    public static function onWorkerStart($worker)
    {
        MessageService::World([
            'type' => 'system',
            'data' => [
                'type' => 'notice',
                'data' => '服务已启动'
            ],
        ]);
    }

    public static function onConnect($client_id)
    {

    }

    public static function onWebSocketConnect($client_id, $data)
    {
        if (isset($data['get']['token'])) {
            try {
                $uid = \Tinywan\Jwt\JwtToken::verify(1,$data['get']['token'])['extend']['id'];
                Gateway::bindUid($client_id,$uid);
                MessageService::Uid([
                    'type' => 'system',
                    'data' => [
                        'type' => 'notice',
                        'data' => '服务连接成功'
                    ],
                ],$uid);
            }catch (\Exception|\Error $e){
                Gateway::closeClient($client_id);
            }

        }else{
            Gateway::closeClient($client_id);
        }
    }

    public static function onMessage($client_id, $message)
    {
        Gateway::sendToClient($client_id, "receive message $message");
    }

    public static function onClose($client_id)
    {
        MessageService::World([
            'type' => 'statistics',
            'data' => [
                'online' => Gateway::getAllUidCount(),
            ]
        ]);
    }

}
