using System;
class Jiaogu 
{
    public static void Main(string[] args) 
    {
        for( int n=1; n<=100; n++ )
        {
            int a = n;
            while( a != 1 )
            {
                Console.Write( " " +a );
                if( a%2==1 ) a = a*3+1; else a /= 2;
            }
            Console.WriteLine(" " +a);
        }
    }
}