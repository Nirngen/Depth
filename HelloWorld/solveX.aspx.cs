using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class solveX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double chi=0;
            double rabi=0;
            for (int a=0; (chi + rabi!= 35)&&(2 * chi + 4 * rabi != 94); a++ )
            {
                chi = a;
                rabi = 0;
                for (int b=0; (chi+b!=35); b++ )
                { rabi = b;}
            }
            Response.Write("共有"+chi+"只鸡，"+rabi+"只兔子");
        }
    }
}