private void Search(string url)
{
 string rl;
 WebRequest Request = WebRequest.Create(url.Trim());
 
 WebResponse Response = Request.GetResponse();
 
 Stream resStream = Response.GetResponseStream();
 
 StreamReader sr = new StreamReader(resStream, Encoding.Default);
 StringBuilder sb = new StringBuilder();
 while ((rl = sr.ReadLine()) != null)
 {
  sb.Append(rl);
 }
 
 
 string str = sb.ToString().ToLower();
 
 string str_get = mid(str, "<ul class=\"post_list\">", "</ul>");
 
 
 int start = 0;
 while (true)
 {
  if (str_get == null)
   break;
  string strResult = mid(str_get, "href=\"", "\"", out start);
  if (strResult == null)
   break;
  else
  {
   lab[url] += strResult;
   str_get = str_get.Substring(start);
  }
 }
}
 
 
 
 
private string mid(string istr, string startString, string endString)
{
 int iBodyStart = istr.IndexOf(startString, 0);    //开始位置
 if (iBodyStart == -1)
  return null;
 iBodyStart += startString.Length;       //第一次字符位置起的长度
 int iBodyEnd = istr.IndexOf(endString, iBodyStart);   //第二次字符在第一次字符位置起的首次位置
 if (iBodyEnd == -1)
  return null;
 iBodyEnd += endString.Length;        //第二次字符位置起的长度
 string strResult = istr.Substring(iBodyStart, iBodyEnd - iBodyStart - 1);
 return strResult;
}
 
 
private string mid(string istr, string startString, string endString, out int iBodyEnd)
{
 //初始化out参数,否则不能return
 iBodyEnd = 0;
 
 int iBodyStart = istr.IndexOf(startString, 0);    //开始位置
 if (iBodyStart == -1)
  return null;
 iBodyStart += startString.Length;       //第一次字符位置起的长度
 iBodyEnd = istr.IndexOf(endString, iBodyStart);   //第二次字符在第一次字符位置起的首次位置
 if (iBodyEnd == -1)
  return null;
 iBodyEnd += endString.Length;        //第二次字符位置起的长度
 string strResult = istr.Substring(iBodyStart, iBodyEnd - iBodyStart - 1);
 return strResult;
}