using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Game.Helper
{
    class StrHelper
    {
        public static Color HexToColor(string hex = "#000000")
        {
            try
            {
                Color col = ColorTranslator.FromHtml(hex);
                return col;
            }
            catch { 
                return Color.Black;
            }
            
        }
        public static string ChEncodeUrl(string str)
        {
            //byte[] byt = Encoding.Default.GetBytes(str);
            string ret = System.Web.HttpUtility.UrlEncode(str, Encoding.UTF8);
            ret = ret.Replace("!", "%21");
            ret = ret.Replace("*", "%2A");
            ret = ret.Replace("(", "%28");
            ret = ret.Replace(")", "%29");
            ret = ret.Replace("\\", "%5C");
            return ret;
        }
        
        public static string explodes(string str, int per, string sp = "\r\n")
        {
            StringBuilder str2 = new StringBuilder();
            int len = str.Length / per + 1;
            int i = 0;
            for (i = 0; i < len - 1; i++)
            {
                str2.Append(str.Substring(per * i, per)).Append(sp);
            }
            str2.Append(str.Substring(per * i));
            return str2.ToString();
        }
        public static bool checkEquals(string str1 = "", string str2 = "")
        {
            if (str1 == null || str2 == null)
            {
                if (str1 != null && str2 == null)
                    return false;
                if (str1 == null && str2 != null)
                    return false;
            }
            if (str1.Equals(str2) || str1 == str2)
                return true;
            else
                return false;

        }

        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary> 
        /// 释放内存
        /// </summary> 
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

        public static string toFix(string num)
        {
            if (string.IsNullOrEmpty(num))
            {
                return "0";
            }
            return decimal.Round(decimal.Parse(num), 2).ToString();
        }
    }
}
