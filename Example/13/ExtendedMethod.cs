using System;
public static class MyExt
{
	public static bool IsLonger(this string str, int n)
	{ 
		return str!=null && str.Length>n; 
	}
}

class T
{
	static void Main()
	{
		string a = "abc";
		Console.WriteLine( a.IsLonger(2) );
	}
}