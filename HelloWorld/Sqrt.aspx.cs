using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class Sqrt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double n = double.Parse(txtNum.Text);
            double s = double.Parse(txtSqrt.Text);
            double l = 0.0001;
            double g=0;
            double g2 = Math.Sqrt(n);
            Response.Write("内置函数计算结果为" + g2 + "</br>");
            double k = 0;
            bool A = true;
            if (n < 0||s<0)
                Response.Write("输入数值不能为负");
            else
            {
                for (int j = 0; j * j < 10000 * n; j++)
                {
                    if (j * j > n)
                    {
                        g = j - 1;
                        k = j - 1;
                        break;
                    }
                }
                while ((g * g - n) * (g * g - n) > l * l)
                {
                    g = g + s;
                    if (g * g - n > 0)
                    {
                        Response.Write("步长过大");
                        A = false;
                        break;
                    }
                }
                if (A)
                    Response.Write(g);
            }
        }
    }
}