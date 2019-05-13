using System;
class A 
{
}

class B :A
{
	public void M(){
		Console.WriteLine (" B.M() is Called " );
	}
}

class C 
{
}

public class IsTest 
{
	public static void Test (object obj) 
	{
		if( obj is B)
		{
			B b = (B) obj;
			b.M();
		}
		else
		{
			Console.WriteLine (obj.GetType() + " is Not B");
		}
	}

	public static void Main()
	{
		A a = new A();
		Test( a );
		a = new B();
		Test( a );

		C c = new C();
		Test( c );
	}
}
