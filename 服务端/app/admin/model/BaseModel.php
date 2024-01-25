<?php

namespace app\admin\model;

//use toptink\think\Model;
//use think\Model;
use think\model\concern\SoftDelete;

class BaseModel extends \think\Model
{
    protected $autoWriteTimestamp = 'datetime';

    protected $createTime = 'create_time';
    protected $updateTime = 'update_time';

    use SoftDelete;
    protected $deleteTime = 'delete_time';
    protected $defaultSoftDelete = null;
}