using System;
public class Fac
{
    public static void Main(string [] args)
    {
        Console.WriteLine("Fac of 5 is " + fac( 5) );
    }
    static long fac( int n ){
        if( n==0 || n==1) return 1;
        else return fac(n-1) * n;
    }
}