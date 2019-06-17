using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;
using System.Data;
namespace Database
{
    public partial class InsertDistance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string start = TextBox1.Text;
            string end = TextBox2.Text;
            string distance = TextBox3.Text;
            string sqlcheck = "select * from students.dbo.tblDistance";
            int ID = 0;
            string StudentNumber = "10185000222";
            //distance和学号需为float;ID is not null and INT
            SQLHelper sh = new SQLHelper();
            DataSet ds = new DataSet();
            sh.RunSQL(sqlcheck, ref ds);
            DataTable dt;
            DataRow[] row;
            dt = ds.Tables[0];
            row = dt.Select("ID is not null");
            bool a = true;
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = ID; j <= dt.Rows.Count + 1; j++)
                {
                    if (j != Int32.Parse(row[i]["ID"].ToString()))
                    {
                        ID = j;
                        break;
                    }
                }
                if ((start == row[i]["PointA"].ToString() && end == row[i]["Pointb"].ToString()) || (end == row[i]["PointA"].ToString() && start == row[i]["Pointb"].ToString()))
                {
                    a = false;
                    break;
                }
            }
            sh.Close();
            string sql = string.Format("insert into students.dbo.tblDistance (ID,PointA,pointB,Distance,StudentNumber)values({0},'{1}','{2}',{3},'{4}')", ID, start, end, distance, StudentNumber);
            SQLHelper sh1 = new SQLHelper();
            if (a)
            {
                sh1.RunSQL(sql);
                sh1.Close();
                Response.Write("插入成功");
            }
            else
                Response.Write("路径已存在");
        }
    }
}