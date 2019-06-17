using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.AITools.Tvbboy;

namespace Main
{
    public partial class NormalC : System.Web.UI.Page
    {
        double[] Scores2019 ={90,79,91,89,77,82,85,88,78,92,92,94,93,72,92,91,92,76,86,87,77,79,89,90,90,81,92,86};
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public float intoZ(double x, double mean, double vari)
        {
            x = (x - mean) / vari;
            string x1 = x.ToString();
            float x2 = float.Parse(x1);
            return x2;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                double score = float.Parse(TextBox1.Text);
                if (score > 100 || score < 0)
                    Response.Write("请输入正确的成绩");
                else
                {
                    Mean me = new Mean();
                    double a = me.calcMean(Scores2019);
                    double b = me.calcVari(Scores2019);
                    float z1 = intoZ(score, a, b);
                    float z2 = intoZ(110, a, b);
                    double result = ClassStatistics.selfCaculate(z2) - ClassStatistics.selfCaculate(z1);
                    result = result * 100;
                    Response.Write("估计你的排名在前" + result + "%");
                }
            }
            catch(Exception ex)
            {
                Response.Write("输入错误！"+"</br>"+ex.Message);
            }
            finally
            {

            }
        }
    }
}