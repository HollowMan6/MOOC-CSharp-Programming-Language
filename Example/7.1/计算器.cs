//简单的计算器
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
namespace wincalc
{
	///
	/// Summary description for calcForm.
	///
	public class calcForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button bClr;
		private System.Windows.Forms.Button bDot;
		private System.Windows.Forms.Button bPlus;
		private System.Windows.Forms.Button bSub;
		private System.Windows.Forms.Button bMul;
		private System.Windows.Forms.Button bDiv;
		private System.Windows.Forms.Button bEqu;
		private System.Windows.Forms.TextBox txtCalc;
		//以下是要添加的代码
		//定义变量
		Double dblAcc;
		Double dblSec;
		bool blnClear,blnFrstOpen;
		String strOper;
		//以上是添加的代码
		///
		/// Required designer variable.
		///
		private System.ComponentModel.Container components = null;
		public calcForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			//以下是要添加的代码
			//初始化设量
			dblAcc=0;
			dblSec=0;
			blnFrstOpen=true;
			blnClear=true;
			strOper=new string('=',1);
			//以上是添加的代码
		}
		///
		/// Clean up any resources being used.
		///
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		///
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		///
		private void InitializeComponent()
		{
			this.bPlus = new System.Windows.Forms.Button();
			this.bMul = new System.Windows.Forms.Button();
			this.bDot = new System.Windows.Forms.Button();
			this.txtCalc = new System.Windows.Forms.TextBox();
			this.bClr = new System.Windows.Forms.Button();
			this.bDiv = new System.Windows.Forms.Button();
			this.bSub = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.bEqu = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// bPlus
			//
			this.bPlus.BackColor = System.Drawing.SystemColors.Control;
			this.bPlus.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bPlus.Location = new System.Drawing.Point(208, 112);
			this.bPlus.Name = "bPlus";
			this.bPlus.Size = new System.Drawing.Size(32, 80);
			this.bPlus.TabIndex = 1;
			this.bPlus.Text = "+";
			//以下是要添加的代码
			bPlus.Click += new System.EventHandler(this.btn_Oper);
			//以上是添加的代码
			//
			// bMul
			//
			this.bMul.Location = new System.Drawing.Point(160, 112);
			this.bMul.Name = "bMul";
			this.bMul.Size = new System.Drawing.Size(32, 32);
			this.bMul.TabIndex = 1;
			this.bMul.Text = "*";
			//以下是要添加的代码
			bMul.Click += new System.EventHandler(this.btn_Oper);
			//以上是添加的代码
			//
			// bDot
			//
			this.bDot.ForeColor = System.Drawing.Color.Black;
			this.bDot.Location = new System.Drawing.Point(112, 208);
			this.bDot.Name = "bDot";
			this.bDot.Size = new System.Drawing.Size(32, 32);
			this.bDot.TabIndex = 0;
			this.bDot.Text = ".";
			//以下是要添加的代码
			bDot.Click += new System.EventHandler(this.btn_clk);
			//以上是添加的代码
			//
			// txtCalc
			//
			this.txtCalc.Location = new System.Drawing.Point(16, 24);
			this.txtCalc.Name = "txtCalc";
			this.txtCalc.ReadOnly = true;
			this.txtCalc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtCalc.Size = new System.Drawing.Size(224, 21);
			this.txtCalc.TabIndex = 2;
			this.txtCalc.Text = "";
			//
			// bClr
			//
			this.bClr.BackColor = System.Drawing.SystemColors.Control;
			this.bClr.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bClr.Location = new System.Drawing.Point(208, 64);
			this.bClr.Name = "bClr";
			this.bClr.Size = new System.Drawing.Size(32, 32);
			this.bClr.TabIndex = 0;
			this.bClr.Text = "AC";
			//以下是要添加的代码
			bClr.Click += new System.EventHandler(this.btn_clr);
			//以上是添加的代码
			//
			// bDiv
			//
			this.bDiv.Location = new System.Drawing.Point(160, 160);
			this.bDiv.Name = "bDiv";
			this.bDiv.Size = new System.Drawing.Size(32, 32);
			this.bDiv.TabIndex = 1;
			this.bDiv.Text = "/";
			//以下是要添加的代码
			bDiv.Click += new System.EventHandler(this.btn_Oper);
			//以上是添加的代码
			//
			// bSub
			//
			this.bSub.Location = new System.Drawing.Point(160, 64);
			this.bSub.Name = "bSub";
			this.bSub.Size = new System.Drawing.Size(32, 32);
			this.bSub.TabIndex = 1;
			this.bSub.Text = "-";
			//以下是要添加的代码
			bSub.Click += new System.EventHandler(this.btn_Oper);
			//以上是添加的代码
			//
			// button8
			//
			this.button8.Location = new System.Drawing.Point(16, 64);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(32, 32);
			this.button8.TabIndex = 0;
			this.button8.Text = "7";
			//以下是要添加的代码
			button8.Click += new System.EventHandler(this.btn_clk);
			//以上是添加的代码
			//
			// button9
			//
			this.button9.Location = new System.Drawing.Point(64, 64);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(32, 32);
			this.button9.TabIndex = 0;
			this.button9.Text = "8";
			//以下是要添加的代码
			button9.Click += new System.EventHandler(this.btn_clk);
			//以上是添加的代码
			//
			// bEqu
			//
			this.bEqu.BackColor = System.Drawing.SystemColors.Control;
			this.bEqu.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bEqu.Location = new System.Drawing.Point(160, 208);
			this.bEqu.Name = "bEqu";
			this.bEqu.Size = new System.Drawing.Size(80, 32);
			this.bEqu.TabIndex = 1;
			this.bEqu.Text = "=";
			//以下是要添加的代码
			bEqu.Click += new System.EventHandler(this.btn_equ);
			//以上是添加的代码
			//
			// button10
			//
			this.button10.Location = new System.Drawing.Point(112, 64);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(32, 32);
			this.button10.TabIndex = 0;
			this.button10.Text = "9";
			//以下是要添加的代码
			button10.Click += new System.EventHandler(this.btn_clk);
			//以上是添加的代码
			//
			// button4
			//
			this.button4.Location = new System.Drawing.Point(112, 160);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(32, 32);
			this.button4.TabIndex = 0;
			this.button4.Text = "3";
			//以下是要添加的代码
			button4.Click += new System.EventHandler(this.btn_clk);
			//以上是添加的代码
			//
			// button5
			//
			this.button5.Location = new System.Drawing.Point(16, 112);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(32, 32);
			this.button5.TabIndex = 0;
			this.button5.Text = "4";
			//以下是要添加的代码
			button5.Click += new System.EventHandler(this.btn_clk);
			//以上是添加的代码
			//
			// button6
			//
			this.button6.Location = new System.Drawing.Point(64, 112);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(32, 32);
			this.button6.TabIndex = 0;
			this.button6.Text = "5";
			//以下是要添加的代码
			button6.Click += new System.EventHandler(this.btn_clk);
			//以上是添加的代码
			//
			// button7
			//
			this.button7.Location = new System.Drawing.Point(112, 112);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(32, 32);
			this.button7.TabIndex = 0;
			this.button7.Text = "6";
			//以下是要添加的代码
			button7.Click += new System.EventHandler(this.btn_clk);
			//以上是添加的代码
			//
			// button1
			//
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.ForeColor = System.Drawing.Color.Black;
			this.button1.Location = new System.Drawing.Point(16, 208);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "0";
			//以下是要添加的代码
			button1.Click += new System.EventHandler(this.btn_clk);
			//以上是添加的代码
			//
			// button2
			//
			this.button2.Location = new System.Drawing.Point(16, 160);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(32, 32);
			this.button2.TabIndex = 0;
			this.button2.Text = "1";
			//以下是要添加的代码
			button2.Click += new System.EventHandler(this.btn_clk);
			//以上是添加的代码
			//
			// button3
			//
			this.button3.Location = new System.Drawing.Point(64, 160);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(32, 32);
			this.button3.TabIndex = 0;
			this.button3.Text = "2";
			//以下是要添加的代码
			button3.Click += new System.EventHandler(this.btn_clk);
			//以上是添加的代码
			//
			// calcForm
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(256, 261);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtCalc,
																		  this.bEqu,
																		  this.bDiv,
																		  this.bMul,
																		  this.bSub,
																		  this.bPlus,
																		  this.bDot,
																		  this.bClr,
																		  this.button10,
																		  this.button9,
																		  this.button8,
																		  this.button7,
																		  this.button6,
																		  this.button5,
																		  this.button4,
																		  this.button3,
																		  this.button2,
																		  this.button1});
			this.Name = "calcForm";
			this.Text = "计算器";
			this.ResumeLayout(false);
		}
		#endregion
		//以下是要添加的代码
		//小数点的操作
		private void btn_clk(object obj,EventArgs ea)
		{
			if(blnClear)
				txtCalc.Text="";
			Button b3=(Button)obj;
			txtCalc.Text+=b3.Text;
			if(txtCalc.Text==".")
				txtCalc.Text="0.";
			dblSec=Convert.ToDouble(txtCalc.Text);
			blnClear=false;
		}
		//程序开始点
		private static void Main()
		{
			Application.Run(new calcForm());
		}
		private void btn_Oper(object obj,EventArgs ea)
		{
			Button tmp=(Button)obj;
			strOper=tmp.Text;
			if(blnFrstOpen)
				dblAcc=dblSec;
			else
				calc();
			blnFrstOpen=false;
			blnClear=true;
		}
		//等号运算
		private void btn_equ(object obj,EventArgs ea)
		{
			calc();
		}
		//所有运算操作
		private void calc()
		{
			switch(strOper)
			{
				case "+":
					dblAcc+=dblSec; //加号运算
					break;
				case "-":
					dblAcc-=dblSec; //减号运算
					break;
				case "*":
					dblAcc*=dblSec; //乘号运算
					break;
				case "/":
					dblAcc/=dblSec; //除号运算
					break;
			}
			strOper="="; //等号运算
			blnFrstOpen=true;
			txtCalc.Text=Convert.ToString(dblAcc);//将运算结果转换成字符类型,并输出
			dblSec=dblAcc;//将运算数A的值放入运算数B中,以便后面运算
		}
		//清除按钮
		private void btn_clr(object obj,EventArgs ea)
		{
			clear();
		}
		//清除按钮的操作
		private void clear()
		{
			dblAcc=0;
			dblSec=0;
			blnFrstOpen=true;
			txtCalc.Text="";
			txtCalc.Focus();//设置焦点为txtCalc
		}
		//以上是添加的代码
	}
} 
