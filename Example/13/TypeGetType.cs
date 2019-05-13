using System;
class TypeGetType
{
	static void Main() 
	{
		int x = 1;
		double d = 1.0;
		Type[] t = 
		{
			typeof(int),
			typeof(System.Int32),
			typeof(string),
			typeof(double[]),
			x.GetType(),
			(x+d).GetType(),
			Type.GetType( "System.Console" ),

		};
		for (int i = 0; i < t.Length; i++) 
		{
			Console.WriteLine(t[i]);
		}
	}
}
