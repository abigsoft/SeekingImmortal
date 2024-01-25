## 系统环境
- Linux CentOS 7.6
- PHP >= 8.0
- MySQL >= 8.0
- Nginx
- Redis

## 环境启动
### 端口启动
- 7272 (Gateway)
- 8087 (Webman)
- 80 (Http)
- 443 (Https)
- 6379 (Redis)
- 1236 (Gateway Register)
- 2345 2346 (定时任务)

### 启动服务
- 启动(调试模式)
```PHP
php start.php start
```
- 启动(常驻模式)
```PHP
php start.php start -d
```
- 重载
```PHP
php start.php reload
```
- 重启
```PHP
php start.php restart
```
- 停止
```PHP
php start.php stop
```
