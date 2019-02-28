using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class var : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int a=0;
            int b = 3;
            byte c = 6;
            char d = 'a';
            double e1 = 3.1415;
            bool f;
            byte g = 255;
            Response.Write(a+"</br>");
            Response.Write("<font color=red>" + b + "</font>"+"</br>");
            f = !(b <= 4 && b >= 3);
            Response.Write(f);

            //下面是不同类数据、同类数据的运算情形
            int A = 10;
            int B = 3;
            double K=A/B;
            double K2 = A / 3.0;
            Response.Write(K+"</br>");
            Response.Write(K2);

            //byte h=g+1,it's a false code.
        }
    }
}