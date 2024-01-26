using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Game.Helper
{
    public class CurlHelper
    {
        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <returns></returns>
        public static string Post(string url, string token = "", Dictionary<string, string> dic = null)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            if (token != "")
            {
                req.Headers["Authorization"] = "Bearer " + token;
            }
            req.Headers["Version"] = ConfigModel.version_id.ToString();
            req.Timeout = 60000;
            #region 添加Post 参数
            StringBuilder builder = new StringBuilder();
            int i = 0;
            if (dic != null)
            {
                foreach (var item in dic)
                {
                    if (i > 0)
                        builder.Append("&");
                    builder.AppendFormat("{0}={1}", item.Key, StrHelper.ChEncodeUrl(item.Value));
                    i++;
                }
            }

            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            try
            {
                #endregion
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(result);
                return "{\"status\":203,\"msg\":\"服务异常\",\"data\":\"\"}";
            }


        }

        /// <summary>
        /// 发送Get请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="dic">请求参数定义</param>
        /// <returns></returns>
        public static string Get(string url, string token = "", Dictionary<string, string> dic = null)
        {
            string result = "";
            StringBuilder builder = new StringBuilder();
            builder.Append(url);
            if (dic != null && dic.Count > 0)
            {
                builder.Append("?");
                int i = 0;
                foreach (var item in dic)
                {
                    if (i > 0)
                        builder.Append("&");
                    builder.AppendFormat("{0}={1}", item.Key, item.Value);
                    i++;
                }
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(builder.ToString());
            if (token != "")
            {
                req.Headers["Authorization"] = "Bearer " + token;
            }
            req.Headers["Version"] = ConfigModel.version_id.ToString();
            req.Timeout = 60000;
            //添加参数
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            try
            {
                //获取内容
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(result);
                return "{\"status\":203,\"msg\":\"服务异常\",\"data\":\"\"}";
            }
            finally
            {
                stream.Close();
            }
            return result;
        }
    }
}
