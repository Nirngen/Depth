using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JiebaNet.Segmenter;
using System.IO;
using JiebaNet;
using System.Linq;
using System.Diagnostics;
//强调，反复生成至同一个json不会覆盖，而是新增

namespace WordSegmenter
{
    public partial class KindomCut : System.Web.UI.Page
    {
        string content = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string ReadData(string filepath)
        {
            //试图读取电脑中的文件
            System.Text.Encoding code = System.Text.Encoding.GetEncoding("gb2312");
            //gb2312 or utf-8,两种编码
            FileStream fs = new FileStream(Server.MapPath(filepath), FileMode.Open, FileAccess.Read);
            //仅对文本执行读写
            StreamReader sr = new StreamReader(fs, code);
            //定位操作点,begin是一个参考点
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            //判断文件是否为空
            string str = sr.ReadToEnd();
            //关闭文件，从内向外关
            sr.Close();
            fs.Close();
            return str;
        }
        public int GetFrequence(IEnumerable<string> content, string specficword) { int ret = 0; foreach (string item in content) { if (item == specficword) ret++; } return ret; }
        string[] DelRepeatData(string[] a) { return a.GroupBy(p => p).Select(p => p.Key).ToArray(); }
        public void WriteData(string filePath, string fileContent)
        {
            string aimfilepath = MapPath(filePath);
            using (FileStream fs = new FileStream(aimfilepath, FileMode.OpenOrCreate))
            {
                StreamWriter sw = new StreamWriter(fs); sw.Write(fileContent);
                sw.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string text = TextBox1.Text;
            var segmenter = new JiebaSegmenter();
            string aimFile = string.Format(@"./Resources/{0}.txt", text);
            string content = GetContent(aimFile);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var wordsforSearch = segmenter.CutForSearch(content);
            Dictionary<string, int> persons = new Dictionary<string, int>();
            string jsonstr = "[";
            int i = 0;
            foreach (string item in wordsforSearch.Distinct<string>())
            {
                if (item.Length >= 2 && item.Length <= 4)
                {
                    if (!persons.ContainsKey(item))
                    {
                        int f = GetFrequence(wordsforSearch, item);
                        persons.Add(item.Trim(), f);
                        if (f >= 20 && f != 2406)
                        {
                            if (i == 0)
                                jsonstr += "{\"name\":\"" + item.Trim() + "\",\"value\":" + f + "}";
                            else
                                jsonstr += ",{\"name\":\"" + item.Trim() + "\",\"value\":" + f + "}";
                            i++;
                        }
                    }
                }
            }
            jsonstr += "]";
            string name = TextBox2.Text;
            GetJson(name, jsonstr);
            persons = (from entry in persons orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
            string result = ""; foreach (var person in persons) { if (person.Value >= 20) result += ("<br>" + person.Key + "-" + person.Value.ToString()); }
            Response.Write(result); sw.Stop(); TimeSpan ts2 = sw.Elapsed; Response.Write(string.Format("</br>Stopwatch 总共花费{0}ms.", ts2.TotalMilliseconds.ToString()));
            if (!(content == ""))
                Response.Write(string.Format("</br>"+"结果已输出至{0}.json"+"</br>",name));
        }
        protected string GetContent(string aimFile)
        {
            string content = "";
            try
            {
                content = ReadData(aimFile);
            }
            catch
            {
                Response.Write("文件不存在");
                content = "";
            }
            return content;
        }
        protected void GetJson(string name,string jsonstr)
        {
            if (name.Length == 0)
                name = "story";
            string a = string.Format("{0}.json", name);
            WriteData(a, jsonstr);
        }
    }
}