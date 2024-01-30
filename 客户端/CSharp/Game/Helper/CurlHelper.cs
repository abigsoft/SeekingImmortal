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
        public static async Task<string> GetAsync(string url, string token = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage response = await _httpClient.GetAsync(url);
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
    }
}
