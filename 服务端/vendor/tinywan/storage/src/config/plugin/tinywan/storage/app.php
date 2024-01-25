<?php
/**
 * @desc app.php 描述信息
 *
 * @author Tinywan(ShaoBo Wan)
 * @date 2022/3/10 19:46
 */

return [
    'enable' => true,
    'storage' => [
        'default' => 'local', // local：本地 oss：阿里云 cos：腾讯云 qos：七牛云
        'single_limit' => 1024 * 1024 * 200, // 单个文件的大小限制，默认200M 1024 * 1024 * 200
        'total_limit' => 1024 * 1024 * 200, // 所有文件的大小限制，默认200M 1024 * 1024 * 200
        'nums' => 10, // 文件数量限制，默认10
        'include' => [], // 被允许的文件类型列表
        'exclude' => [], // 不被允许的文件类型列表
        // 本地对象存储
        'local' => [
            'adapter' => \Tinywan\Storage\Adapter\LocalAdapter::class,
            'root' => runtime_path().'/storage',
            'dirname' => function () {
                return date('Ymd');
            },
            'domain' => 'http://127.0.0.1:8787',
            'uri' => '/runtime', // 如果 domain + uri 不在 public 目录下，请做好软链接，否则生成的url无法访问
            'algo' => 'sha1',
        ],
        // 阿里云对象存储
        'oss' => [
            'adapter' => \Tinywan\Storage\Adapter\OssAdapter::class,
            'accessKeyId' => 'xxxxxxxxxxxx',
            'accessKeySecret' => 'xxxxxxxxxxxx',
            'bucket' => 'resty-webman',
            'dirname' => function () {
                return 'storage';
            },
            'domain' => 'http://webman.oss.tinywan.com',
            'endpoint' => 'oss-cn-hangzhou.aliyuncs.com',
            'algo' => 'sha1',
        ],
        // 腾讯云对象存储
        'cos' => [
            'adapter' => \Tinywan\Storage\Adapter\CosAdapter::class,
            'secretId' => 'xxxxxxxxxxxxx',
            'secretKey' => 'xxxxxxxxxxxx',
            'bucket' => 'resty-webman-xxxxxxxxx',
            'dirname' => 'storage',
            'domain' => 'http://webman.oss.tinywan.com',
            'region' => 'ap-shanghai',
        ],
        // 七牛云对象存储
        'qiniu' => [
            'adapter' => \Tinywan\Storage\Adapter\QiniuAdapter::class,
            'accessKey' => 'xxxxxxxxxxxxx',
            'secretKey' => 'xxxxxxxxxxxxx',
            'bucket' => 'resty-webman',
            'dirname' => 'storage',
            'domain' => 'http://webman.oss.tinywan.com',
        ],
    ],
];
