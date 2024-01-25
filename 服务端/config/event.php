<?php

return [
    'throw.auth' => [
        [app\common\event\ThrowEvent::class, 'auth'],
    ],
    'throw.chat' => [
        [app\common\event\ThrowEvent::class, 'chat'],
    ],
];
