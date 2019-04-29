using System;

using System.Threading;

public class ThreadJoin {

    public static void Main(string [] args) {

        Runner r = new Runner();

        Thread thread = new Thread(  r.run );

        thread.Start();

 

        thread.Join();

 

        for( int i=0; i<10; i++ ){

            Console.WriteLine("\t" + i );

            Thread.Sleep(100);

        }

    }

}

 

class Runner {

    public void run() {

        for( int i=0; i<10; i++ ){

            Console.WriteLine( i );

            Thread.Sleep(100);

        }

    }

}