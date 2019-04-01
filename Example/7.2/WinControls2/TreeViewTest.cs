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
		private System.ComponentModel.IContainer components;

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
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(272, 165);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);

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

		private TreeView tv;
		public void InitTreeView()
		{
			//  Create  and  setup  a  TreeView
			tv = new TreeView();
			tv.Location = new Point(30, 30);
			tv.Size = new Size(120,  150);
			//  Set the ImageList
			//tv.ImageList = ImageList1;
			// Add it to the form
			Controls.Add (tv);
			// Add child nodes
			AddNodes ( );
		}
		private void AddNodes()
		{
			// Create and add a root node
			TreeNode tn = new TreeNode("Root",  0,  0);
			tv.Nodes.Add (tn);
			// Add a child node
			TreeNode tn1 = new TreeNode("Child1", 1, 1);
			tn.Nodes.Add (tn1);
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			InitTreeView();
		}


	}
}
