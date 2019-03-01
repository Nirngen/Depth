using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class GetTriangularArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double a = double.Parse(txt1.Text);
            double b = double.Parse(txt2.Text);
            double c = double.Parse(txt3.Text);
            string d1;
            string d2;
            //先判断是否为三角形
            if (a + b <= c || a + c <= b || b + c <= a)
                Response.Write("你输入的三条边不能构成1个三角形");
            else
            {
                double p = (a + b + c) * 0.5;
                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

                if (a * a + b * b > c * c)
                    d1 = "锐角";
                else if (a * a + b * b == c * c)
                    d1 = "直角";
                else
                    d1 = "钝角";

                if (a == b || b == c || a == c)
                {
                    if (a == b && b == c)
                        d2 = "等边";
                    else
                        d2 = "等腰";
                }
                else
                    d2 = "一般";

                Response.Write("你输入的三条边组成了一个" + d2 + d1 + " 三角形，它的面积是" + s);

            }

        }
    }
}