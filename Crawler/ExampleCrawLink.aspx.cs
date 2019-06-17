using Common.AITools.Tvbboy;

using System;

using System.Collections.Generic;

using System.Text.RegularExpressions;



namespace ProjectCrawler

{

    /// <summary>

    ///  这是爬取华东师范大学贴吧的范例，把贴吧地址赋值给它，它会爬取相应网页的超级链接地址和标题

    /// </summary>

    public partial class ExampleCrawLink : System.Web.UI.Page

    {

        protected void Page_Load(object sender, EventArgs e)

        {



        }

        /// <summary>

        /// 抓取超链接

        /// </summary>

        public void HrefCrawlerA(string goal,string pages)

        {
            //不需要有keyword
            var hrefList = new List<examplemyhref>();//定义泛型列表存放URL   

            string initurl = string.Format("https://tieba.baidu.com/f?kw={0}&ie=utf-8&tab=main&pn={1}",goal, pages);

            string result = string.Empty;

            var hrefCrawler = new SimpleCrawler();//调用爬虫程序

            hrefCrawler.url = new Uri(initurl);//定义爬虫入口URL      

            //Response.Write("爬虫开始抓取地址：" + hrefCrawler.url.ToString() + "</br>");

            hrefCrawler.OnError += (s, e) =>

            {

                Response.Write("爬虫抓取出现错误，异常消息：" + e.Exception.Message);

            };

            hrefCrawler.OnCompleted += (s, e) =>

            {

                //使用正则表达式清洗网页源代码中的数据
                //string e1 = e.PageSource;
                //e1=Regex.Replace(e.PageSource, "(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]", "");
                var links = Regex.Matches(e.PageSource, @"<a[^>]+href=""*(?<href>[^>\s]+)""\s*[^>]*>(?<text>(?!.*img).*?)</a>", RegexOptions.IgnoreCase);

                foreach (Match match in links)

                {

                    var h = new examplemyhref

                    {

                        hreftitle = match.Groups["text"].Value,

                        hrefsrc = match.Groups["href"].Value

                    };

                    if (!hrefList.Contains(h))

                    {

                        hrefList.Add(h);//将数据加入到泛型列表

                        result += h.hreftitle+"</br>";//将名称及URL显示到网页



                    }

                }

                //Response.Write("===============================================</br>");

                //Response.Write("爬虫抓取任务完成！合计 " + links.Count + " 个超级链接。</br>");

                //Response.Write("耗时：" + e.Milliseconds + "</br>毫秒");

                //Response.Write("线程：" + e.ThreadId + "</br>");

                Response.Write(result);

                //Response.Write("===============================================</br>");



            };

            hrefCrawler.start();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string goal = TextBox1.Text;
            string key = "";
            int p0 = 10;
            try
            { p0 = Int32.Parse(TextBox3.Text); }
            catch
            { p0 = 10; }            p0 = p0 * 50 - 50;
            string p = "0";
            for (int pages = 0; pages <= p0; pages = pages + 50)
            {
                p = pages.ToString();
                HrefCrawlerA(goal, p);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string goal = TextBox1.Text;
            string key = TextBox2.Text;
            int p0 = 10;
            try
            { p0 = Int32.Parse(TextBox3.Text); }
            catch
            { p0 = 10; }
            p0 = p0 * 50 - 50;
            string p = "0";
            string re = "";
            for (int pages = 0; pages <= p0; pages = pages + 50)
            {
                p = pages.ToString();
                re=re+HrefCrawlerB(goal, p,key);
            }
            if (!(re.Length == 0))
                Response.Write(re);
            else
                Response.Write("未找到信息！");
        }
        public string HrefCrawlerB(string goal, string pages,string key)

        {
            //需要keyword
            var hrefList = new List<examplemyhref>();//定义泛型列表存放URL   

            string initurl = string.Format("https://tieba.baidu.com/f?kw={0}&ie=utf-8&tab=main&pn={1}", goal, pages);

            string result = string.Empty;

            var hrefCrawler = new SimpleCrawler();//调用爬虫程序

            hrefCrawler.url = new Uri(initurl);//定义爬虫入口URL      

            //Response.Write("爬虫开始抓取地址：" + hrefCrawler.url.ToString() + "</br>");

            hrefCrawler.OnError += (s, e) =>

            {

                Response.Write("爬虫抓取出现错误，异常消息：" + e.Exception.Message);

            };

            hrefCrawler.OnCompleted += (s, e) =>

            {

                //使用正则表达式清洗网页源代码中的数据

                var links = Regex.Matches(e.PageSource, @"<a[^>]+href=""*(?<href>[^>\s]+)""\s*[^>]*>(?<text>(?!.*img).*?)</a>", RegexOptions.IgnoreCase);

                foreach (Match match in links)

                {
                    if (match.Groups["text"].Value.Contains(key))
                    {
                        var h = new examplemyhref

                        {

                            hreftitle = match.Groups["text"].Value,
                            hrefsrc = match.Groups["href"].Value

                        };

                        if (!hrefList.Contains(h))

                        {

                            hrefList.Add(h);//将数据加入到泛型列表

                            result += h.hreftitle + "|" + h.hrefsrc + "</br>";//将名称及URL显示到网页



                        }
                    }

                }

                //Response.Write("===============================================</br>");

                //Response.Write("爬虫抓取任务完成！合计 " + links.Count + " 个超级链接。</br>");

                //Response.Write("耗时：" + e.Milliseconds + "</br>毫秒");

                //Response.Write("线程：" + e.ThreadId + "</br>");





            };

            hrefCrawler.start();
            return result;
        }
    }

    public class examplemyhref

    {

        public string hreftitle { get; set; }

        public string hrefsrc { get; set; }

    }

}