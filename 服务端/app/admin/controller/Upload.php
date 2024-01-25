<?php 

namespace app\admin\controller;
use app\common\model\UploadsModel;
use think\facade\Log;
use think\facade\Db;
use think\facade\Validate;
use think\facade\Filesystem;
use think\exception\ValidateException;

class Upload extends Admin{
	
	
	
	//上传前先检测上传模式 如果是oss客户端直传则直接返回 token 、key等信息
	public function upload(){
		$file = $this->request->file('file');
		$file_type = upload_replace(config('sys.upload_file_ext')); //上传黑名单过滤
		if(!Validate::fileExt($file,$file_type)){
			throw new ValidateException('文件类型验证失败');
		}
		
		if(!Validate::fileSize($file,config('sys.upload_file_size') * 1024 * 1024)){
			throw new ValidateException('文件大小验证失败');
		}
        $filepath = UploadsModel::where('hash',$file->hash('md5'))->value('path');
        if($filepath){
            return $this->suc('SUCCESS',$filepath);
        }else{
			$edit = $this->request->post('edit');	//检测是否编辑器上传  如果是则不走oss客户端传
			if(config('my.oss_status') && config('my.oss_upload_type') == 'client' && !$edit){
				switch(config('my.oss_default_type')){
					case 'qiniuyun';
						$data['serverurl'] = config('my.qny_oss_client_uploadurl');
						$data['domain'] = config('my.qny_oss_domain');
                        $qn_auth = new \Qiniu\Auth(config('my.qny_oss_accessKey'), config('my.qny_oss_secretKey'));
                        $data['token'] = $qn_auth->uploadToken(config('my.qny_oss_bucket'));
					break;

					case 'tencent';
						$data['SecretId'] = config('my.tencent_oss_secretId');
						$data['SecretKey'] = config('my.tencent_oss_secretKey');
						$data['Bucket'] = config('my.tencent_oss_bucket');
						$data['Region'] = config('my.tencent_oss_region');
						$data['Schema'] = config('my.tencent_oss_schema');
					break;
				}
                $data['key'] = (app('http')->getName().'/'.date(config('my.upload_subdir'))).'/'.$file->hash('md5').'.'.$file->extension();
				$data['type'] = config('my.oss_default_type');
                return $this->suc('SUCCESS',$data);
			}else{
                try{
                    if(config('my.oss_status')){
                        $url = \utils\oss\OssService::OssUpload($file);
                        $disk = config('my.oss_default_type');
                    }else{
                        $filename = Filesystem::disk('public')->putFile(app('http')->getName().'/'.date(config('my.upload_subdir')),$file,'uniqid');
                        $url = config('base_config.domain').config('filesystem.disks.public.url').'/'.$filename;
                        $disk = 'local';
                    }
                }catch(\Exception $e){
                    throw new ValidateException('上传失败');
                }
                $data = ['path'=>$url,'hash'=>$file->hash('md5'),'disk'=>$disk,'name'=>$file->getOriginalName()];
                if($url && explode('/',$file->getMime())[0] == 'image'){
                    $data['type'] = 1;
                }
                UploadsModel::create($data);
                return $this->suc('SUCCESS',$url);
			}
		}
	}
    //百度编辑器上传
    public function uploadUeditor(){
        ob_end_clean();
        $ueditor_config = json_decode(preg_replace("/\/\*[\s\S]+?\*\//", "", file_get_contents("static/admin/js/ueditor/php/config.json")), true);
        $action = $_GET['action'];
        switch ($action) {
            case 'config':
                $result = json_encode($ueditor_config);
                break;
            /* 上传图片 */
            case 'uploadimage':
                /* 上传涂鸦 */
            case 'uploadscrawl':
                /* 上传视频 */
            case 'uploadvideo':
                /* 上传文件 */
            case 'uploadfile':
                $file = $this->request->file('upfile');
                $file_type = upload_replace(config('sys.upload_file_ext')); //上传黑名单过滤
                if(!Validate::fileExt($file,$file_type)){
                    throw new ValidateException('文件类型验证失败');
                }

                if(!Validate::fileSize($file,config('sys.upload_file_size') * 1024 * 1024)){
                    throw new ValidateException('文件大小验证失败');
                }

                $filepath = UploadsModel::where('hash',$file->hash('md5'))->value('path');
                if($filepath) {
                    $url = $filepath;
                }else{
                    try{
                        if(config('my.oss_status')){
                            $url = \utils\oss\OssService::OssUpload($file);
                            $disk = config('my.oss_default_type');
                        }else{
                            $filename = Filesystem::disk('public')->putFile(app('http')->getName().'/'.date(config('my.upload_subdir')),$file,'uniqid');
                            $url = config('base_config.domain').config('filesystem.disks.public.url').'/'.$filename;
                            $disk = 'local';
                        }
                    }catch(\Exception $e){
                        throw new ValidateException('上传失败');
                    }
                    $data = ['path'=>$url,'hash'=>$file->hash('md5'),'disk'=>$disk,'name'=>$file->getOriginalName()];
                    if($url && explode('/',$file->getMime())[0] == 'image'){
                        $data['type'] = 1;
                    }
                    UploadsModel::create($data);
                }

                $result = json_encode(array(
                    'url' => $url,
                    'title' => htmlspecialchars($url, ENT_QUOTES),
                    'original' => basename($url),
                    'state' => 'SUCCESS'
                ));
                break;
            default:
                $result = json_encode(array(
                    'state' => '请求地址出错'
                ));
                break;
        }
        /* 输出结果 */
        if (isset($_GET["callback"])) {
            if (preg_match("/^[\w_]+$/", $_GET["callback"])) {
                die(htmlspecialchars($_GET["callback"]) . '(' . $result . ')');
            } else {
                die(json_encode(array(
                    'state' => 'callback参数不合法'
                )));
            }
        } else {
            die($result);
        }
    }

}