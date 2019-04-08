    TextOnSeal _top = new TextOnSeal();

    _top.TextFont = new Font("宋体", 16, FontStyle.Regular);

    _top.FillColor = Color.Red;

    _top.ColorTOP = Color.Black;

    _top.Text = "中华人民共和国";

    _top.BaseString = "愚翁专用章";

    _top.ShowPath = true;

    _top.LetterSpace = 20;

    _top.SealSize = 180;

    _top.CharDirection = Char_Direction.Center;

    _top.SetIndent( 20 );

 

    Graphics g = this.CreateGraphics();

    g.DrawImage( _top.TextOnPathBitmap(), 0, 0 );

 

    _top.CharDirection = Char_Direction.ClockWise;

    g.DrawImage( _top.TextOnPathBitmap(), 180, 0 );

 

    _top.CharDirection = Char_Direction.AntiClockWise;

    g.DrawImage( _top.TextOnPathBitmap(), 0, 180 );

 

    _top.SetIndent( 20 );

    _top.CharDirection = Char_Direction.OutSide;

    g.DrawImage( _top.TextOnPathBitmap(), 180, 180 );