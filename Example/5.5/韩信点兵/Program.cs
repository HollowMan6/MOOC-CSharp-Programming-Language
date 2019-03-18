using System;
class HanXin
{
    static void Main()
    {
        for( int n=1; n<=105; n++ )
        {
            if( n%3==2 && n%5==3 && n%7==5 )
                Console.WriteLine(n);
        }
    }
}