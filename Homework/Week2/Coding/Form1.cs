using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        
        int a, b, grade = 0;
        string op;
        int result;
        Random rnd = new Random();

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked== true)
                timer1.Enabled = true;
            else
                timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            BtnJudge_Click_1(null, null);
        }

        private void btnNew_Click(object sender, System.EventArgs e)
        {
            a = rnd.Next(9) + 1;
            b = rnd.Next(9) + 1;
            int c = rnd.Next(4);
            switch (c)
            {
                case 0: op = "+"; result = a + b; break;
                case 1: op = "-"; result = a - b; break;
                case 2: op = "*"; result = a * b; break;
                case 3: op = "/"; result = a / b; break;
            }
            lblA.Text = a.ToString();
            lblB.Text = b.ToString();
            lblOp.Text = op;
            txtAnswer.Text = "";
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(textBox1.Text)*1000;
        }

        private void BtnJudge_Click_1(object sender, EventArgs e)
        {
            string str = txtAnswer.Text;
            if (str == "")
                MessageBox.Show("请输入答案！");
            else
            {
                double d = double.Parse(str);
                string disp = "" + a + op + b + "=" + str + " ";
                if (d == result) // if( Math.Abs(d-result)< 1e-3 )
                {
                    disp += "✔";
                    grade++;
                    label2.Text = grade.ToString();
                    btnNew_Click(null, null);
                    label7.BackColor = Color.Green;
                }
                else
                {
                    disp += "✘";
                    btnNew_Click(null, null);
                    label7.BackColor = Color.Red;
                }
                lstDisp.Items.Add(disp);
            }
        }
        public Form1()
        {
            InitializeComponent();
            btnNew_Click(null, null);
        }
    }
}
