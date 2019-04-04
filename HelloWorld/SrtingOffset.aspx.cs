using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class SrtingOffset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string L1 = txtStr.Text;
            int num = int.Parse(txtNum.Text);
            if (num >= 26 || num <= 0)
            { Response.Write("位数不合法！"); }
            else
            {//A=65,Z=90;a=97,z=122
                foreach (char L in L1)

                {
                    int L2 = Convert.ToInt32(L);
                    if ((L2 + num <= 90 && L2 >= 65) || (L2 + num <= 122 && L2 >= 97))
                        L2 = L2 + num;
                    else if ((L2 >= 65 && L2 <= 90) || (L2 >= 97 && L2 <= 122))
                        L2 = L2 - (26 - num);
                    char L3 = Convert.ToChar(L2);
                    Response.Write(L3);
                    //错题：if后多分支要用elseif而不是if，否则计算机会看成进入新一个判断
                    //convert用来转换成ascii，parse不能强转
                    //进入页面立刻载入的代码仿佛会出问题
                    //foreach是遍历数组中每一个元素，而不是判断某个输入值的每一位是否在数组里
                    //防止特殊情况，如位数为27，-1等等
                }
            }
        }
    }
}