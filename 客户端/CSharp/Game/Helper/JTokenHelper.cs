using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Helper
{
    public class JTokenHelper
    {
        public static int ToInt(JToken obj, int def = 0)
        {
            try
            {
                if (obj == null)
                {
                    return def;
                }
                else
                {
                    return Convert.ToInt32(obj.ToString());
                }
            }
            catch (Exception e)
            {
                return 0;
            }


        }

        public static string ToStr(JToken obj, string def = "")
        {
            try
            {
                if (obj == null)
                {
                    return def;
                }
                else
                {
                    return obj.ToString();
                }
            }
            catch (Exception e)
            {
                return "";
            }

        }

        public static string ToStrN(JToken? obj, string path,string def = "")
        {
            try
            {
                if (obj == null)
                {
                    return ToStr(ToJToken(obj, path, def)) ;
                }
                else
                {
                    return obj.ToString();
                }
            }
            catch (Exception e)
            {
                return "";
            }

        }

        public static JToken ToJToken(JToken? obj, string path, JToken def = null)
        {
            try
            {
                string[] paths = path.Split('.');
                if (obj == null)
                {
                    return def;
                }
                foreach (string s in paths)
                {
                    obj = obj[s];
                    if (obj == null)
                    {
                        return def;
                    }
                }
                return obj;
            }
            catch (Exception e)
            {
                return def;
            }

        }
    }
}
