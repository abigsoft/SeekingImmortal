using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entity
{
    public class ResultEntity
    {
        private int status = 0;
        public void setStatus(int value)
        {
            status = value;
        }

        public int getStatus()
        {
            return status;
        }
        private string msg = "系统错误";
        public void setMsg(string value)
        {
            msg = value;
        }

        public string getMsg()
        {
            return msg;
        }
        private JToken data = null;
        public void setData(JToken value)
        {
            data = value;
        }

        public JToken getData()
        {
            return data;
        }

        public string toString()
        {
            if (data == null)
            {
                return "{}";
            }
            return data.ToString();
        }
    }
}
