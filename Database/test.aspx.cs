using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Common.AITools.Tvbboy;

namespace Database
{
    public partial class test : System.Web.UI.Page
    {
        private void printRouteResult(RoutePlanResult _result)
        {
            Response.Write("</br>路径:");
            //获取最短路径结果中，所有的节点
            string[] tmp = _result.getPassedNodeIDs();
            for (int i = 0; i < tmp.Length; i++)
                Response.Write(tmp[i] + "-->");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList nodeList = new ArrayList();
            Node a = new Node("A");
            nodeList.Add(a);
            a = new Node("A");
            nodeList.Add(a);
            a.EdgeList.Add(new Edge("A", "B", 1));
            a = new Node("B");
            nodeList.Add(a);
            a.EdgeList.Add(new Edge("B", "C", 1));
            a = new Node("A");
            nodeList.Add(a);
            a.EdgeList.Add(new Edge("A", "B", 1));
            a = new Node("C");
            nodeList.Add(a);

            RoutePlanner planner = new RoutePlanner();
            RoutePlanResult result = null;
            //Paln 函数是核心函数，首先将所有节点喂给模型，然后输入起点和终点，返回最优路径
            result = planner.Paln(nodeList, "A", "C");
            Response.Write("距离为" + result.getWeight());
            printRouteResult(result);
            Response.Write("C");
            //Response.Write("上海");
            //Response.Write("<br>");
            planner = null;
            //***************** A Node 北京 ******************* 
            //Node aNode = new Node("北京");
            //nodeList.Add(aNode);
            //aNode.EdgeList.Add(new Edge("北京", "上海", 20));
            //aNode.EdgeList.Add(new Edge("北京", "武汉", 40));
        }
    }
}