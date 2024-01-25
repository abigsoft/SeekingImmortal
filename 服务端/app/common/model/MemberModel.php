<?php


namespace app\common\model;

class MemberModel extends BaseModel
{
    protected $pk = 'uid';

    protected $name = 'member';

    public static function onAfterWrite(\think\Model $model)
    {
        \support\Redis::set('user_info_' . $model->uid, $model->toJson());
    }
}