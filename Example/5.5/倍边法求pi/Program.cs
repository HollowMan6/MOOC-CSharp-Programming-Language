using System;
class TestDebugPi
{
    static void Main(){
        double a=1;
        for(int n=1; n<=10; n++ )
        {
            a = Math.Sqrt(2 - Math.Sqrt(4 - a * a));
            double pi = a * 3 * Math.Pow(2,n);
            Console.WriteLine( pi );
        }
        Console.WriteLine( Math.PI );
          
        //请调试:如果n<=100,如何?
    }
}