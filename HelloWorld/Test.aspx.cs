using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int a1 = Convert.ToInt32("A");
            int a2 = Convert.ToInt32("Z");
            int a3 = Convert.ToInt32("a");
            int a4 = Convert.ToInt32("z");
            int a5 = Convert.ToInt32("0");
            int a6 = Convert.ToInt32("9");
            Response.Write(a1);
            Response.Write(a2);
            Response.Write(a3);
            Response.Write(a4);
            Response.Write(a5);
            Response.Write(a6);

        }
    }
}