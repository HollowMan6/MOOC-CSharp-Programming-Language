private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)

{

 

    GraphicsPath gp = new GraphicsPath( FillMode.Winding );

    gp.AddString(

        "字体轮廓", 

        new FontFamily("方正舒体"), 

        (int) FontStyle.Regular,

        80, 

        new PointF(10, 20), 

        new StringFormat());

 

    Brush brush =  new LinearGradientBrush(

            new PointF(0,  0), new PointF(Width, Height), 

            Color.Red, Color.Yellow);

 

    e.Graphics.DrawPath( Pens.Black, gp );

    e.Graphics.FillPath( brush, gp );

 

}