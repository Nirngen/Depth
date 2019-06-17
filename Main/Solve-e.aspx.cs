using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main
{
    public partial class Solve_e : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //利用1/x在1-2间的面积，求出ln2，即log2 e，math.pow即得
            int num = 1000000;
            double x, y;
            double s = 0;
            double p, n;
            n = 0;
            Random rd = new Random();
            for (int i = 0; i <= num; i++)
            {
                x = rd.NextDouble() * 1 + 1;
                y = rd.NextDouble() * 1 + 0;
                if (1 / x >= y)
                {
                    n++;
                }
            }
            p = n / num;
            s = 1 * 1 * p;//ln2
            double result = 0;
            result = Math.Pow(2, 1/s);
            Response.Write(result);
        }
    }
}