using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;
namespace ProjectEchart
{
    public partial class ExampleGeoMapLabel : System.Web.UI.Page
    {
        public DataTable dt;
        public string jsstirng = "";
       protected void Page_Load(object sender, EventArgs e)
        {
            SQLHelper sh = new SQLHelper();
            string sql = "select d.c_name_chn,d.x_coord,d.y_coord from BIOG_ADDR_CODES c inner join ( select a.c_addr_type,b.c_name_chn,x_coord,y_coord from BIOG_ADDR_DATA a inner join ADDRESSES b on a.c_addr_id = b.c_addr_id where a.c_personid = ( select c_personid from BIOG_MAIN where c_name_chn = '呂祖謙' ) )d on c.c_addr_type = d.c_addr_type group by d.c_name_chn,d.x_coord,d.y_coord,c.c_addr_desc_chn";
            DataSet ds = new DataSet();
            try
            {
                sh.RunSQL(sql, ref ds);
                dt = ds.Tables[0];
               // personnumber = dt.Rows.Count;
                foreach (DataRow dr in dt.Rows)
                {
                    //  jsstirng += string.Format(@"{name:{0}'', geoCoord:[{1}, {2}]},", dr["c_name_chn"].ToString(), dr["x_coord"].ToString(), dr["y_coord"].ToString());
                   jsstirng += string.Format(@"{{name:'{0}',geoCoord:[{1}, {2}]}},", dr["c_name_chn"].ToString(), dr["x_coord"].ToString(), dr["y_coord"].ToString());
                }
            }
            catch (Exception ex)
            {
                Response.Write("数据库出错");
            }
            finally
            {
                sh.Close();
            }
        }
    }
}