using System;

using System.Threading;

using System.Threading.Tasks;

class TestParallelInvoke

{

    static void Main(string[] args)

    {

        Action[] actions = { new Action(DoSometing), DoSometing };

        Parallel.Invoke( actions ); 

 

        Console.WriteLine("主函数所在线程"+Thread.CurrentThread.ManagedThreadId);

        Console.ReadKey();

    }

    static void DoSometing(){ 

        Console.WriteLine("函数所在线程"+Thread.CurrentThread.ManagedThreadId);

        Thread.Sleep(2000);

    }

}