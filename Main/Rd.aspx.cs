using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main
{
    public partial class Rd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random rd = new Random();
            int i = 0;
            int a = 0;
            int[] num = new int[99];
            while (i <= 98)
            {
                a = rd.Next(1, 100);
                int k = 1;
                foreach (int j in num)
                {
                    if (j == a)
                        break;
                    if (k == 99)
                    {
                        num[i] = a;
                        Response.Write(a.ToString()+"</br>");
                        i++;
                    }
                    k++;
                }
            }
            //思路二：因为要生成99个不重复数字，且连续处于1-100间，那么可以将其视为数组的不同索引，只要num[a]!=0即可
        }
    }
}