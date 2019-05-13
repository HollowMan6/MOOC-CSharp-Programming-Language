using System;
class ParamsTest
{
	static double Multi( params double [] nums )
	{
		double result = 1.0;
		foreach( double a in nums )
			result *= a;
		Console.WriteLine( result );
		return result;
	}

	static void Main()
	{
		Multi();
		Multi( 27 );
		Multi( 3.14, 0.9, 0.9 );
		Multi( 1,2,3,4,5);
		Multi( new double [] {1,2,3,4,5}  );
	}
}
