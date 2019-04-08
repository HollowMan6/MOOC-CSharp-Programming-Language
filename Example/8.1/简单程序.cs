            Graphics g = this.CreateGraphics();

            Pen pen = new Pen(Color.Red, 2);

            Brush brush = new SolidBrush(Color.Blue);

            Font font = new Font("宋体", 25);

            Rectangle rect = new Rectangle(20, 120, 100, 160);

            g.DrawLine(pen, 20, 100, 100, 100);

            g.DrawRectangle(pen, rect);

            g.DrawString("GDI+图形编程", font, brush, 20, 20);

            brush.Dispose(); font.Dispose(); pen.Dispose();

            g.Dispose();