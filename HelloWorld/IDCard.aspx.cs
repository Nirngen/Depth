using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class IDCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string k = txtID.Text;

            if (!(k.Length == 18))
                Response.Write("False");
            else
            {
                bool a = true;
                int r;
                int sum=0;
                int[] s = { 7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2 };
                char[] s2 = { '1','0','X','9','8','7','6','5','4','3','2' };
                char[] hey = k.ToCharArray();
                //将字符串强行转化为数组，只能tochar
                for (int i = 0; i <= 16; i++)
                {
                    r = Convert.ToInt32(hey[i]);
                    //48-57,数字的ascii码范围
                    if ((r > 57) || (r < 48))
                        a = false;
                }
                r = Convert.ToInt32(hey[17]);
                if (!((r <= 57 && r >= 48) || r == 88 || r == 120))
                    a = false;
                if (!a)
                    Response.Write("False");
                else
                {
                    for (int j = 0; j <= 16; j++)
                    {
                        sum = sum + hey[j] * s[j];
                    }
                    sum = sum % 11;
                    char C = s2[sum];
                    if (hey[17] == C)
                        Response.Write("False");
                    //错误步骤就是这一步，因为char相乘为ASCII码相乘
                    else
                    {
                        for (int h = 6; h <= 13; h++)
                        {
                            Response.Write(hey[h]);
                            if (h == 9)
                                Response.Write("年");
                            if (h == 11)
                                Response.Write("月");
                            if (h == 13)
                                Response.Write("日");
                        }
                        if (hey[16] % 2 == 1)
                            Response.Write("男");
                        else
                            Response.Write("女");
                    }


                }
            }
        }
    }
}