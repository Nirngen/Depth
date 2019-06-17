using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main
{
    public partial class SolvePPCC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double[] ShangZ = { 3.1992, -0.9189, 0.855, -1.5095, -1.9689, 0.0869, 0.3499, -0.0108, -0.1758, 2.471, 1.0388, -1.1981, -1.09, 1.1006, 1.9237, -4.3959, 0.1392, 1.5668, 0.8809, 1.1213, 1.8039 };
            double[] MaoT = { 5.849, 2.3209, 2.0052, -0.3352, -2.3174, 1.05, -0.8893, 0.024, -2.1578, 4.2184, -0.09, 3.183, 1.2067, -1.7837, 2.8529, -1.4828, -2.526, -1.5107, -0.266, -0.9426, 4.5417 };
            Response.Write("上证指数" + PrintData(ShangZ) + "</br>");
            Response.Write("贵州茅台" + PrintData(MaoT) + "</br>");
            Response.Write("相关系数为" + ppcc(ShangZ, MaoT)+"</br>");
            JudgePPCC(ppcc(ShangZ, MaoT));
        }
        protected double calcMean(double[] list)
        {
            double result = 0;
            foreach (double i in list)
            {
                result = result + i;
            }
            result = result / list.Length;
            return result;
        }
        protected double calcVari(double[] list)
        {
            double result = 0;
            double mean = calcMean(list);
            foreach (double i in list)
            {
                result = Math.Pow(i - mean, 2) + result;
            }
            result = Math.Sqrt(result / list.Length);
            return result;
        }
        public double ppcc(double[] list1, double[] list2)
        {
            double a1 = calcVari(list1);
            double a2 = calcMean(list1);
            double b1 = calcVari(list2);
            double b2 = calcMean(list2);
            if (!(list1.Length == list2.Length))
            {
                Response.Write("数据长度不符");
                return -1;
            }
            else
            {
                double result = 0;
                for (int i = 0; i <= list1.Length - 1; i++)
                {
                    result = (list1[i] - a2) * (list2[i] - b2) + result;
                }
                result = result / (a1 * b1 * list1.Length);
                return result;
            }
        }
        public string PrintData(double[] list)
        {
            string a = "";
            string b = "";
            for (int i = 0; i <= list.Length - 1; i++)
            {
                b = list[i].ToString();
                b = b + ",";
                a = a + b;
            }
            return a;
        }
        public void JudgePPCC(double x)
        {
            if (x > 0)
                Response.Write("正相关，涨跌一致");
            if (x == 0)
                Response.Write("互不相关");
            if(x<0)
                Response.Write("负相关，涨跌相反");
        }
    }
}