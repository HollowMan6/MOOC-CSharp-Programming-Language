using System;

struct AStruct
{
	public int x;
}

class BClass
{
	public int x;
}

class TransByRef
{
	private static int a;
	public static void Main(string[] args) 
	{
		AStruct a  = new AStruct();
		modify ( ref a ); 
		Console.WriteLine(a.x);//Êä³ö1

		BClass b = new BClass();
		modify( ref b );
		Console.WriteLine(b.x); //Êä³ö0
	}

	public static void modify (ref AStruct a) 
	{
		a.x++;
	}
	public static void modify (ref BClass b) 
	{
		b.x ++;
		b = new BClass();
	}
}
