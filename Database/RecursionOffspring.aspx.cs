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
    public partial class RecursionOffspring : System.Web.UI.Page
    {
        DataTable dt;
        string Goal;
        DataRow[] rows;
        DataRow[] row1;
        DataRow[] row2;
        DataRow[] row3;
        string EID1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void GetFather(string EID)
        {
            if (EID == Goal)
            {
                string sql3 = string.Format("EID='{0}'", EID1);
                row1 = dt.Select(sql3);
                Response.Write(row1[0]["ENAME"].ToString() + "</br>");
                return;
            }
            if (EID == "0")
                return;
            string condition = string.Format("EID ='{0}'", EID);
            rows = dt.Select(condition);
            if (rows.Length > 0)
            {
                GetFather(rows[0]["EPARENTID"].ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ENAME = TextBox1.Text;
            string sql = "select * from  DynastyHanEmperor ";
            SQLHelper sh = new SQLHelper();
            DataSet ds = new DataSet();
            sh.RunSQL(sql, ref ds);
            try
            {
                if (ds.Tables.Count > 0)//获取dataset中表的个数
                {
                    dt = ds.Tables[0];
                    string sql1 = "EID is not null";
                    string sql2 = string.Format("ENAME='{0}'", ENAME);
                    row2 = dt.Select(sql1);
                    row3 = dt.Select(sql2);
                    Goal = row3[0]["EID"].ToString();
                    for (int i = 0; i <= 34; i++)
                    {
                        EID1 = row2[i]["EID"].ToString();
                        GetFather(row2[i]["EPARENTID"].ToString());
                    }
                }
            }
            catch
            {
                Response.Write("Error!!");
            }
            finally
            {
                sh.Close();
            }

        }
    }
}