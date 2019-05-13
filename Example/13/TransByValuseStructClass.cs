using System;

struct AStruct
{
	public int x;
}

class BClass
{
	public int x;
}

class TransByValuseStructClass
{
	private static int a;
	public static void Main(string[] args) 
	{
		AStruct a  = new AStruct();
		modify (a); 
		Console.WriteLine(a.x);//Êä³ö0

		BClass b = new BClass();
		modify(b);
		Console.WriteLine(b.x); //Êä³ö1
	}

	public static void modify (AStruct a) 
	{
		a.x++;
	}
	public static void modify (BClass b) 
	{
		b.x ++;
		b = new BClass();
	}
}
