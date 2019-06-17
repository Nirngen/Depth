using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;
using System.Collections;
using Common.AITools.Tvbboy;
using System.Data;

namespace Database
{
    public partial class NewDijkstra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //sqlddl1,sqlddl2,dsddl,dsddl1,shddl,shddl1
            SQLHelper shddl = new SQLHelper();
            string sqlddl1 = "select PointA from students.dbo.tblDistance group by PointA";
            DataSet dsddl = new DataSet();
            shddl.RunSQL(sqlddl1, ref dsddl);
            if (!IsPostBack)
            {
                ddl1.DataSource = dsddl.Tables[0];
                ddl1.DataTextField = "PointA";
                ddl1.DataBind();
            }
            shddl.Close();
            SQLHelper shddl1 = new SQLHelper();
            DataSet dsddl1 = new DataSet();
            string sqlddl2 = "select PointB from students.dbo.tblDistance group by PointB";
            shddl1.RunSQL(sqlddl2, ref dsddl1);
            if (!IsPostBack)
            {
                ddl2.DataSource = dsddl1.Tables[0];
                ddl2.DataTextField = "PointB";
                ddl2.DataBind();
            }
            shddl1.Close();
        }
        private void printRouteResult(RoutePlanResult _result)
        {
            Response.Write("</br>路径:");
            string[] tmp = _result.getPassedNodeIDs();
            for (int i = 0; i < tmp.Length; i++)
                Response.Write(tmp[i] + "-->");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //需要四个sql，sh，ds，dt，row
            string sqla1, sqla2, sqlb1, sqlb2;
            string ca = "";
            string cb = "";
            string start = ddl1.SelectedValue;
            string end = ddl2.SelectedValue;
            SQLHelper sha1 = new SQLHelper();
            SQLHelper sha2 = new SQLHelper();
            SQLHelper shb1 = new SQLHelper();
            SQLHelper shb2 = new SQLHelper();
            DataSet dsa1 = new DataSet();
            DataSet dsb1 = new DataSet();
            DataTable dta1, dta2, dtb1, dtb2;
            DataRow[] ra1, ra2, rb1, rb2;
            ArrayList nodeList = new ArrayList();
            //思路：遍历A，对A的每一个城市，遍历所有路径；然后遍历B中不在A中的城市，同样遍历路径
            //介于debug次数过多，把快捷的debug方法写在这里提醒自己：通过response.write监视nodelist的录入
            sqla1 = "select PointA from students.dbo.tblDistance group by PointA";
            sha1.RunSQL(sqla1, ref dsa1);
            dta1 = dsa1.Tables[0];
            ra1 = dta1.Select("PointA is not null");
            sha1.Close();
            for (int i = 0; i <= dta1.Rows.Count - 1; i++)
            {
                ca = ra1[i]["PointA"].ToString();
                Node a = new Node(ca);
                nodeList.Add(a);
                DataSet dsa2 = new DataSet();
                //dsa2、dsb2一定要在for循环内反复声明，以清空set内存；否则，新ref到的数据会加入到Tables[0]中而非替换之
                sqla2 = string.Format("select PointA,PointB,Distance from students.dbo.tblDistance where PointA='{0}' group by PointA,PointB,Distance", ca);
                sha2.RunSQL(sqla2, ref dsa2);
                dta2 = dsa2.Tables[0];
                ra2 = dta2.Select("PointA is not null");
                sha2.Close();
                for (int j = 0; j <= dta2.Rows.Count - 1; j++)
                {
                    cb = ra2[j]["PointB"].ToString();
                    a.EdgeList.Add(new Edge(ca, cb, double.Parse(ra2[j]["Distance"].ToString())));
                }
            }
            sqlb1 = "select PointB from (select PointB from students.dbo.tblDistance group by PointB)B left join (select PointA from students.dbo.tblDistance group by PointA)A on A.PointA=B.PointB where PointA is null";
            shb1.RunSQL(sqlb1, ref dsb1);
            dtb1 = dsb1.Tables[0];
            rb1 = dtb1.Select("PointB is not null");
            shb1.Close();
            for (int i = 0; i <= dtb1.Rows.Count - 1; i++)
            {
                cb = rb1[i]["PointB"].ToString();
                DataSet dsb2 = new DataSet();
                sqlb2 = string.Format("select PointA,PointB,Distance from students.dbo.tblDistance where PointB='{0}' group by PointA,PointB,Distance", cb);
                shb2.RunSQL(sqlb2, ref dsb2);
                dtb2 = dsb2.Tables[0];
                rb2 = dtb2.Select("PointB is not null");
                shb2.Close();
                Node b = new Node(cb);
                nodeList.Add(b);
                for (int j = 0; j <= dtb2.Rows.Count - 1; j++)
                {
                    ca = rb2[j]["PointA"].ToString();
                    b.EdgeList.Add(new Edge(cb, ca, double.Parse(rb2[j]["Distance"].ToString())));
                }
            }
            RoutePlanner planner = new RoutePlanner();
            RoutePlanResult result = null;
            if (start == end)
            {
                Response.Write("距离为0");
            }
            else
            {
                result = planner.Paln(nodeList, start, end);
                if (result.getWeight() > 100000000)
                    Response.Write("两地无通路！");
                else
                {
                    Response.Write("距离为" + result.getWeight());
                    printRouteResult(result);
                    Response.Write(end + "</br>");
                    planner = null;
                }
            }
        }
    }
}