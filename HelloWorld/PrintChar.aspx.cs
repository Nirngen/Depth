using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class PrintChar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //A，65
            int line = int.Parse(txtLine.Text);
            char r;
            if (line >= 27 || line <= 0)
            { Response.Write("位数不合法"); }
            else
            {
                for (int i = 1; i <= line; i++)
                {
                    for (int i1 = 1; i1 <= line - i; i1++)
                    { Response.Write("&nbsp;"); };
                    r = Convert.ToChar(i + 64);
                    for (int i2 = 1; i2 <= 2 * i - 1; i2++)
                    { Response.Write(r); };
                    for (int i3 = 1; i3 <= line - i; i3++)
                    { Response.Write("&nbsp;"); };
                    Response.Write("</br>");
                    //防止特殊情况，如27行

                }
            }
        }
    }
}