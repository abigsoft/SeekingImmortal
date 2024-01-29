<?php

namespace app\api\controller;

use app\common\exception\ParamException;
use app\common\model\TitleMainModel;
use app\common\model\WorldChatModel;
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

    function cancel(){
        $message_id = $this->request->param('message_id', '');
        if (!$message_id) {
            throw new ParamException('该消息不能撤回');
        }
        if (!$this->user['account_status']) {
            throw new ParamException('您的账号已被禁用');
        }
        if (!$this->user['character_status']) {
            throw new ParamException('您的角色已被禁用');
        }
        if ($this->uid != "administrator") {
            $info = WorldChatModel::where('id', $message_id)
                //->where('channel', 'world')
                ->field('id,create_time,member_uid,message_data')
                ->find();
            if (!$info) {
                throw new ParamException('该消息不存在');
            }
            if ($info['member_uid'] != $this->uid) {
                throw new ParamException('不是你的消息禁止撤销');
            }
            if (time() - strtotime($info['create_time']) > 120) {
                throw new ParamException('2 分钟以上的消息禁止撤回');
            }
            if(stripos($info['message_data'],'#')!== false){
                throw new ParamException('事件消息禁止撤回');
            }
        }else{
            $info['message_data'] = '';
        }
        MessageService::World([
            "type" => "world",
            "data" => [
                "channel" => "cancel",//world世界,person个人,group群组，cancel撤销消息
                "data" => [
                    "id" => 0,//0为世界，群组为对应群组的ID
                    "name" => "世界",
                    "notice" => 0,//是否提醒
                    "message" => [
                        "id" => $message_id,
                        "time" => date('H:i:s')
                    ]
                ]
            ]
        ]);
        if ($this->uid != "administrator") {
            MessageService::System(($this->user['nickname']) . " 刚刚撤回了一条见不得人的消息", '#C0C0C0');
            MessageService::System(($this->user['nickname']) . " 撤回了一条消息：" . $info['message_data'], '#FF0000','administrator');
        }

        return $this->success('消息撤销成功', $info['message_data']);
    }
}