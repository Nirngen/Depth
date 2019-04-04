using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class xe10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //int有位数限制，过大的阶乘不能计算，溢出为0
            double result=1;
            double x = double.Parse(txtSum.Text);
            for (int i = 1; i <= x; i = i + 1)
            { result = result * i; }
            Response.Write(result);

        }
    }
}