using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Windows.Forms;

 

using System.Threading;

using System.Threading.Tasks;

using System.IO;

 

public class AsyncStream

{

    async Task<int> WriteFile()

    {

        using (StreamWriter sw = new StreamWriter(

            new FileStream("aaa.txt", FileMode.Create) ))

        {

            await sw.WriteAsync("my text");

            return 1;

        }

    }

    async static void Test()

    {

        AsyncStream a = new AsyncStream();

        await a.WriteFile();

        Console.WriteLine("Write OK");

    }

    static void Main()

    {

        Test();

    }

}