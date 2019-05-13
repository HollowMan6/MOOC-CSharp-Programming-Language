using System;
class A{}
class B:A
{
	int i;
	public B( int i )
	{
		this.i = i;
	}
}
class Test
{
	static void Main() 
	{
		A obj1 = new A();
		A obj2 = new B(3);
		A obj3 = new B(3);
		B obj4 = (B) obj3;
		Console.WriteLine( obj1 == obj2 );
		Console.WriteLine( obj2 == obj3 );
		Console.WriteLine( obj3 == obj4 );
	}
}
