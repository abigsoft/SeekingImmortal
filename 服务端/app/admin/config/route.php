<?php
/**
 * This file is part of webman.
 *
 * Licensed under The MIT License
 * For full copyright and license information, please see the MIT-LICENSE.txt
 * Redistributions of files must retain the above copyright notice.
 *
 * @author    walkor<walkor@workerman.net>
 * @copyright walkor<walkor@workerman.net>
 * @link      http://www.workerman.net/
 * @license   http://www.opensource.org/licenses/mit-license.php MIT License
 */

use Webman\Route;
Route::group('/admin', function () {
    Route::any('/create', function () {
        return response('create');
    });
    Route::any('/edit', function () {return response('edit');});
    Route::any('/view/{id}', function ($request, $id) {response("view $id");});
})->middleware([
    //app\common\middleware\MiddlewareA::class,
    //app\middleware\MiddlewareB::class,
]);