using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp08
{
    public partial class Form1 : Form
    {
        
        string str1 = "";
        string str2 = "";
        string str3 = "";
        public Form1()
        {            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = textBox1.Text;
            string str2 = textBox2.Text;
            string str3 = textBox3.Text;

            int CircleD = 0;  //圆的直径
            int penW = 5;   //画笔的大小
            string star = "★";
            Font star_Font = new Font("Arial", 45, FontStyle.Regular);  //设置星的字体
            Font Var_Font = new Font("Arial", 20, FontStyle.Regular);   //设置文字字体
            if (str1 == "" | str2 == "" | str3 == "")
            {
                MessageBox.Show("请输入相关内容");
            }
            else
            {
                //画圆
                CircleD = Int32.Parse(str3);
                Rectangle rect = new Rectangle(5, 5, CircleD - 10, CircleD - 10);
                Graphics g = this.CreateGraphics();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);
                Pen myPen = new Pen(Color.Red, penW);
                g.DrawEllipse(myPen, rect);
                //画星
                SizeF Star = new SizeF(rect.Width, rect.Height);
                Star = g.MeasureString(star, star_Font);
                float star_x = (rect.Width / 2F) + 5 - Star.Width / 2F;
                float star_y = rect.Height / 2F - Star.Width / 2F;
                g.DrawString(star, star_Font, myPen.Brush, new PointF(star_x, star_y));
                //画文字
                Star = g.MeasureString(str2, Var_Font);
                float m = (rect.Width / 2F) + 5 - Star.Width / 2F;
                float n = rect.Height / 2F + Star.Height * 2;
                g.DrawString(str2, Var_Font, myPen.Brush, new PointF(m, n));

                string test = str1;
                int len = test.Length;
                float angle = 180;
                float change = 0;
                if (len > 1) 
                {
                    change = 180 / (len - 1);
                }
                for (int i = 0; i < len; i++) //以指定的弧度绘制
                {
                    if (len > 1)
                    {
                        float x = (CircleD + 5 / 2) / 2;
                        float y = (CircleD + 5 / 2) / 2;
                        g.TranslateTransform(x, y);
                        g.RotateTransform(angle);  
                        Brush myBrush = Brushes.Red;//定义画刷
                        float words_x = CircleD / 2 - 10 * 5;
                        float words_y = 0;
                        g.DrawString(test.Substring(i, 1), Var_Font, myBrush, words_x, words_y);
                        g.ResetTransform();
                        angle += change;
                    }
                    else
                    {
                        //输入一个字符时
                        float x = (CircleD + 5 / 2) / 2;
                        float y = (CircleD + 5 / 2) / 2;
                        g.TranslateTransform(x, y);
                        g.RotateTransform(0);
                        Brush myBrush = Brushes.Red;
                        float words_x = -5 * 3;
                        float words_y = -(CircleD / 2 - 2 * 5);
                        g.DrawString(test.Substring(i, 1), Var_Font, myBrush, words_x, words_y);
                        g.ResetTransform();
                    }
                }


            }
        }
                
    }
}
