using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;

namespace Database
{
    public partial class Try : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLHelper sh = new SQLHelper();
            string c = "select count(*) from BIOG_MAIN";
            try
            {
                sh.RunSQL(c);
                Response.Write("Success!");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                sh.Close();
            }
        }
    }
}