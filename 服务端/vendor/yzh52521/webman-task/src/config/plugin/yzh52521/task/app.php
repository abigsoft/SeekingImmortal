<?php
return [
    'enable' => true,
    'task'   => [
        'listen'            => '0.0.0.0:2345',
        'async_listen'      => '0.0.0.0:2346',
        'crontab_table'     => 'th_system_crontab', //任务计划表
        'crontab_table_log' => 'th_system_crontab_log',//任务计划流水表
        'debug'             => true, //控制台输出日志
        'write_log'         => true,// 任务计划日志
        'runInBackground'   => false //命令行任务是否后台运行
    ],
];
