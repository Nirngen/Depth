using Common.AITools.Tvbboy;

using System;

using System.Collections.Generic;

using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.IO;
using System.Net;



namespace ProjectCrawler

{

    /// <summary>

    /// 该程序是抓取网页图片的范例程序



    /// </summary>

    public partial class ExampleCrawlerImg : System.Web.UI.Page

    {

        protected void Page_Load(object sender, EventArgs e)

        {

            //1.抓取图片
            for(int n=1;n<=12;n++)
                IMGCrawler(n);



        }

        /// <summary>

        /// 抓取图片

        /// </summary>

        public void IMGCrawler(int num)

        {
            //需要download图片时，图片在网页中爬下来的路径是虚拟路径，需要变成实际路径才行
            List<string> imglist = new List<string>();
            string initurl = string.Format("http://www.hr.ecnu.edu.cn/s/116/t/209/p/1/c/3538/d/7465/i/{0}/list.htm", num);

            string result = string.Empty;

            var imgCrawler = new SimpleCrawler();//调用爬虫程序

            imgCrawler.url = new Uri(initurl);//定义爬虫入口URL      

            Response.Write("爬虫开始抓取地址：" + imgCrawler.url.ToString() + "</br>");

            imgCrawler.OnError += (s, e) =>

            {

                Response.Write("爬虫抓取出现错误，异常消息：" + e.Exception.Message);

            };

            imgCrawler.OnCompleted += (s, e) =>

            {

                //使用正则表达式清洗网页源代码中的数据

                string pattern = @"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>";



                var imgs = Regex.Matches(e.PageSource, pattern, RegexOptions.IgnoreCase);

                foreach (Match match in imgs)

                {

                    if (!imglist.Contains("http://www.hr.ecnu.edu.cn/"+match.Groups["imgUrl"].Value))

                    {

                        imglist.Add("http://www.hr.ecnu.edu.cn/" + match.Groups["imgUrl"].Value);//将数据加入到泛型列表
                        downloadImage(@"http://www.hr.ecnu.edu.cn/" + match.Groups["imgUrl"].Value, "~/img/");
                        //注意地址的前缀;要实现对图片的下载，需要有http：//
                        result += "http://www.hr.ecnu.edu.cn/" + match.Groups["imgUrl"].Value + "|<img width='50',height='50' src='"+ "http://www.hr.ecnu.edu.cn/" + match.Groups["imgUrl"].Value + "'></br>";//将名称及URL显示到网页

                    }

                }

                Response.Write("===============================================</br>");

                Response.Write("爬虫抓取任务完成！合计 " + imgs.Count + " 个图片。</br>");

                Response.Write("耗时：" + e.Milliseconds + "</br>毫秒");

                Response.Write("线程：" + e.ThreadId + "</br>");

                Response.Write(result);

                Response.Write("===============================================</br>");



            };



            imgCrawler.start();



        }
        public void downloadImage(string url, string VirtuleFolder)
        { try
            {
                string LocalFolder = Server.MapPath(VirtuleFolder);
                string ext = string.Empty;
                ext = url.Substring(url.Length - 3, 3);
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + ext;
                WebClient my = new WebClient();
                byte[] mybyte;
                mybyte = my.DownloadData(url);
                MemoryStream ms = new MemoryStream(mybyte);
                System.Drawing.Image img;
                img = System.Drawing.Image.FromStream(ms);
                switch (ext.ToLower())
                { case "gif": img.Save(Path.Combine(LocalFolder, filename), ImageFormat.Gif);
                        break;
                    case "png": img.Save(Path.Combine(LocalFolder, filename), ImageFormat.Png);
                        break;
                    case "jpeg":
                    case "jpg": img.Save(Path.Combine(LocalFolder, filename), ImageFormat.Jpeg);
                        break;
                }
            }
            catch (Exception ex)
            { Response.Write("----------------下载图片发生错误-----------------------------</br>");
                Response.Write("错误内容：</br>" + ex.Message);
            }
        }



    }



}