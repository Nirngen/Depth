using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public partial class K_Means : System.Web.UI.Page
    {
        /// <summary> 
        ///  用来显示二维的数据 
        /// </summary> 
        /// <param name="data">被显示的数据</param> 
        /// <param name="decimals">如果是数字的话显示的有效数字位数</param> 
        /// <param name="indices">是否显示编号一列</param>
        double[][] rawData;
        string[] nameData;
        int a = 0;
        public void ShowData(double[][] data, int decimals, bool indices,string[] name)
        {
            for (int i = 0; i < data.Length; ++i)
            {
                if (indices)
                    Response.Write(name[i] + "&nbsp;&nbsp&nbsp&nbsp");
                for (int j = 0; j < data[i].Length; ++j)
                {
                    if (data[i][j] >= 0.0)
                        Response.Write("&nbsp;&nbsp&nbsp&nbsp");
                    Response.Write(data[i][j].ToString("F" + decimals) + "&nbsp;&nbsp&nbsp&nbsp ");
                }
                Response.Write("</br>");
            }
        }
        public void ShowClustered(double[][] data, int[] clustering, int numClusters, int decimals,string[] name)
        { for (int k = 0; k < numClusters; ++k)
            { Response.Write("===================</br>");
                for (int i = 0; i < data.Length; ++i)
                { int clusterID = clustering[i];
                    if (clusterID != k)
                        continue;
                    Response.Write(name[i]+"&nbsp;&nbsp; ");
                    for (int j = 0; j < data[i].Length; ++j)
                    { double v = data[i][j];
                        Response.Write(v.ToString("F" + decimals) + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"); }
                    Response.Write("</br>"); }
                Response.Write("===================</br>"); } }
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLHelper sh = new SQLHelper();
            DataSet ds = new DataSet();
            DataTable dt;
            DataRow[] row;
            string sql = "";
            sql = "select name,military,power,wisdom,politics,charm from students.dbo.TblGenerals";
            sh.RunSQL(sql, ref ds);
            dt = ds.Tables[0];
            row = dt.Select("name is not null");
            sh.Close();
            rawData = new double[dt.Rows.Count][];
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                rawData[i] = new double[] {Double.Parse(row[i]["military"].ToString()), Double.Parse(row[i]["power"].ToString()),Double.Parse(row[i]["wisdom"].ToString()) ,Double.Parse(row[i]["politics"].ToString()) ,Double.Parse(row[i]["charm"].ToString()) };
            }
            a = dt.Rows.Count;
            SQLHelper sh1 = new SQLHelper();
            DataSet ds1 = new DataSet();
            DataTable dt1;
            DataRow[] row1;
            string sql1 = "";
            sql1 = "select name from students.dbo.TblGenerals";
            sh1.RunSQL(sql1, ref ds1);
            dt1 = ds1.Tables[0];
            row1 = dt1.Select("name is not null");
            sh1.Close();
            nameData = new string[dt1.Rows.Count];
            for (int i = 0; i <= dt1.Rows.Count - 1; i++)
            {
                nameData[i] = row1[i]["name"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int num = Int32.Parse(TextBox1.Text);
            Response.Write("\n 开始 k-means 聚类（clustering）\n");
            Response.Write("需要聚类的数据如下:</br>");
            Response.Write("&nbsp;&nbsp&nbsp&nbsp" + "&nbsp;&nbsp&nbsp&nbsp" + "&nbsp;&nbsp&nbsp&nbsp 统率&nbsp;&nbsp&nbsp&nbsp 武力&nbsp;&nbsp&nbsp&nbsp 智力&nbsp;&nbsp&nbsp&nbsp 政治&nbsp;&nbsp&nbsp&nbsp 魅力</br>");
            Response.Write("-------------------</br>");
            ShowData(rawData, 0, true,nameData);
            int numClusters = num;
            Response.Write("需要聚类的目标簇数: " + numClusters + "<br>");
            if (num > a)
                Response.Write("超出总数");
            else
            {
                int[] clustering = Common.AITools.Tvbboy.ClassKmeans.Cluster(rawData, numClusters);
                Response.Write("K-means 聚类结束 e<br>");
                Response.Write("原始数据被聚类之后的结果:<br>");
                ShowClustered(rawData, clustering, numClusters, 0, nameData);
            }
        }
    }
}