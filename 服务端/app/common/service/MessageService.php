<?php

namespace app\common\service;

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
}