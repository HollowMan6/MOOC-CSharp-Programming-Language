using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using System.Net.Http; //要在项目中添加引用System.Net.Http

namespace AsyncUseHttpClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("BeforeGet" + Thread.CurrentThread.ManagedThreadId);
            this.textBox2.Text = "";
            string url = textBox1.Text.Trim();
            string content = await AccessTheWebAsync(url);
            this.textBox2.Text = content;
            Console.WriteLine("AfterGet" + Thread.CurrentThread.ManagedThreadId);

            Test();
        }

        // 在签名中三个要注意的事项: 
        //  - 该方法具有一个async修饰符.  
        //  - 返回类型为 Task or Task<t>. (参考 "返回类型" 一节.)
        //    这里, 返回值是 Task<int> 因为返回的是一个整数类型. 
        //  - 这个方法的名称以 "Async" 结尾.
        async Task<string> AccessTheWebAsync(string url)
        {
            // 你需要添加System.Net.Http的引用来声明client
            HttpClient client = new HttpClient();

            // GetStringAsync 返回 Task<string>. 这意味着当Task结束等待之后 
            // 你将得到一个string (urlContents).
            Task<string> getStringTask = client.GetStringAsync(url);

            // 你可以做一些不依赖于 GetStringAsync 返回值的操作.
            DoIndependentWork();

            // await 操作挂起了当前方法AccessTheWebAsync. 
            //  - AccessTheWebAsync 直到getStringTask完成后才会继续. 
            //  - 同时, 控制权将返回 AccessTheWebAsync 的调用者. 
            //  - 控制权会在getStringTask完成后归还到AccessTheAsync.  
            //  - await操作将取回getStringTask中返回的string结果. 
            string urlContents = await getStringTask;

            // return语句用来指定一个整数结果。
            // 调用AccessTheWebAsync将会收到一个返回值的长度. 
            return urlContents;
        }


        void DoIndependentWork()
        {
            textBox2.Text += "Working . . . . . . .\r\n";
        }


        Task<double> FacAsync(int n)
        {
            return Task<double>.Run(() =>
            {
                Console.WriteLine("Fac" + Thread.CurrentThread.ManagedThreadId);
                double s = 1;
                for (int i = 1; i < n; i++) s = s * i;
                Thread.Sleep(1000);
                return s;
            });
        }
        async void Test()
        {
            // 调用异步方法
            Console.WriteLine("BeforeTask" + Thread.CurrentThread.ManagedThreadId);
            Task<double> myTask = FacAsync(10);
            Thread.Sleep(100);
            Console.WriteLine("BeforeAwait" + Thread.CurrentThread.ManagedThreadId);
            double result = await myTask;
            Console.WriteLine("AfterAwait" + Thread.CurrentThread.ManagedThreadId);
            // 或者在一句中调用
            double result2 = await FacAsync(10);
            Console.WriteLine("Result:{0},{1},{2}", result, result2, Thread.CurrentThread.ManagedThreadId);
        }
    }
}