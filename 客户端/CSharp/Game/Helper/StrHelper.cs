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
        public static Color HexToColor(string hex)

        {
            Color col = ColorTranslator.FromHtml(hex);
            return col;
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
        ///<summary>
        ///生成随机字符串 
        ///</summary>
        ///<param name="length">目标字符串的长度</param>
        ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
        ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
        ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
        ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        ///<returns>指定长度的随机字符串</returns>
        public static string GetRandomString(int length, bool useNum = true, bool useLow = false, bool useUpp = false, bool useSpe = false, string custom = "")
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
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

        public static string MD5Encrypt(string normalTxt)
        {
            try
            {
                var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] emailBytes = Encoding.UTF8.GetBytes(normalTxt.ToLower());
                byte[] hashedEmailBytes = md5.ComputeHash(emailBytes);
                StringBuilder sb = new StringBuilder();
                foreach (var b in hashedEmailBytes)
                {
                    sb.Append(b.ToString("x2").ToLower());
                }
                return sb.ToString();
            }
            catch
            {
                return "";
            }
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
