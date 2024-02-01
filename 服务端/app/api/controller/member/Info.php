<?php
namespace app\api\controller\member;
use app\api\controller\Base;
use app\common\exception\ParamException;
use app\common\model\MemberModel;
use app\common\model\MemberTitleModel;
use app\common\service\MessageService;
use app\common\validate\MemberValidate;
use GatewayWorker\Lib\Gateway;
use think\exception\ValidateException;
use think\facade\Db;
use Webman\Event\Event;

class Info extends Base{
    function info(){
        $user_info = \Tinywan\Jwt\JwtToken::getUser();
        unset($user_info['password'],$user_info['delete_time']);
        $user_info['level_title'] = config('world.level_list')[$this->user['level_id']] ?? '未知生物';
        $user_info['data_fortune'] = "好运";
        return $this->success('SUCCESS',$user_info);
    }

    function password()
    {
        $password = $this->request->param('password', '');
        if (!$password) {
            throw new ParamException('新密码不能为空');
        }
        $validate = new MemberValidate;
        if (!$validate->scene('reset_pass')->check([
            'password' => $password
        ])) {
            throw new ParamException($validate->getError());
        }
        MemberModel::where('uid', $this->uid)
            ->update([
                'password' => buildPass($password)
            ]);
        Event::emit('refresh.member',$this->uid);
        return $this->success('密码重置成功');
    }

    function nickname()
    {
        $nickname = $this->request->param('nickname', '');
        $nickname = str_replace(' ', '', $nickname);
        $validate = new MemberValidate;
        if (!$validate->scene('update')->check([
            'nickname' => $nickname
        ])) {
            throw new ParamException($validate->getError());
        }
        if ($nickname == $this->user['nickname']) {
            throw new ParamException('新道号未发生改变');
        }
        if ($this->user['data_gold_coin'] < 200) {
            //throw new ParamException('修改道号需要支付200金币，余额不足');
        }
        $check = MemberModel::where('nickname', $nickname)->count();
        if ($check > 0) {
            throw new ParamException('道号已被占用');
        }
        $res = MemberModel::where('uid', $this->uid)
            //->where('data_gold_coin', '>=', 200)
            ->update([
                'nickname' => $nickname,
                'data_gold_coin' => Db::raw('data_gold_coin - 200'),
                'mask_title_id' => 0,
                'mask_title_name' => ''
            ]);
        if ($res == 0) {
            throw new ParamException('余额不足');
        }
        MemberTitleModel::destroy(['member_uid' => $this->uid],true);
        Event::emit('refresh.member',$this->uid);
        MessageService::Uid([
            'type'=>'system',
            'data'=>[
                'type' => 'init',
                'data' => 'user',
            ]
        ],$this->uid);
        return $this->success('修改成功');
    }

    function title()
    {
        if ($this->request->isGet()) {
            $title_list = MemberTitleModel::where('member_uid',$this->uid)
                ->order('id desc')
                ->column('title_id id,title,color');
            return $this->success('SUCCESS', $title_list);
        }
        $id = $this->request->param('id', 0);
        $mask_title_name = '';
        if ($id > 0) {
            $check = MemberTitleModel::where('member_uid', $this->uid)
                ->where('title_id', $id)
                ->field('id,title_id,title,color')
                ->find();
            if ($check) {
                $id = $check['title_id'];
                $mask_title_name = $check['title'];
            }else{
                throw new ParamException('称号不存在');
            }
        }

        MemberModel::where('uid', $this->uid)->update([
            'mask_title_id' => $id,
            'mask_title_name' => $mask_title_name,
        ]);
        Event::emit('refresh.member',$this->uid);
        MessageService::Uid([
            'type'=>'system',
            'data'=>[
                'type' => 'init',
                'data' => 'user',
            ]
        ],$this->uid);
        return $this->success('称号使用成功');
    }
}