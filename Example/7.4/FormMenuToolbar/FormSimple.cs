using System;
using System.Drawing;
using System.Windows.Forms;
public class MyForm : Form
{
	public MyForm()
	{
		this.Size = new Size(200,100);
		this.Text = "Form1";
	}
	static void Main()
	{
		Application.Run(new MyForm());
	}
}

