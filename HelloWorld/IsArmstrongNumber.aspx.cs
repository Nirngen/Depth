using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class IsArmstrongNumber : System.Web.UI.Page
    {
        public bool IsANumber(int x)
        {
            string x1 = x.ToString();
            int n = x1.Length;
            double re = 0;
            foreach (int i in x1)
            {
                int i1 = Convert.ToInt32(i)-48;
                //一串数字每一位转为ascii后归一至数字;其他处理方法有,1.把每一位的char转为string再转为int,避免ascii码2.int.parse(substring),因为sub得到的直接是字符串
                re = re + Math.Pow(i1, n);
            }
            if (re == x)
                return true;
            else
                return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            for (int t = 100; t <= 1000000; t++)
            {
                if (IsANumber(t))
                    Response.Write(t + "</br>");
            }
        }
    }
}