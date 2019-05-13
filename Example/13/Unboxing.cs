using System;
class Test
{
	static void Main()
	{
		int i = 123;
		F( (object) i );
	}
	static void F( object obj)
	{
		if( obj is int )
		{
			int x = (int)obj;
			Console.WriteLine( x );
		}
	}
}