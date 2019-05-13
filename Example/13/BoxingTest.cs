using System;
class Test
{
	static void Main() 
	{
		int i = 123;
		object obj = i;		// boxing
		int j = (int) obj;	// unboxing
		F( obj );
		F( i );
		F( 123);
		F( Color.Red );
		Point p = new Point( 10,10 );
		F( p );
		Console.WriteLine( 123.ToString());
	}

	static void  F(  object obj )
	{
		if( obj is int ) 
			Console.Write( "int:" );
		if( obj is System.Enum ) 
			Console.Write( "enum:" );
		if( obj is Point )
			Console.Write( "Point:" );
		Console.WriteLine( obj.ToString() );
	}

	enum Color 
	{
		Red, Green, Blue
	}

	struct Point 
	{
		public int x, y;
		public Point( int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		public override string ToString()
		{
			return "x="+x +", y=" + y;
		}
	}
}
