private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)

{

    Graphics g = e.Graphics;

    g.FillRectangle( Brushes.White, 0, 0, Width, Height);

 

    float x = g.VisibleClipBounds.Width;

    float y = g.VisibleClipBounds.Height;

    PointF[] pts = 

    { 

        new PointF(0,0), new PointF(x/2,0), 

        new PointF(x/2,y/2), new PointF(0,y/2)

    };

    Pen pen = new Pen(Color.Blue, 1.0F);

    g.ScaleTransform( 0.8F, 0.8F );

    g.TranslateTransform(x/2,y/2+20);

    for( int i=0; i<36; i++)

    {

        g.DrawBeziers(pen, pts );

        g.DrawRectangle( pen, -x/12, -y/12, x/6, y/6 );

        g.DrawEllipse( pen, -x/4, -y/3, x/2, y*2/3 );

        g.RotateTransform(10);

    }

}