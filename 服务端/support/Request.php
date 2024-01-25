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

namespace support;

/**
 * Class Request
 * @package support
 */
class Request extends \Webman\Http\Request
{
    public function isPost(): bool
    {
        return $this->method() == 'POST';
    }

    public function isGet(): bool
    {
        return $this->method() == 'GET';
    }

    public function getController(): array|string|null
    {
        return strtolower(str_replace("app\\" . ($this->app) . "\controller\\", "", $this->controller));
    }

    public function param($data = [],$default = ''):array|int|string|null
    {
        if(is_string($data)){
            return $this->input($data,$default);
        }
        $param = [];
        if(!empty($data) && is_array($data)){
            foreach ($data as $k=>$v){
                if(is_int($k)){//代表仅取值
                    $param[$v] = $this->input($v);
                }elseif(is_string($k)){
                    $param[$k] = $this->input($k,$v);
                }
            }
            return $param;
        }
        return $this->all();
    }
}