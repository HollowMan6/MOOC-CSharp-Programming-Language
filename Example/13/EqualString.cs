using System;
class EqualString
{
	public static void Main(string[] args) 
	{
		string s1 = "Test";
		string s2 = "Test";
		string s3 = string.Copy( s2 );

		Console.WriteLine( s1 == s2 ); //True
		Console.WriteLine( s2 == s3 ); //Truse
		Console.WriteLine( (object)s1 == s2 );  // True
		Console.WriteLine( (object) s2 == s3 ); // False
	}
}
