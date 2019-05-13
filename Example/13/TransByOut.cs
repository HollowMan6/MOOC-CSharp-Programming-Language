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
		AStruct a ;
		modify ( out a ); 
		Console.WriteLine(a.x);//Êä³ö1

		BClass b ;
		modify( out b );
		Console.WriteLine(b.x); //Êä³ö1
	}

	public static void modify (out AStruct a) 
	{
		a = new AStruct();
		a.x++;
	}
	public static void modify (out BClass b) 
	{
		b = new BClass();
		b.x ++;
	}
}
