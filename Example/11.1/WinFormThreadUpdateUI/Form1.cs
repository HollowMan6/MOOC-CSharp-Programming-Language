using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Threading;

namespace WinFormThreadUpdateUI
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lstMsg;
		private System.Windows.Forms.Button btnAddThread;
		private System.Windows.Forms.Label lblMsg;
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.lstMsg = new System.Windows.Forms.ListBox();
			this.btnAddThread = new System.Windows.Forms.Button();
			this.lblMsg = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lstMsg
			// 
			this.lstMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lstMsg.ItemHeight = 12;
			this.lstMsg.Location = new System.Drawing.Point(0, 170);
			this.lstMsg.Name = "lstMsg";
			this.lstMsg.Size = new System.Drawing.Size(488, 256);
			this.lstMsg.TabIndex = 0;
			// 
			// btnAddThread
			// 
			this.btnAddThread.Location = new System.Drawing.Point(88, 40);
			this.btnAddThread.Name = "btnAddThread";
			this.btnAddThread.Size = new System.Drawing.Size(104, 32);
			this.btnAddThread.TabIndex = 1;
			this.btnAddThread.Text = "加一个线程";
			this.btnAddThread.Click += new System.EventHandler(this.btnAddThread_Click);
			// 
			// lblMsg
			// 
			this.lblMsg.Location = new System.Drawing.Point(32, 96);
			this.lblMsg.Name = "lblMsg";
			this.lblMsg.Size = new System.Drawing.Size(392, 23);
			this.lblMsg.TabIndex = 2;
			this.lblMsg.Text = "label1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(488, 426);
			this.Controls.Add(this.lblMsg);
			this.Controls.Add(this.btnAddThread);
			this.Controls.Add(this.lstMsg);
			this.Name = "Form1";
			this.Text = "Form1";
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




		private void btnAddThread_Click(object sender, System.EventArgs e)
		{
			Thread thread = new Thread( new ThreadStart( MyFun ) );
			thread.Name = (++id).ToString();
			thread.IsBackground = true;
			thread.Start();
		}
		int id =0;

		Random rnd = new Random();
		private void MyFun()
		{
			while( true )
			{
				//Thread.Sleep( rnd.Next(4000) );
				string msg = DateTime.Now + " " + Thread.CurrentThread.Name;
				//AddMsgFun( msg ); //这样不好 //VS.net 2005 以上的版本会抛出异常
				ShowMsg( msg ); //这样较好
			}
		}




		private void ShowMsg( string msg )
		{
			if(this.InvokeRequired )//进行判断
			{
				this.BeginInvoke( new AddMsg(this.AddMsgFun), new object[]{ msg } ); //显示到界面上
			}
			else
			{
				AddMsgFun( msg );
			}
		}

		private delegate void AddMsg( string msg );
		private void AddMsgFun( string msg )
		{
			this.lstMsg.Items.Insert(0, msg );
			this.lstMsg.SelectedIndex=0;

			this.lblMsg.Text = msg;
		}

	}
}
