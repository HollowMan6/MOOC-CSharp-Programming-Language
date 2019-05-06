using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CrudDemo
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
            this.IsMdiContainer = true;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void 书目管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FormBookQuery();
            frm.MdiParent = this;
            frm.Show();
        }
        private void 书目录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FormBookInput();
            frm.MdiParent = this;
            frm.Show();

        }


    }
}
