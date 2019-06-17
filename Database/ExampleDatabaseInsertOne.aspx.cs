using SQL;
using System;
using System.Data.SqlClient;
namespace ProjectAlgorithm
{
    /// <summary>
    /// 数据库如何读取单个记录的内容
    /// </summary>
    public partial class ExampleDatabaseInsertOne : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {                      
        }
       

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string studentNo = txtStudentNo.Text;
            string studentName = txtStudentName.Text;
            int Gender=0 ;
            if (ridMale.Checked)
                Gender =1;
            if (ridFemale.Checked)
                Gender = 0;
            string Major = ddlMajor.SelectedValue;
            DateTime Birthday = Calendar1.SelectedDate;
            string sql1 = string.Format("insert into tblstudents (studentNo,studentName,gender,Major,Birthday)values('{0}','{1}',{2},'{3}','{4}')", studentNo, studentName, Gender, Major, Birthday);
            string sql = "select studentNo from tblStudents";
            bool a = false;
            SqlDataReader sdr;
            SQLHelper sh = new SQLHelper();
            sh.RunSQL(sql, out sdr);
            while (sdr.Read())
            {
                if (sdr["studentNo"].ToString() == studentNo)
                {
                    a = true;
                    break;
                }
                //必须是sdr.tostring才能比较相等,不加tostring则无效
            }
            if (a)
            {
                Response.Write("学号已存在");
                sh.Close();
                sdr.Close();
            }
            else
            {
                SQLHelper sh1 = new SQLHelper();

                try
                {
                    //返回影响的行数，所以插入成功会返回1
                    int ret = sh1.RunSQL(sql1);

                    if (ret > 0)
                    {
                        Response.Write("插入成功");
                    }
                    else
                    {
                        Response.Write("插入失败");
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("SQL语句:" + sql1 + "<br>");
                    Response.Write("插入异常:" + ex.Message);
                }
                finally
                {

                    sh.Close();
                    sdr.Close();
                    sh1.Close();
                }
            }
        }
    }
}