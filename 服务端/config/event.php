<?php

return [
    'throw.auth' => [
        [app\common\event\ThrowEvent::class, 'auth'],
    ],
    'throw.chat' => [
        [app\common\event\ThrowEvent::class, 'chat'],
    ],
    'refresh.member' => [
        [app\common\event\Refresh::class, 'member'],
    ],
];
