<?php
declare (strict_types = 1);

namespace Abigsoft\LikeWebmanTp\url;
use Webman\Route;
class Url
{

    protected $request;


    /**
     * 路由对象
     * @var Route
     */
    protected $route;

    /**
     * URL变量
     * @var array
     */
    protected $vars = [];

    /**
     * 路由URL
     * @var string
     */
    protected $url;

    /**
     * URL 根地址
     * @var string
     */
    protected $root = '';

    /**
     * HTTPS
     * @var bool
     */
    protected $https;

    /**
     * URL后缀
     * @var string|bool
     */
    protected $suffix = false;

    /**
     * URL域名
     * @var string|bool
     */
    protected $domain = false;

    /**
     * 架构函数
     * @access public
     * @param  string $url URL地址
     * @param  array  $vars 参数
     */
    public function __construct()
    {
        $this->request = request();
    }

    public function url(string $url = '')
    {
        $this->url = $url;
        return $this;
    }

    /**
     * 设置URL参数
     * @access public
     * @param  array $vars URL参数
     * @return $this
     */
    public function vars(array $vars = [])
    {
        $this->vars = $vars;
        return $this;
    }

    /**
     * 设置URL后缀
     * @access public
     * @param  string|bool $suffix URL后缀
     * @return $this
     */
    public function suffix($suffix)
    {
        $this->suffix = $suffix;
        return $this;
    }

    /**
     * 设置URL域名（或者子域名）
     * @access public
     * @param  string|bool $domain URL域名
     * @return $this
     */
    public function domain($domain)
    {
        $this->domain = $domain;
        return $this;
    }

    /**
     * 设置URL 根地址
     * @access public
     * @param  string $root URL root
     * @return $this
     */
    public function root(string $root)
    {
        $this->root = $root;
        return $this;
    }

    /**
     * 设置是否使用HTTPS
     * @access public
     * @param  bool $https
     * @return $this
     */
    public function https(bool $https = true)
    {
        $this->https = $https;
        return $this;
    }

    /**
     * 检测域名
     * @access protected
     * @param  string      $url URL
     * @param  string|true $domain 域名
     * @return string
     */
    protected function parseDomain(string &$url, $domain): string
    {
        if (!$domain) {
            return '';
        }

        $request    = $this->request;
        $rootDomain = $request->host();

        if (false !== strpos($domain, '://')) {
            $scheme = '';
        } else {
            $scheme = $this->https || ($request->header('x-forwarded-proto','http')) . '://';
        }

        return $scheme . $domain;
    }

    /**
     * 解析URL后缀
     * @access protected
     * @param  string|bool $suffix 后缀
     * @return string
     */
    protected function parseSuffix($suffix): string
    {
        if ($suffix) {
            $suffix = true === $suffix ? 'html' : $suffix;

            if (is_string($suffix) && $pos = strpos($suffix, '|')) {
                $suffix = substr($suffix, 0, $pos);
            }
        }

        return (empty($suffix) || 0 === strpos($suffix, '.')) ? (string) $suffix : '.' . $suffix;
    }

    /**
     * 直接解析URL地址
     * @access protected
     * @param  string      $url URL
     * @param  string|bool $domain Domain
     * @return string
     */
    protected function parseUrl(string $url, &$domain): string
    {
        $request = $this->request;

        if (0 === strpos($url, '/')) {
            // 直接作为路由地址解析
            $url = substr($url, 1);
        } elseif (false !== strpos($url, '\\')) {
            // 解析到类
            $url = ltrim(str_replace('\\', '/', $url), '/');
        } elseif (0 === strpos($url, '@')) {
            // 解析到控制器
            $url = substr($url, 1);
        } elseif ('' === $url) {
            $url = $request->getController() . '/' . $request->action;
        } else {
            $controller = $request->getController();

            $path       = explode('/', $url);
            $action     = array_pop($path);
            $controller = empty($path) ? $controller : array_pop($path);

            $url = $controller . '/' . $action;
        }

        return $url;
    }

    /**
     * 生成URL地址
     * @access public
     * @return string
     */
    public function build(): string
    {
        // 解析URL
        $url     = $this->url;
        $suffix  = $this->suffix;
        $domain  = $this->domain;
        $request = $this->request;
        $vars    = $this->vars;

        if (0 === strpos($url, '[') && $pos = strpos($url, ']')) {
            // [name] 表示使用路由命名标识生成URL
            $name = substr($url, 1, $pos - 1);
            $url  = 'name' . substr($url, $pos + 1);
        }

        if (false === strpos($url, '://') && 0 !== strpos($url, '/')) {
            $info = parse_url($url);
            $url  = !empty($info['path']) ? $info['path'] : '';

            if (isset($info['fragment'])) {
                // 解析锚点
                $anchor = $info['fragment'];

                if (false !== strpos($anchor, '?')) {
                    // 解析参数
                    [$anchor, $info['query']] = explode('?', $anchor, 2);
                }

                if (false !== strpos($anchor, '@')) {
                    // 解析域名
                    [$anchor, $domain] = explode('@', $anchor, 2);
                }
            } elseif (strpos($url, '@') && false === strpos($url, '\\')) {
                // 解析域名
                [$url, $domain] = explode('@', $url, 2);
            }
        }

        if ($url) {
            $checkName   = isset($name) ? $name : $url . (isset($info['query']) ? '?' . $info['query'] : '');
            $checkDomain = $domain && is_string($domain) ? $domain : null;
        }

        // 路由标识不存在 直接解析
        $url = $this->parseUrl($url, $domain);

        if (isset($info['query'])) {
            // 解析地址里面参数 合并到vars
            parse_str($info['query'], $params);
            $vars = array_merge($params, $vars);
        }

        // URL后缀
        if ('/' == substr($url, -1) || '' == $url) {
            $suffix = '';
        } else {
            $suffix = $this->parseSuffix($suffix);
        }

        // 锚点
        $anchor = !empty($anchor) ? '#' . $anchor : '';

        // 参数组装
        if (!empty($vars)) {
            $vars = http_build_query($vars);
            $url .= $suffix . ($vars ? '?' . $vars : '') . $anchor;
        } else {
            $url .= $suffix . $anchor;
        }

        $url =  $request->app .'/' . $url;

        // 检测域名
        $domain = $this->parseDomain($url, $domain);

        // URL组装
        return $domain . rtrim($this->root, '/') . '/' . ltrim($url, '/');
    }

    public function __toString()
    {
        return $this->build();
    }

    public function __debugInfo()
    {
        return [
            'url'    => $this->url,
            'vars'   => $this->vars,
            'suffix' => $this->suffix,
            'domain' => $this->domain,
        ];
    }
}