using System;
public class TransByValue 
{
	private static int a;
	public static void Main(string[] args) 
	{
		int a = 0;
		modify (a); 
		Console.WriteLine(a);//Êä³ö0

		int [] b = new int [1];
		modify(b);
		Console.WriteLine(b[0]); //Êä³ö1
	}

	public static void modify (int a) 
	{
		a++;
	}
	public static void modify (int[] b) 
	{
		b[0] ++;
		b = new int[5];
	}
}
