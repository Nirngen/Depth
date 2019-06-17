using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class IsLeapYear : System.Web.UI.Page
    {
        public bool RN(uint x)
        {
            if (x % 100 == 0)
            {
                if (x % 400 == 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (x % 4 == 0)
                    return true;
                else
                    return false;
            }
        }
    }
}