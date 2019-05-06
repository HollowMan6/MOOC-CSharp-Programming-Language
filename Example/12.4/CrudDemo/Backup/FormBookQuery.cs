using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CrudDemo
{
    public partial class FormBookQuery : Form
    {
        public FormBookQuery()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string sql = "select * from Book where 1=1";
            Util.StringUtil.AddSqlWhere(ref sql, "书名", "like", txtBookName.Text);
            Util.StringUtil.AddSqlWhere(ref sql, "作者", "like", txAuthor.Text);

            DataSet ds = DAL.AccessDB.GetDataSet(sql);

            this.dataGridView1.DataSource = ds.Tables[0];

        }
    }
}
