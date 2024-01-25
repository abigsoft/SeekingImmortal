<?php

namespace app\queue\redis;

use GatewayWorker\Lib\Gateway;
use Webman\Event\Event;
use Webman\RedisQueue\Consumer;

class WordMessage implements Consumer
{
    // 要消费的队列名
    public string $queue = 'word-message';
    // 消费
    public function consume($data): void
    {
        try {
            if(is_string($data)){
                Gateway::sendToAll($data);
            }else{
                if(isset($data['uid']) && isset($data['data']) && isset($data['group'])){
                    if($data['uid'] == 'all'){
                        Gateway::sendToAll(json_encode($data['data']));
                    }elseif(!$data['group']){
                        Gateway::sendToUid($data['uid'],json_encode($data['data']));
                    }else{
                        Gateway::sendToGroup($data['uid'],json_encode($data['data']));
                    }
                }
            }
        } catch (\Exception $e) {
            Event::emit('throw.chat',$e);
        }
    }
}