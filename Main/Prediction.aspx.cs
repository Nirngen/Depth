using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.AITools.Tvbboy;

namespace Main
{
    public partial class Prediction : System.Web.UI.Page
    {
        Point[] izone = new Point[8];
        protected void Page_Load(object sender, EventArgs e)
        {
            izone[0] = new Point(178,62);
            izone[1] = new Point(192,83);
            izone[2] = new Point(182,55);
            izone[3] = new Point(169,58);
            izone[4] = new Point(175,55);
            izone[5] = new Point(173,60);
            izone[6] = new Point(176,60);
            izone[7] = new Point(183,68);
            RegressionN(izone, 1);
            Response.Write("</br>");
            RegressionN(izone, 2);
            Response.Write("</br>");
            JudgeRegression(izone, 1, 186, "72");
            JudgeRegression(izone, 2, 186, "72");
            JudgeRegression(izone, 1, 177, "60");
            JudgeRegression(izone, 2, 177, "60");
            Response.Write("经人眼识别，一次方程拟合程度较高"+"</br>");
            Response.Write("剩余数据：（176,59），（181,66）"+"</br>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double a = 0;
            string b = TextBox2.Text;
            try
            {
                double c = Double.Parse(b);
                a = Double.Parse(TextBox1.Text);
                if (a <= 0 || c < 0)
                    Response.Write("请输入正确的身高体重");
                else
                {
                    if (b != "0")
                        JudgeRegression(izone, 1, a, b);
                    else
                        JudgeRegression(izone, 1, a, "未输入");
                }
            }
            catch
            {
                Response.Write("请输入正确的身高体重");
            }
        }
        public void RegressionN(Point[] parray,int n)
        {
            //点数不能小于 n    
            if (parray.Length < n)
            {
                Response.Write("点的数量小于 n，无法进行线性回归");
                return;
            }
            //MultiLine 的第一个参数，是已经存在的点的集合，第二个参数是拟合的方程的最高 次幂  
            //返回的是 double[]类型的数组，这个数组放的就是方程的系数  
            double[] xishu = ClassLeastSquares.MultiLine(parray, n);
            string expr = "";
            for (int i = 0; i < xishu.Length; i++)
                expr += xishu[i].ToString() + "*x^" + i + "+"; expr = expr.Substring(0, expr.Length - 1);
            Response.Write(string.Format("{0}次",n)+"线性回归方程为： y = " + expr);
        }
        public void JudgeRegression(Point[] parray, int n,double x,string real)
        {
            if (parray.Length < n)
            {
                Response.Write("点的数量小于 n，无法进行线性回归");
                return;
            }
            double[] xishu = ClassLeastSquares.MultiLine(parray, n);
            double y =0;
            for (int i = 0; i < xishu.Length; i++)
            {
                y += xishu[i] * Math.Pow(x, i);
            }
            Response.Write("输入身高为" +x.ToString()+ string.Format("，{0}次函数预测体重为",n) +y.ToString()+ ",真实体重"+real+"</br>");
        }
    }
}