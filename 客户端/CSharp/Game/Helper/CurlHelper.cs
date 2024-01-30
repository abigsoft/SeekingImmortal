using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Game.Helper
{
    public class CurlHelper
    {
        static readonly HttpClient _httpClient = new HttpClient();

        static CurlHelper()
        {
            _httpClient.Timeout = TimeSpan.FromMilliseconds(60000);
            // 配置你的 HttpClient (如添加通用的 Headers) 可以在这里完成
            _httpClient.DefaultRequestHeaders.Add("Version", ConfigModel.version_id.ToString());
        }
        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <returns></returns>
        public static async Task<string> PostAsync(string url, string token = "", Dictionary<string, string> dic = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var content = new FormUrlEncodedContent(dic ?? new Dictionary<string, string>());
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
