using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class JudgeLeapYear : IsLeapYear
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (uint i = 1949; i <= 2018; i++)
            {
                if (RN(i))
                    Response.Write(i + ",");
            }
        }
    }
}