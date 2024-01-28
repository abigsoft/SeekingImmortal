<?php

namespace app\queue\redis;
use app\common\model\WorldChatBackModel;
use Webman\Event\Event;
use Webman\RedisQueue\Consumer;

class ChatDatabase implements Consumer
{
    // 要消费的队列名
    public string $queue = 'word-chat-data';
    // 消费
    public function consume($data): void
    {
        try {
            WorldChatBackModel::create([
                'channel' => $data['channel'] ?? 'world',
                'member_uid' => $data['uid'] ?? '',
                'message_type' => $data['type'] ?? '',
                'message_data' => $data['data'] ?? '',
            ]);
        } catch (\Exception $e) {
            Event::emit('throw.chat',$e);
        }
    }
}