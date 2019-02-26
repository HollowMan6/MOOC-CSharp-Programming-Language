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
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.label1.Left += 10;
        }

        Random rnd = new Random();
        int deltx = 10;

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Left += deltx;
            if (this.label1.Left < 0 || this.label1.Left + this.label1.Width
            > this.Width) deltx = -deltx;
            this.label1.BackColor =
            Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }
    }
}
