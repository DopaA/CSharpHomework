using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;

namespace apdo_homework_9
{  
    public class SimpleCrawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        private string current = null;
        static void Main(string [] args)
        {
            SimpleCrawler myCrawler = new SimpleCrawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];

            myCrawler.urls.Add(startUrl, false);//加入初始界面

            new Thread(myCrawler.Crawl).Start();
            Console.ReadLine();
        }
        private void Crawl()
        {
            //先将url存储下来
            List<string> urlst = new List<string>();
            List<string> htmls = new List<string>();
            for(int i = 0; i < 10; i++)
            {
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }
                if (current == null) continue;
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = GetHtml(current);
                htmls.Add(html);
                urlst.Add(current);
                urls[current] = true;
                Parse(html);
            }
            Console.WriteLine("开始爬行了....");
            Parallel.For(0, 10, i =>
              {
                  string current = urlst[i];
                  Console.WriteLine("爬行" + current + "页面!");
                  Download(htmls[i],i);
              });
            Console.WriteLine("爬行结束");
        }
 
        public string  GetHtml(string current)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(current);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Download(string html,int i)
        {
               count = i;
                string filename = count.ToString();
                File.WriteAllText(filename,html, Encoding.UTF8);
        }
        public void  Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach(Match match in matches)
            {
                strRef=match.Value.Substring(match.Value.IndexOf('=')+1).Trim('"','\"','#',' ','>');
                    if(strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
