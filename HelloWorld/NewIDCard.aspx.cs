using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class NewIDCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = TextBox1.Text;
            int sum = 0;
            int[] s = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };//系数
            char[] s2 = { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };//结果
            bool key = true;
            if (id.Length != 18)
            {
                key = false;
            }
            if (key)
                if (!(id.Substring(17, 1)=="X"|| id.Substring(17, 1) =="x"|| (Convert.ToInt32(Char.Parse(id.Substring(17, 1))) <= 57 && Convert.ToInt32(Char.Parse(id.Substring(17, 1))) >= 48)))
                {
                    key = false;
                }
            if (key)
            {
                foreach (char i in id.Substring(0,17))
                {
                    if (!(Convert.ToInt32(i) <= 57 && Convert.ToInt32(i) >= 48))
                    {
                        key = false;
                    }
                }
            }
            if (!key)
                Response.Write("Error!");
            else
            {
                for (int i = 0; i <= 16; i++)
                {
                    sum = sum + Int32.Parse(id[i].ToString()) * s[i];
                }
                sum = sum % 11;
                if (s2[sum] != id[17])
                    key = false;
            }
            if (key)
            {
                Response.Write("正确！");
            }
            else
                Response.Write("Error!");
        }
    }
}