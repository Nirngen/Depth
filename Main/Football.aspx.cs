using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main
{
    public partial class Football : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //只要随机两场（分成两堆，互相独立）;选取量化（进行随机）的目标；将量化转化为等式
            //若均为4分，出现概率各0.5
            //赢+3，平+1，输+0；
            //克罗地亚6分，尼日利亚3分，冰岛1分，阿根廷1分
            //尼阿，冰克
            int num = 1000000;
            double x, y;
            double m, n, q;
            q = 0;//冰岛
            m = 0;//尼日利亚
            n = 0;//阿根廷
            double p = num;//克罗地亚
            Random rd = new Random();
            for (int i = 0; i <= num; i++)
            {
                x = rd.NextDouble() * 3 + 0;
                y = rd.NextDouble() * 3 + 0;
                if ((x <= 1 && x >= 0) || (x >= 2 && x <= 3 && y >= 1 && y <= 3))
                {
                    m++;
                }
                if (x >= 1 && x <= 2 && y >= 1 && y <= 3)
                {
                    n++;
                }
                if (x >= 1 && x <= 2 && y <= 1 && y >= 0)
                {
                    q = q + 0.5;
                    n = n + 0.5;
                }
                if (x >= 2 && x <= 3 && y >= 0 && y <= 1)
                {
                    q = q + 0.5;
                    m = m + 0.5;
                }
            }
            Win(p, num, "克罗地亚");
            Win(q, num, "冰岛");
            Win(m, num, "尼日利亚");
            Win(n, num, "阿根廷");
        }
        protected void Win(double x, int num,string k)
        {
            double p = 0;
            p = x / num;
            Response.Write(string.Format(k + "出线的概率为{0}"+"</br>", p));
        }
    }
}