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
}