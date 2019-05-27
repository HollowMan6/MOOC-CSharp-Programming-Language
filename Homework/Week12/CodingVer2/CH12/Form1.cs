using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CH12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool isRandom = false;
        public  DB mydb;
        public int intNumRead=1;
        Random rnd = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
             mydb = new DB();
           // mydb.creatTable();
            #region 将txt文档数据导入数据库，只需运行一次
            //string path = AppDomain.CurrentDomain.BaseDirectory + "College_Grade4.txt";
            //StreamReader sr = new StreamReader(path, Encoding.Default);
            //string str = sr.ReadToEnd();
            //string[] arrStr = str.Split('\n');
            //int num = 0;
            //foreach (string strTemp in arrStr)
            //{
            //    num++;
            //    string[] arrStr2 = strTemp.Trim().Split('\t');
            //    mydb.insertData(num, arrStr2[0], arrStr2[1], rnd.Next(10));
            //}
            #endregion
            showInfo(intNumRead);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                isRandom = true;
            }
            else
            {
                isRandom = false;
            }
        }
        public void showInfo(int num)
        {
            DB.infor infor = mydb.searchInfo(num);
            label3.Text = infor.eng;
            label4.Text = infor.chi;
            label5.Text =infor.fami.ToString();
            intNumRead = infor.i;
            if (infor.fami<5)
            {
                label3.ForeColor = Color.Red;
                label4.ForeColor = Color.Red;
            }
            else
            {
                label3.ForeColor = Color.Green;
                label4.ForeColor = Color.Green;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            mydb.updata(int.Parse(label5.Text)+1, intNumRead);

            if (isRandom)
            {
                
                showInfo(rnd.Next(DB.intCount));
            }
            else
            {
               // intNumRead++;
                showInfo(++intNumRead);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mydb.updata(int.Parse(label5.Text) -1, intNumRead);

            if (isRandom)
            {

                showInfo(rnd.Next(DB.intCount));
            }
            else
            {
                // intNumRead++;
                showInfo(++intNumRead);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            intNumRead = 1;
            showInfo(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataSet mydat = new DataSet();
            mydat = mydb.showFamiliarityLess5();
            dataGridView1.DataSource = mydat.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataSet mydat = new DataSet();
            mydat = mydb.showFamiliarityHigher5();
            dataGridView1.DataSource = mydat.Tables[0];
        }
    }
}
