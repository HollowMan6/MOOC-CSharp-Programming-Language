using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TestWin
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(24, 40);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(104, 136);
			this.listBox1.TabIndex = 0;
			// 
			// listBox2
			// 
			this.listBox2.ItemHeight = 12;
			this.listBox2.Location = new System.Drawing.Point(224, 40);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(96, 136);
			this.listBox2.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(136, 72);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = ">>";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(136, 112);
			this.button2.Name = "button2";
			this.button2.TabIndex = 2;
			this.button2.Text = "<<";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(336, 221);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.listBox2,
																		  this.listBox1,
																		  this.button2});
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.listBox1.SelectionMode = SelectionMode.One;
			this.listBox2.SelectionMode = SelectionMode.MultiSimple;

			this.listBox1.Items.AddRange( new string [] {
															new string( 'a', 8 ),
															new string( 'b', 8 ),
															new string( 'c', 8 ),
															new string( 'd', 8 ),});

			this.listBox2.Items.AddRange( new string [] {
															new string( '1', 6 ),
															new string( '2', 6 ),
															new string( '3', 6 ),
															new string( '4', 6 ),});


			}

		private void button1_Click(object sender, System.EventArgs e)
		{
			object obj = this.listBox1.SelectedItem;
			if( obj != null )
			{
				this.listBox2.Items.Add( obj );
				this.listBox1.Items.Remove( obj );
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			ListBox.SelectedObjectCollection objs = this.listBox2.SelectedItems;
			this.listBox1.BeginUpdate();
			foreach( object obj in objs )
			{
				this.listBox1.Items.Add( obj );
			}
			this.listBox1.EndUpdate();

			ListBox.SelectedIndexCollection  ids = this.listBox2.SelectedIndices;
			this.listBox2.BeginUpdate();
			for( int i=ids.Count - 1; i>=0; i-- ) 
			{
				this.listBox2.Items.RemoveAt( ids[i] );
			}
			this.listBox2.EndUpdate();
		}

	}
}
