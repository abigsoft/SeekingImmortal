<?php
/**
 * @desc 腾讯云对象存储适配器
 * @help https://cloud.tencent.com/document/product/436
 *
 * @author Tinywan(ShaoBo Wan)
 * @date 2022/3/13 19:54
 */
declare(strict_types=1);

namespace Tinywan\Storage\Adapter;

use Qcloud\Cos\Client;
use Qcloud\Cos\Exception\CosException;
use Throwable;
use Tinywan\Storage\Exception\StorageException;

class CosAdapter extends AdapterAbstract
{
    /**
     * @var null
     */
    protected $instance = null;

    /**
     * @desc: 对象存储实例
     */
    public function getInstance(): ?Client
    {
        if (is_null($this->instance)) {
            $this->instance = new Client([
                'region' => $this->config['region'],
                'schema' => 'https',
                'credentials' => [
                    'secretId' => $this->config['secretId'],
                    'secretKey' => $this->config['secretKey'],
                ],
            ]);
        }

        return $this->instance;
    }

    /**
     * @desc: 方法描述
     *
     * @author Tinywan(ShaoBo Wan)
     */
    public function uploadFile(array $options = []): array
    {
        try {
            $result = [];
            foreach ($this->files as $key => $file) {
                $uniqueId = hash_file($this->algo, $file->getPathname());
                $saveName = $uniqueId.'.'.$file->getUploadExtension();
                $object = $this->config['dirname'].$this->dirSeparator.$saveName;
                $temp = [
                    'key' => $key,
                    'origin_name' => $file->getUploadName(),
                    'save_name' => $saveName,
                    'save_path' => $object,
                    'url' => $this->config['domain'].$this->dirSeparator.$object,
                    'unique_id' => $uniqueId,
                    'size' => $file->getSize(),
                    'mime_type' => $file->getUploadMineType(),
                    'extension' => $file->getUploadExtension(),
                ];
                $this->getInstance()->putObject([
                    'Bucket' => $this->config['bucket'],
                    'Key' => $object,
                    'Body' => fopen($file->getPathname(), 'rb'),
                ]);
                array_push($result, $temp);
            }
        } catch (Throwable|CosException $exception) {
            throw new StorageException($exception->getMessage());
        }

        return $result;
    }

    /**
     * @desc: 上传服务端文件
     *
     * @author Tinywan(ShaoBo Wan)
     */
    public function uploadServerFile(string $file_path): array
    {
        $file = new \SplFileInfo($file_path);
        if (!$file->isFile()) {
            throw new StorageException('不是一个有效的文件');
        }

        $uniqueId = hash_file($this->algo, $file->getPathname());
        $object = $this->config['dirname'].$this->dirSeparator.$uniqueId.'.'.$file->getExtension();

        $result = [
            'origin_name' => $file->getRealPath(),
            'save_path' => $object,
            'url' => $this->config['domain'].$this->dirSeparator.$object,
            'unique_id' => $uniqueId,
            'size' => $file->getSize(),
            'extension' => $file->getExtension(),
        ];

        $this->getInstance()->putObject([
            'Bucket' => $this->config['bucket'],
            'Key' => $object,
            'Body' => fopen($file->getPathname(), 'rb'),
        ]);

        return $result;
    }

    /**
     * @desc: 上传Base64
     *
     * @return array
     *
     * @author Tinywan(ShaoBo Wan)
     */
    public function uploadBase64(string $base64, string $extension = 'png')
    {
        $base64 = explode(',', $base64);
        $uniqueId = date('YmdHis').uniqid();
        $object = $this->config['dirname'].$this->dirSeparator.$uniqueId.'.'.$extension;

        $this->getInstance()->putObject([
            'Bucket' => $this->config['bucket'],
            'Key' => $object,
            'Body' => base64_decode($base64[1]),
        ]);

        $imgLen = strlen($base64['1']);
        $fileSize = $imgLen - ($imgLen / 8) * 2;

        return [
            'save_path' => $object,
            'url' => $this->config['domain'].$this->dirSeparator.$object,
            'unique_id' => $uniqueId,
            'size' => $fileSize,
            'extension' => $extension,
        ];
    }
}
