using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class SolveP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem li;
                string i0;
                for (int i = 1; i <= 20; i++)
                {
                    i0 = Convert.ToString(i);
                    li = new ListItem(i0, i0);
                    ddl1.Items.Add(li);
                    ddl2.Items.Add(li);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int d1 = int.Parse(ddl1.SelectedValue);
            int d2 = int.Parse(ddl2.SelectedValue);
            bool an = false;
            if (d1 >= d2)
                Response.Write("Please Try Again");
            else
            {
                if (d1 == 2)
                    Response.Write(2 + "</br>");
                for (int i = d1; i <= d2; i++)
                {
                    for (int i1 = 2; i1 < i; i1++)
                    {
                        if (i % i1 == 0)
                        {
                            break;
                        }
                        if (i1 == i - 1)
                        {
                            Response.Write(i + "</br>");
                            an = true;
                        }
                    }
                }
                if (an == false)
                    Response.Write("No P");
            }
        }
    }
}