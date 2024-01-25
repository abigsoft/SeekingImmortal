<?php

namespace app\common\exception;

use Exception;
use Throwable;
use Webman\Http\Request;
use Webman\Http\Response;
use function json_encode;
class BaseException extends Exception
{
    public $code = 0;
    public $message = '网络异常';
    public $data = null;

    public function __construct($message = "", $code = 0, $data = [])
    {
        parent::__construct($message, $code, null);
        $this->code = $code;
        $this->message = $message;
        $this->data = $data;
    }

    public function render(Request $request): ?Response
    {
        $json = ['status' => $this->code ?: 500, 'msg' => $this->message, 'data' => $this->data];
        return new Response(200, ['Content-Type' => 'application/json'],
            json_encode($json, JSON_UNESCAPED_UNICODE | JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES));
    }
}