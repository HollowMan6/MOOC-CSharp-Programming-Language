using System;

using System.Threading;

using System.Threading.Tasks;

class T

{

    static void Main(string[] args)

    {

 

        Parallel.For(0, 10, i =>

        {

            Console.WriteLine("i={0}, fac={1}, 线程id={2}",

                i, Calc(i),

                Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(10);

        });

        Console.ReadLine();

    }

    static double Calc(int n)

    {

        double f = 1;

        for(int i=1; i<=n; i++ ) f*=i;

        return f;

    }

}