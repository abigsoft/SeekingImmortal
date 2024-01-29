<?php

namespace app\common\service;

use app\common\model\WorldChatModel;
use Webman\RedisQueue\Client;

class MessageService
{
    public static function World($data): void
    {
        Client::send('word-message', ['data' => $data, 'uid' => 'all', 'group' => false]);
    }

    public static function Uid($data, $uid = 'all'): void
    {
        Client::send('word-message', ['data' => $data, 'uid' => $uid, 'group' => false]);
    }

    public static function Group($data, $uid = 'all'): void
    {
        Client::send('word-message', ['data' => $data, 'uid' => $uid, 'group' => true]);
    }

    public static function Create($data,$channel = 'world'):int
    {
        $data['channel'] = $channel;
        Client::send('word-chat-data', $data);
        $res = WorldChatModel::create([
            'channel' => $data['channel'] ?? 'world',
            'member_uid' => $data['uid'] ?? '',
            'member_name' => $data['name'] ?? '',
            'message_type' => $data['type'] ?? '',
            'message_data' => $data['data'] ?? '',
        ]);
        return intval($res->id);
    }

    public static function system($message, $color = '#FF0000', $to = '', $name = '系统', $notice = 0){
        $data = [
            "type" => "world",
            "data" => [
                "channel" => "world",//world世界,person个人,group群组，cancel撤销消息
                "data" => [
                    "id" => 0,//0为世界，群组为对应群组的ID
                    "name" => "世界",
                    "notice" => $notice,//是否提醒
                    "message" => [
                        "id" => 0,
                        "from" => [
                            "uid" => 'administrator',//用户ID
                            "title" => '管理员',//称号
                            "name" => $name//昵称
                        ],
                        "color" => [//颜色
                            "title" => $color,
                            "name" => $color,
                            "message" => $color,
                            "time" => $color,
                        ],
                        "event" => "",//事件标签
                        "content" => [
                            "type" => 'text',
                            "data" => $message
                        ],
                        "time" => date('H:i:s')
                    ]
                ]
            ]
        ];
        self::Uid($data,$to);

    }
}