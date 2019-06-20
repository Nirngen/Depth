using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;
using System.Data.SqlClient;

namespace Database
{
    public partial class Altname : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string an = txtName.Text;
            //不知道为什么，简体字也能查询到？
            string re = string.Empty;
            //string.empty不分配存储空间，而“”分配空的空间。empty较为规范
            if (an.Length < 1)
            {
                Response.Write("输入错误！");
                return;
            }
            SQLHelper sh = new SQLHelper();
            string sql = string.Format("select c_alt_name_chn from (select c_personid from biog_main where c_name_chn = '{0}')a inner join altname_data b on a.c_personid = b.c_personid",an);
            //用format来向string中添加变量
            SqlDataReader sdr;
            //声明sqldatareader
            try
            {
                sh.RunSQL(sql, out sdr);
                if (sdr.Read())
                {
                    Response.Write("TA的曾用名：");
                    Response.Write(string.Format("{0}", sdr["c_alt_name_chn"].ToString()) + "</br>");
                    //注意read（）是光标移动，如果不在这里write，只会输出第二个及之后的曾用名
                    while (sdr.Read())
                    {
                        Response.Write(string.Format("{0}", sdr["c_alt_name_chn"], ToString()) + "</br>");
                    }
                    sdr.Close();
                }
                else
                    Response.Write("没有找到记录");
            }
            catch (Exception ex)
            {
                re = ex.Message;
            }
            finally
            {
                Response.Write(re);
                sh.Close();
            }

        }
    }
}