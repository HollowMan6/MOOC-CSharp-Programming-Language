using System;

class Test
{
	static void Main()
	{
		object o;
		o = 123;
		o = new Test();
		o = new int[]{ 1,2,3 };
		string s = 123.ToString();
		int n = "abcdef".Length;
		char c = "abcdef"[3];
	}
}
