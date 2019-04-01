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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Items.AddRange(new object[] {
														  "LargeIcon",
														  "SmallIcon",
														  "Report",
														  "List"});
			this.listBox1.Location = new System.Drawing.Point(184, 40);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(72, 88);
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(272, 165);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listBox1});
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

		private System.Windows.Forms.ListBox listBox1;


		private ImageList imageList1;
		
		void PrepareImageList()
		{
			imageList1 = new ImageList();
			imageList1.ImageSize = new Size( 32, 32 );
			imageList1.Images.Add( 
				Image.FromFile( @"c:\winnt\Gone Fishing.bmp" ) );
			imageList1.Images.Add( 
				Image.FromFile( @"c:\winnt\Greenstone.bmp" ) );
			imageList1.Images.Add( 
				Image.FromFile( @"c:\winnt\FeatherTexture.bmp" ) );
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			PrepareImageList( );
			CreateListView();
		}


		private ListView lv;
		public void CreateListView()
		{
			//  Create a ListView, position and size it
			lv = new ListView();
			lv.Location = new Point(8,  8);
			lv.Size = new Size(160,  136);
			lv.ForeColor = SystemColors.WindowText;
			// Set up the ImageList that holds the large icons
			lv.LargeImageList = imageList1;
			lv.SmallImageList = imageList1;
			Controls.Add(lv);
			// Add the items
			AddItems();
		}
		private void AddItems()
		{
			// Create some list items
			ListViewItem item1 = new ListViewItem( "Team one",  0);
			ListViewItem item2 = new ListViewItem( "Team two",  1);
			ListViewItem item3 = new ListViewItem( "Team three", 2);
			// Add them to the list
			lv.Items.Add(item1);
			lv.Items.Add(item2);
			lv.Items.Add(item3);
		}

		private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int mode = this.listBox1.SelectedIndex;
			switch( mode )
			{
				case 0: 
					lv.View = View.LargeIcon;
					break;
				case 1:
					lv.View = View.SmallIcon ;
					break;
				case 2:
					lv.View = View.Details;
					break;
				case 3:
					lv.View = View.List;
					break;
			}
		}


	}
}
