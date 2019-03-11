using System;

using System.Drawing;

using System.Collections;

using System.ComponentModel;

using System.Windows.Forms;

using System.Data;



namespace TestWin

{

/// <summary>

/// Summary description for Form1.

/// </summary>

public class Form1 : System.Windows.Forms.Form

{

private System.Windows.Forms.Button button1;

/// <summary>

/// Required designer variable.

/// </summary>

private System.ComponentModel.Container components = null;



public Form1()

{

//

// Required for Windows Form Designer support

//

InitializeComponent();



//

// TODO: Add any constructor code after InitializeComponent call

//

}



/// <summary>

/// Clean up any resources being used.

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

/// Required method for Designer support - do not modify

/// the contents of this method with the code editor.

/// </summary>

private void InitializeComponent()

{

this.button1 = new System.Windows.Forms.Button();

this.SuspendLayout();

//

// button1

//

this.button1.Location = new System.Drawing.Point(216, 24);

this.button1.Name = "button1";

this.button1.Size = new System.Drawing.Size(64, 24);

this.button1.TabIndex = 0;

this.button1.Text = "button1";

//

// Form1

//

this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);

this.ClientSize = new System.Drawing.Size(292, 273);

this.Controls.AddRange(new System.Windows.Forms.Control[] {

this.button1});

this.Name = "Form1";

this.Text = "Form1";

this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

this.ResumeLayout(false);



}

#endregion



/// <summary>

/// The main entry point for the application.

/// </summary>

[STAThread]

static void Main()

{

Application.Run(new Form1());

}



private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)

{

Graphics g = e.Graphics;

Pen pen = Pens.Blue;



Fun [] funs = {

new Fun( this.Square ),

new Fun( Form1.XPlus ),

new Fun( Math.Cos ),

new Fun( Math.Sqrt )

};

foreach( Fun fun in funs )

{

PlotFun( fun, g, pen );

}

}



delegate double Fun( double x );



void PlotFun( Fun fun, Graphics g, Pen pen )

{

for( double x=0; x<10; x+=0.1)

{

double y = fun(x);

Point point = new Point( (int)(x*20), (int)(200-y*30) );

g.DrawLine( pen, point, new Point( point.X+2, point.Y+2) );

Console.WriteLine( " " + x + " " + y );

}

}



double Square( double x )

{

return Math.Sqrt( Math.Sqrt( x) );

}

static double XPlus( double x )