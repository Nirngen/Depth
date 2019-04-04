using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;
using System.Data.SqlClient;
using System.Data;

namespace Database
{
    public partial class DatabaseDDL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLHelper sh = new SQLHelper();
            string sql1 = "select c_dy,c_dynasty_chn from (select c_nianhao_id,c_dy,c_dynasty_chn,c_nianhao_chn from NIAN_HAO where c_dynasty_chn != '未詳' and c_nianhao_chn != '未詳' and c_dynasty_chn is not null and c_nianhao_chn is not null and c_dy is not null)a group by c_dynasty_chn,c_dy order by c_dy";
            DataSet ds = new DataSet();
            sh.RunSQL(sql1, ref ds);
            if (!IsPostBack)
            {
                ddlD.DataSource = ds.Tables[0];
                ddlD.DataTextField = "c_dynasty_chn";
                ddlD.DataValueField = "c_dy";
                ddlD.DataBind();
                //绑定数据库的流程如上
                ddlD.Items.FindByValue("5").Selected = true;
            }
            sh.Close();
            //string a = ddlD.DataValueField; 这样出来的是c_dy
            string a = ddlD.SelectedValue;
            string sql2 = string.Format("select c_nianhao_chn,c_nianhao_id from NIAN_HAO where c_dynasty_chn != '未詳' and c_nianhao_chn != '未詳' and c_dynasty_chn is not null and c_nianhao_chn is not null and c_dy is not null and c_dy ={0}", a);
            DataSet ds1 = new DataSet();
            //新建一个ds（不知道为什么，关掉sh后再run sql2，然后用ds.table[0]会出现很多空白项）
            sh.RunSQL(sql2, ref ds1);
            ddlN.DataSource = ds1.Tables[0];
            ddlN.DataTextField = "c_nianhao_chn";
            ddlN.DataValueField = "c_nianhao_id";
            ddlN.DataBind();
            sh.Close();

        }

        protected void ddlN_SelectedIndexChanged(object sender, EventArgs e)
        {
            //注意这个是ddlN的changed，如果是ddlD的，的确可以替代pageload里的代码
        }
    }
}