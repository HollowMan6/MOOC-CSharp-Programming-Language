using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CrudDemo
{
    public partial class FormBookInput : Form
    {
        public FormBookInput()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] fields = { "书名", "作者", "关键字", "出版社" };
            string[] values = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text };

            string sql = Util.StringUtil.MakeInsertSql(fields, values, "Book");
            DAL.AccessDB.ExecuteNonQuery(sql);

            MessageBox.Show("数据已保存");

            this.Close();
        }
    }
}
