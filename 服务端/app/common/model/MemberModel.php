<?php


namespace app\common\model;

class MemberModel extends BaseModel
{
    protected $pk = 'uid';

    protected $name = 'member';

    protected static function onAfterWrite(\think\Model $model): void
    {
        //\support\Redis::set('user_info_' . $model->uid, $model->toJson());
        //\support\Redis::hSet('task:member_list',$model->uid,$model->toJson());
    }
}