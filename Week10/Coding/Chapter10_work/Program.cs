using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Chapter10_work
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("请输入网址：")               ;
            //string url = Console.ReadLine();
            string url = "https://hao.360.com";
            Spiders spider = new Spiders();
            string readstr = spider.Climb(url);  //返回url爬取的网页code

            //Console.WriteLine(readstr);

            List<Url> urllist = spider.GainURL(readstr);    //分析出readstr中的URL
            //将所有URL下载下来
            int a = 0,//无效网址数
                b = 0;//下载成功网址数
            foreach (var item in urllist)
            {

                //Console.WriteLine(item.key);
                if (item.isDownload == false)
                {
                    string ss = spider.Climb(item.key);
                    if (ss=="")
                    {
                        a++;
                        //continue;//无效URL则跳过，}
                    }
                    else
                    {
                        item.information = ss;
                        item.isDownload = true;
                        b++;
                    }

                }
                Console.WriteLine("\n=====已爬成功：" + a + "\t无效URL：" + b + "\t已进行：" + (a + b) + "/" + urllist.Count + "============\n");

            }


            Console.WriteLine("\n============所有URL爬行完毕============\n");



            Console.ReadLine();


        }
    }

    class Spiders
    {
        public string Climb(String url)
        {
            string readerStr;
            Console.WriteLine("\n============" + url + "  网页爬取ing……============\n");
            try
            {
                WebRequest request = WebRequest.Create(url);

                WebResponse response = (WebResponse)request.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream, Encoding.UTF8);

                readerStr = reader.ReadToEnd();

                //Console.WriteLine(readerStr);//输出网页源码
            }
            catch
            {
                Console.WriteLine("\n==================URL异常！==================\n");
                return "";
            }
            Console.WriteLine("\n==================网页爬取完毕！==================\n");
            return readerStr;
        }

        //网页链接形式 ： href="http       "
        //从爬取的网页获取所有网页的URL添加到列表
        public List<Url> GainURL(string readerStr)
        {
            Console.WriteLine("\n===============网页中的URL解析ing===============\n");

            List<Url> urlList = new List<Url>();//存放网页中的所有链接

            //Regex rgx = new Regex(@"");
            //Regex rgx = new Regex(@"<a[^>]+href=""(?<href>[\S]+?)""[^>]*>(?<text>[\S]+?)</a>");
            Regex rgx = new Regex(@"(href|HREF|src|SRC)[ ]*=[ ]*[""'][^""'#>]+[""']");
            MatchCollection mc = rgx.Matches(readerStr);
            //将所有匹配项（URL），存放到list中
            foreach (Match match in mc)
            {
                //Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);

                string strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\'', '#', ' ', '>');
                if (strRef.Length == 0) continue;
                Console.WriteLine(strRef);
                urlList.Add(new Url(strRef));
            }
            Console.WriteLine("\n     网页中的URL共有：" + mc.Count + "\n");
            Console.WriteLine("\n=================网页中的URL解析完毕=================\n");
            return urlList;

        }

        public Spiders()
        {
        }
    }

    class Url
    {
        //存放该网页网址
        public string key { get; }
        //标记该网站是否爬取信息
        public bool isDownload { get; set; }
        //存放该网址爬取的代码信息
        public string information { get; set; }
        public Url(string key)
        {
            this.key = key;
            this.isDownload = false;
        }

    }
}
