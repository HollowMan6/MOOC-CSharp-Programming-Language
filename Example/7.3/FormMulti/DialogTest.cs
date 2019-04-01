using System;
using System.Drawing;
using System.Windows.Forms;
class DialogTest
{
	static void Main()
	{
		Form form1 = new Form();
		Button button1 = new Button ();
		Button button2 = new Button ();

		button1.Text = "OK";
		button1.Location = new Point (10, 10);
		button2.Text = "Cancel";
		button2.Location 
		= new Point (button1.Left, button1.Height + button1.Top + 10);

		form1.Text = "My Dialog Box";
		form1.FormBorderStyle = FormBorderStyle.FixedDialog;
		form1.Size = new Size( 200,100 );
		form1.StartPosition = FormStartPosition.CenterScreen;

		form1.Controls.Add(button1);
		form1.Controls.Add(button2);

		button1.DialogResult = DialogResult.OK;
		button2.DialogResult = DialogResult.Cancel;
		form1.AcceptButton = button1;
		form1.CancelButton = button2;

		form1.ShowDialog();

		if (form1.DialogResult == DialogResult.OK)
		{
			MessageBox.Show("The OK button on the form was clicked.");
			form1.Dispose();
		}
		else
		{
			MessageBox.Show("The Cancel button on the form was clicked.");
			form1.Dispose();
		}
	}
}

