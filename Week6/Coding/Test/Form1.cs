using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

namespace Test
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int t1 = 0;//此处变量t1只定义一次变量，不随着timer而重复赋值
        private void timer1_Tick(object sender, EventArgs e)
        {

            #region 从文件读取数据     

            /// <summary>      
            /// 使用StreamReader读取文本文件然后一行一行的输出 --  
            /// </summary>  
            List<string> english = new List<string>();//此处初始化两个集合
            List<string> chinese = new List<string>();//将后面把每一行内容分割好的几部分分别存给集合
                                                      //List<string> yinbiao = new List<string>();
                                                      //创建变量line         

            //创建StreamReader 
            StreamReader sw = new StreamReader("D:\\College_Grade4.txt", Encoding.Default);//此处读取文件功能，Encoding.Default的作用是根据文本文件的编码来读取数据，一定不能丢，否则中文会乱码

            string content = sw.ReadToEnd();//把文件读完存给content
            string[] lines = content.Split('\n');//把读取好的文件分割为一行一行存给数组
            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Trim().Split('\t');//以水平制表符为基准将每一行分割成几部分
                if (words.Length < 2)//如果分割的部分小于2个的话就不处理此行
                    continue;
                english.Add(words[0]);//将第一部分和第二部分分别存给上述集合
                chinese.Add(words[1]);
                // yinbiao.Add(words[2]);
            }
            //将英文和翻译先后显示出来
            if (t1 < lines.Length)
            {
                this.label1.Text = english[t1];

                this.label2.Text = chinese[t1];
            }
            t1++;
            #endregion
        }
    }
}
