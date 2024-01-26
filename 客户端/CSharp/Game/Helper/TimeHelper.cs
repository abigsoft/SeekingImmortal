using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Helper
{
    internal class TimeHelper
    {
        /// <summary>  
        /// 获取当前时间戳  
        /// </summary>  
        /// <param name="bflag">为真时获取10位时间戳,为假时获取13位时间戳.</param>  
        /// <returns></returns>  
        public static long GetTimeStamp(bool bflag = true)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            string ret = string.Empty;
            if (bflag)
                ret = Convert.ToInt64(ts.TotalSeconds).ToString();
            else
                ret = Convert.ToInt64(ts.TotalMilliseconds).ToString();

            return long.Parse(ret);
        }

        public static int GetTimeStamp(DateTime time, bool bflag = true)
        {
            TimeSpan ts = time - new DateTime(1970, 1, 1, 8, 0, 0, 0);
            string ret = string.Empty;
            if (bflag)
                ret = Convert.ToInt64(ts.TotalSeconds).ToString();
            else
                ret = Convert.ToInt64(ts.TotalMilliseconds).ToString();

            return int.Parse(ret);
        }

        public static string GetTimeStamp(int time, bool bflag = true)
        {
            DateTime s = new DateTime(1970, 1, 1, 8, 0, 0, 0);
            s = s.AddSeconds(time);
            return s.ToString("HH:mm:ss");
        }
        public static DateTime ConvertTimeStampToDateTime(int timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0));
            return dtStart.AddSeconds(timeStamp);
        }
    }
}
