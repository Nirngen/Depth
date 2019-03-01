using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class GetMax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //输入的数据一定是str
            double num1 = Double.Parse(txtNum1.Text);
            double num2 = Double.Parse(txtNum2.Text);
            double num3 = Double.Parse(txtNum3.Text);
            double a;
            if (num1 >= num2)
            {
                if (num1 >= num3)
                    a = num1;
                else
                    a = num3;
            }
            else
            {
                if (num2 >= num3)
                    a = num2;
                else
                    a = num3;
            };
            Response.Write(txtNum1.Text + ','+ txtNum2.Text + ','+ txtNum3.Text + "最大值是" + a + "</br>" + "来自Response语句");
        }
    }
}