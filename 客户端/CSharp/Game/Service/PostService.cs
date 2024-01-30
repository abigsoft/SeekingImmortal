using Game.Entity;
using Game.Helper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service
{
    public class PostService
    {
        private static String base_url = ConfigModel.base_url;

        public String token = "";
        public String password = "";

        public async Task<ResultEntity> apiPost(String route, Dictionary<string, string> dic = null)
        {
            dic = OrderByKey(dic);
            String url = base_url + route;
            ResultEntity result = new ResultEntity();
            string html = await CurlHelper.PostAsync(url, token, dic);
            JToken res = JsonHelper.ExtractAll(html);
            if (res != null)
            {
                result.setStatus(JTokenHelper.ToInt(res["status"], result.getStatus()));
                result.setMsg(JTokenHelper.ToStr(res["msg"], result.getMsg()));
                result.setData(JTokenHelper.ToJToken(res, "data", result.getData()));
            }
            /**
            if (result.getStatus() == 888 || result.getStatus() == 887)
            {
                MessageBox.Show("登录已失效");
                Application.Exit();
            }**/
            return result;
        }

        public ResultEntity apiGet(String route, Dictionary<string, string> dic = null)
        {
            dic = OrderByKey(dic);
            String url = base_url + route;
            ResultEntity result = new ResultEntity();
            Thread thread = new Thread(() =>
            {
                String html = CurlHelper.Get(url, token,  dic);
                JToken res = JsonHelper.ExtractAll(html);
                if (res != null)
                {
                    result.setStatus(JTokenHelper.ToInt(res["status"], result.getStatus()));
                    result.setMsg(JTokenHelper.ToStr(res["msg"], result.getMsg()));
                    result.setData(JTokenHelper.ToJToken(res, "data", result.getData()));
                }
                /**
                if (result.getStatus() == 888 || result.getStatus() == 887)
                {
                    MessageBox.Show("登录已失效");
                    Application.Exit();
                }**/
            });
            thread.Start();
            thread.Join();
            return result;
        }

        public static Dictionary<string, string> OrderByKey(Dictionary<string, string> list)
        {
            if (list == null)
            {
                list = new Dictionary<string, string>();
            }
            list.Add("timestamp", TimeHelper.GetTimeStamp().ToString());
            list.Add("version", ConfigModel.version_id.ToString());
            Dictionary<string, string> dic1Asc = list.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            StringBuilder buffer = new StringBuilder();
            int i = 0;
            foreach (KeyValuePair<string, string> k in dic1Asc)
            {
                if (i > 0)
                {
                    buffer.AppendFormat("&{0}={1}", k.Key, StrHelper.ChEncodeUrl(k.Value.ToString().Trim()));
                }
                else
                {
                    buffer.AppendFormat("{0}={1}", k.Key, StrHelper.ChEncodeUrl(k.Value.ToString().Trim()));
                }
                i++;
            }
            buffer.AppendFormat("&secret=" + StrHelper.ChEncodeUrl("ox-*ppxljyhr-_$4b"));
            string sign = buffer.ToString();
            dic1Asc.Add("sign", StrHelper.MD5Encrypt(sign.ToLower()));
            return dic1Asc;
        }
    }
}
