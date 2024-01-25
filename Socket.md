# Socket交互格式

## &#x20;请求连接

ws\://{url}/?token\={token}

## 数据格式

1.  系统消息

    ```JSON
    {
      "type":"system",
      "data":{
        "type":"notice"，
        "data":"这里是消息"
      }
    }
    ```

2.  清屏

        {
          "type":"system",
          "data":{
            "type":"clear"，
            "data":"world"//清屏位置
          }
        }

3.  静态状态

        {
          "type":"statistics",
          "data":{
            "online":20,//在线人数
          }
        }

4.  世界消息

        {
          "type":"world",
          "data":{
            "channal":"world",//world世界,person个人,group群组，cancel撤销消息
            "data":{
              "id":0,//0为世界，群组为对应群组的ID
              "name":"名称",
              "notice":0,//是否提醒
              "message":{
                "id":"消息ID",
                "from":{
                  "uid":"1",//用户ID
                  "title":"天道",//称号
                  "area":"山东",//位置
                  "name":"王小明"//昵称
                },
                "color":{//颜色
                  "title":"#000000",//称号
                  "name":"#000000",//昵称
                  "message":"#000000",//消息
                  "area":"#000000",//位置
                  "time":"#000000"//时间
                },
                "event":"",//事件标签
                "message":{
                  "type":"text",//消息类型，text文本，image图片,emoji表情
                  "data":"这里是消息"//消息本体
                },
                "time":"20:59:59"
              }
            }
          }
        }































