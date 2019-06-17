using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main
{
    public partial class Mean : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double[] Month201810RangeData = { 1.3526, 1.0206, -2.1834, -0.1902, 0.0194, 0.3264, -2.2619, 4.0938, 2.5759, -2.9355, 0.6003, -0.8477, -1.4889, 0.9079, -5.2233, 0.1773, 0.1657, -3.7159 };
            double[] Month201710RangeData = { 0.0886, -0.7749, 0.2713, 0.3141, 0.2553, 0.2233, 0.0607, 0.2515, -0.3437, 0.2892, -0.1903, -0.3555, 0.1306, -0.0645, 0.1565, 0.2552, 0.7595 };
            Response.Write("17年10月均值"+calcMean(Month201710RangeData)+"</br>");
            Response.Write("18年10月均值"+calcMean(Month201810RangeData)+"</br>");
            Response.Write("17年10月标准差" + calcVari(Month201710RangeData) + "</br>");
            Response.Write("18年10月标准差" + calcVari(Month201810RangeData) + "</br>");
        }
        public double calcMean(double[] list)
        {
            double result=0;
            foreach (double i in list)
            {
                result = result + i;
            }
            result = result / list.Length;
            return result;
        }
        public double calcVari(double[] list)
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
    }
}