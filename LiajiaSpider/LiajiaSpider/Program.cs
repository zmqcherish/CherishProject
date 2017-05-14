using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LiajiaSpider
{
    class Program
    {
        static string ershoufangPath = "ershoufang.csv";
        static void Main(string[] args)
        {
            if (!File.Exists(ershoufangPath))
            {
                using (StreamWriter sw = File.CreateText(ershoufangPath))
                {
                    //sw.WriteLine("Hello");
                }
            }
            ershoufang();
            Console.WriteLine("处理完成");
        }

        static HashSet<string> idSet = new HashSet<string>();
        private static void ershoufang()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"正在处理第{i}页......");
                string url = $"http://cd.lianjia.com/ershoufang/pg{i}/";
                handlePage(url);
            }
        }

        private static void handlePage(string url,int tryTime = 3)
        {
            if (tryTime == 0)
                return;
            try
            {
                string html = GetWebHtml(url);
                var parser = new HtmlParser();
                var document = parser.Parse(html);
                var lis = document.QuerySelectorAll("li.clear");
                using (StreamWriter sw = File.AppendText(ershoufangPath))
                {
                    foreach (var li in lis)
                    {
                        var id = li.QuerySelector("a").GetAttribute("href");
                        int left = id.LastIndexOf("/") + 1;
                        int right = id.LastIndexOf(".");
                        id = id.Substring(left, right - left);
                        if (idSet.Contains(id))
                            continue;
                        idSet.Add(id);

                        var div = li.QuerySelector("div");

                        string title = div.QuerySelector("div.title").TextContent;

                        var houseInfo = div.QuerySelector("div.address").QuerySelector("div").TextContent.Split('|');
                        string region = houseInfo[0].Trim();
                        string rooms = houseInfo[1].Trim();
                        string size = houseInfo[2].Trim();
                        string toward = houseInfo[3].Trim();
                        string decorate = houseInfo[4].Trim();
                        string hasLift = houseInfo.Length == 6 ? "有电梯" : "";

                        var priceInfo = div.QuerySelector("div.priceInfo");
                        string totalPrice = priceInfo.QuerySelector("div.totalPrice").TextContent;
                        string unitPrice = priceInfo.QuerySelector("div.unitPrice").TextContent;

                        string followInfo = div.QuerySelector("div.followInfo").TextContent;

                        string flood = div.QuerySelector("div.flood").TextContent;

                        sw.WriteLine($"{id},{title},{totalPrice},{unitPrice},{region},{rooms},{size},{toward},{decorate},{hasLift},{flood}");
                    }
                }

                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                handlePage(url, tryTime - 1);
            }
        }

        private static string GetWebHtml(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            request.UserAgent = usgeAgents[r.Next(usgeAgents.Length)];

            var encoding = Encoding.UTF8;//根据网站的编码自定义  
            var response = (HttpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();
            var streamReader = new StreamReader(responseStream, encoding);
            string res = streamReader.ReadToEnd();

            streamReader.Close();
            responseStream.Close();
            return res;
        }

        static string[] usgeAgents = new string[] { "User-Agent:Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.6) Gecko/20091201 Firefox/3.5.6",
    "User-Agent:Mozilla/5.0 (Windows NT 6.2) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.12 Safari/535.11",
    "User-Agent:Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)",
    "User-Agent:Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:34.0) Gecko/20100101 Firefox/34.0",
    "User-Agent:Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Ubuntu Chromium/44.0.2403.89 Chrome/44.0.2403.89 Safari/537.36",
    "User-Agent:Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_6_8; en-us) AppleWebKit/534.50 (KHTML, like Gecko) Version/5.1 Safari/534.50",
    "User-Agent:Mozilla/5.0 (Windows; U; Windows NT 6.1; en-us) AppleWebKit/534.50 (KHTML, like Gecko) Version/5.1 Safari/534.50",
    "User-Agent:Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0",
    "User-Agent:Mozilla/5.0 (Macintosh; Intel Mac OS X 10.6; rv:2.0.1) Gecko/20100101 Firefox/4.0.1",
    "User-Agent:Mozilla/5.0 (Windows NT 6.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1",
    "User-Agent:Mozilla/5.0 (Macintosh; Intel Mac OS X 10_7_0) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11",
    "User-Agent:Opera/9.80 (Macintosh; Intel Mac OS X 10.6.8; U; en) Presto/2.8.131 Version/11.11",
    "User-Agent:Opera/9.80 (Windows NT 6.1; U; en) Presto/2.8.131 Version/11.11"};

        static Random r = new Random();
    }
}
