using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JiebaNet.Segmenter;

namespace WordSegmenter
{
    public partial class Try : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var segmenter = new JiebaSegmenter();
            var seg = segmenter.Cut("我来自华东师范大学", cutAll: true);
            Response.Write(string.Format("[全模式]：{0}</br>", string.Join("/", seg)));
            seg = segmenter.Cut("我来自华东师范大学");//默认为精确模式,同时使用HMM模型
            Response.Write(string.Format("[精确模式]：{0}</br>", string.Join("/", seg)));
            seg = segmenter.Cut("他来到了华东师范大学群贤堂");
            Response.Write(string.Format("[新词识别]:{0}</br>", string.Join("/", seg)));
            seg = segmenter.CutForSearch("李白硕士毕业于东方大学计算所，后在日本京都大学深造");
            Response.Write(string.Format("[搜索引擎模式]:{0}</br>", string.Join("/", seg)));
            seg = segmenter.Cut("结过婚的和尚结过婚的");
            Response.Write(string.Format("[歧义消除]:{0}</br>", string.Join("/", seg)));
        }
    }
}