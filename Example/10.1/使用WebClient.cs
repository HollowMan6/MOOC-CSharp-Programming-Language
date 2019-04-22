using System;

using System.Net;

using System.Text;

class Test

{

    static void Main()

    {

        string url = @"https://localhost/test.html";

        WebClient client = new WebClient();

        byte[] pageData = client.DownloadData(url);

        string pageHtml = Encoding.Default.GetString(pageData);

        Console.WriteLine(pageHtml);

    }