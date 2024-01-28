<?php

namespace app\api\controller;

use app\common\exception\ParamException;
use app\common\model\TitleMainModel;
use app\common\service\MessageService;
use GatewayWorker\Lib\Gateway;
use Workbunny\WebmanIpAttribution\Location;

class Message extends Base
{
    function world(): \support\Response
    {
        $message = $this->request->param('message', '');
        if ($message == '') {
            throw new ParamException('请输入消息');
        }
        if (!$this->user['account_status']) {
            throw new ParamException('您的账号已被禁用');
        }
        if (!$this->user['character_status']) {
            throw new ParamException('您的角色已被禁用');
        }
        if (mb_strlen($message) > 120) {
            throw new ParamException('消息最大支持120个字符');
        }
        if (!Gateway::isUidOnline($this->uid)) {
            throw new ParamException('未登录');
        }
        $type = $this->request->param('type', 'text');//消息类型，text文本，image图片,emoji表情
        if(!in_array($type,['text','image','emoji'])){
            throw new ParamException('消息类型错误');
        }
        $message = sensitive_replace($message, ' ~和谐发言~ ');
        $message_id = MessageService::Create(['uid' => $this->uid, 'name' => $this->user['nickname'], 'type' => $type, 'data' => $message]);
        $mask_title_info = null;
        if($this->user['mask_title_id']){
            $mask_title_info = TitleMainModel::where('id',$this->user['mask_title_id'])
                ->cache(true)
                ->field('id,title,color,special_effect')
                ->find();
        }
        if($mask_title_info){
            if($mask_title_info['special_effect'] != 'random'){
                $mask_title = [
                    'name' => $mask_title_info['title'],
                    "color" => [
                        "title" => $mask_title_info['color'] ? :'#000000',//称号
                        "name" => in_array('name',explode(',',$mask_title_info['special_effect'])) ? ($mask_title_info['color'] ? :'#000000') : '#000000',//昵称
                        "message" => in_array('message',explode(',',$mask_title_info['special_effect'])) ? ($mask_title_info['color'] ? :'#000000') : '#000000',//昵称
                        "area" => in_array('area',explode(',',$mask_title_info['special_effect'])) ? ($mask_title_info['color'] ? :'#000000') : '#000000',//昵称
                        "time" => in_array('time',explode(',',$mask_title_info['special_effect'])) ? ($mask_title_info['color'] ? :'#000000') : '#000000',//昵称
                    ],
                ];
            }else{
                $random_title_color = randomColor();
                $mask_title = [
                    'name' => $mask_title_info['title'],
                    "color" => [
                        "title" => $random_title_color,//称号
                        "name" => $random_title_color,//昵称
                        "message" => $random_title_color,
                        "area" => $random_title_color,
                        "time" => $random_title_color,
                    ],
                ];
            }

        }else{
            $mask_title = [
                'name' => config('world.level_list')[$this->user['level_id']] ?? '未知',
                "color" => [
                    "title" => "#000000",//称号
                    "name" => "#000000",//昵称
                    "message" => "#000000",//消息
                    "area" => "#000000",//位置
                    "time" => "#000000"//时间
                ],
            ];
        }
        $event = "";
        MessageService::World([
            "type" => "world",
            "data" => [
                "channel" => "world",//world世界,person个人,group群组，cancel撤销消息
                "data" => [
                    "id" => 0,//0为世界，群组为对应群组的ID
                    "name" => "世界",
                    "notice" => 0,//是否提醒
                    "message" => [
                        "id" => $message_id,
                        "from" => [
                            "uid" => $this->uid,//用户ID
                            "title" => $mask_title['name'],//称号
                            "name" => $this->user['nickname']//昵称
                        ],
                        "color" => [//颜色
                            "title" => $mask_title['color']['title'],
                            "name" => $mask_title['color']['name'],
                            "message" => $mask_title['color']['message'],
                            "time" => $mask_title['color']['time'],
                        ],
                        "event" => $event,//事件标签
                        "content" => [
                            "type" => $type,
                            "data" => $message
                        ],
                        "time" => date('H:i:s')
                    ]
                ]
            ]
        ]);
        return $this->success('SUCCESS');
    }
}