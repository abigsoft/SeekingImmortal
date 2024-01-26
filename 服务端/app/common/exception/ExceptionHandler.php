<?php

namespace app\common\exception;
use app\common\model\LogExceptionModel;
use Next\VarDumper\Dumper;
use Next\VarDumper\DumperHandler;
use Webman\Http\Request;
use Webman\Http\Response;
use Throwable;

class ExceptionHandler extends \Webman\Exception\ExceptionHandler
{
    use DumperHandler;
    public $dontReport = [
        BaseException::class,
    ];

    public function report(Throwable $exception)
    {
        parent::report($exception);
    }

    public function render(Request $request, Throwable $exception): Response
    {
        if(!env('DEBUG')){
            LogExceptionModel::create([
                'uid' => $request->uid ?? '',
                'type' => substr($exception->getTraceAsString(),0,50),
                'file' => $exception->getFile(),
                'line' => $exception->getLine(),
                'message' => $exception->getMessage(),
                'code' => $exception->getCode(),
            ]);
        }
        if (($exception instanceof BaseException) && ($response = $exception->render($request))) {
            return $response;
        }

        if ($exception instanceof Dumper) {
            return \response(self::convertToHtml($exception));
        }

        return parent::render($request, $exception);
    }
}