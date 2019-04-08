namespace Seal

{

    using System;

    using System.Drawing;

    using System.Drawing.Drawing2D;

    using System.Diagnostics;

 

    /// <summary>

    /// Summary description for TextOnSeal.

    /// </summary>

    public class TextOnSeal

    {

        private string _text;

        private Font _font;

        private Color _pathcolor = Color.Red;

        private Color _color = Color.Black;

        private Color _fillcolor = Color.Black;

        private int _letterspace = 10;

        private bool _showpath = true;

        private Rectangle _rectcircle;

        private Rectangle _rect;

        private int _intentlength = 10;

        private Char_Direction _chardirect = Char_Direction.Center;

        private int _degree = 90;

        private string _basestring;

        #region Class_Properties

        public Char_Direction CharDirection

        {

            get{ return _chardirect;}

            set{

                if( _chardirect != value )

                {

                    _chardirect = value;

                    switch( _chardirect )

                    {

                        case Char_Direction.Center:

                            _degree = 90;

                            break;

                        case Char_Direction.ClockWise:

                            _degree = 0;

                            break;

                        case Char_Direction.OutSide:

                            _degree = -90;

                            break;

                        case Char_Direction.AntiClockWise:

                            _degree = 180;

                            break;

                    }

                }

            }

        }

 

        public string BaseString

        {

            get{ return _basestring;}

            set{ _basestring = value; }

        }

 

        public string Text

        {

            get{ return _text;}

            set{ _text = value;}

        }

 

        public Font TextFont

        {

            get{ return _font;}

            set{ _font = value;}

        }

 

        public Color PathColor

        {

            get{ return _pathcolor;}

            set{ _pathcolor = value; }

        }

 

        public Color ColorTOP

        {

            get{ return _color;}

            set{ _color = value;}

        }

 

        public Color FillColor

        {

            get{ return _fillcolor;}

            set{ _fillcolor = value;}

        }

 

        public int LetterSpace

        {

            get{ return _letterspace;}

            set{ _letterspace = value;}

        }

 

        public bool ShowPath

        {

            get{ return _showpath;}

            set{ _showpath = value;}

        }

 

        public int SealSize

        {

            set{

                _rect = new Rectangle( 0, 0, value, value );

                _rectcircle = new Rectangle(

                    new Point( _rect.X + _intentlength, _rect.Y + _intentlength ),

                    new Size( _rect.Width - 2 * _intentlength, _rect.Height - 2 * _intentlength ) ) ;

            }

 

        }

        #endregion {Class_Properties}

 

        public void SetIndent( int IntentLength )

        {

            _intentlength = IntentLength;

            _rectcircle = new Rectangle( _intentlength, _intentlength,

                _rect.Width - _intentlength * 2, _rect.Height - _intentlength * 2 );

        }

        public TextOnSeal()

        {

            //

            // TODO: Add constructor logic here

            //

        }

 

        public Bitmap TextOnPathBitmap(

            Rectangle rectCircle,

            string strText,

            Font fntText,

            Color clrColor,

            Color clrFill,

            int nPercentage )

        {

            _rect = rectCircle;

            _rectcircle = new Rectangle(

                new Point( _rect.X + _intentlength, _rect.Y + _intentlength ),

                new Size( _rect.Width - 2 * _intentlength, _rect.Height - 2 * _intentlength ) ) ;

            _text = strText;

            _font = fntText;

            _color = clrColor;

            _fillcolor = clrFill;

            _letterspace = nPercentage;

            return TextOnPathBitmap();

        }

 

        /// <summary>

        /// Compute string total length and every char length

        /// </summary>

        /// <param name="sText"></param>

        /// <param name="g"></param>

        /// <param name="fCharWidth"></param>

        /// <param name="fIntervalWidth"></param>

        /// <returns></returns>

        private float ComputeStringLength( string sText, Graphics g, float[] fCharWidth,

            float fIntervalWidth,

            Char_Direction Direction )

        {

            // Init string format

            StringFormat sf = new StringFormat();

            sf.Trimming = StringTrimming.None;

            sf.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap

                | StringFormatFlags.LineLimit;

           

            // Measure whole string length

            SizeF size = g.MeasureString( sText, _font, (int)_font.Style );

            RectangleF rect = new RectangleF( 0f,0f, size.Width, size.Height );

 

            // Measure every character size

            CharacterRange[] crs = new CharacterRange[sText.Length];

            for( int i = 0; i < sText.Length; i++ )

                crs[i] = new CharacterRange( i, 1 );

 

            // Reset string format

            sf.FormatFlags = StringFormatFlags.NoClip;

            sf.SetMeasurableCharacterRanges( crs );

            sf.Alignment = StringAlignment.Near;

 

            // Get every character size

            Region[] regs = g.MeasureCharacterRanges( sText,

                _font, rect, sf );

 

            // Re-compute whole string length with space interval width

            float fTotalWidth = 0f;

            for( int i = 0; i < regs.Length; i++ )

            {

                if( Direction == Char_Direction.Center || Direction == Char_Direction.OutSide )

                    fCharWidth[i] = regs[i].GetBounds( g ).Width;

                else

                    fCharWidth[i] = regs[i].GetBounds( g ).Height;

                fTotalWidth += fCharWidth[i] + fIntervalWidth;

            }

            fTotalWidth -= fIntervalWidth;//Remove the last interval width

 

            return fTotalWidth;

 

        }

 

        /// <summary>

        /// Compute every char position

        /// </summary>

        /// <param name="CharWidth"></param>

        /// <param name="recChars"></param>

        /// <param name="CharAngle"></param>

        /// <param name="StartAngle"></param>

        private void ComputeCharPos(

            float[] CharWidth,

            PointF[] recChars,

            double[] CharAngle,

            double StartAngle )

        {

            double fSweepAngle, fCircleLength;

            //Compute the circumference

            fCircleLength = _rectcircle.Width * Math.PI;

           

            for( int i = 0; i < CharWidth.Length; i++ )

            {

                //Get char sweep angle

                fSweepAngle = CharWidth[i] * 360 / fCircleLength;

 

                //Set point angle

                CharAngle[i] = StartAngle + fSweepAngle / 2;

 

                //Get char position

                if( CharAngle[i] < 270f )

                    recChars[i] = new PointF(

                        _rectcircle.X + _rectcircle.Width / 2

                        -(float)( _rectcircle.Width / 2 *

                        Math.Sin( Math.Abs( CharAngle[i] - 270 ) * Math.PI / 180 ) ) ,

                        _rectcircle.Y + _rectcircle.Width / 2

                        -(float)( _rectcircle.Width / 2 * Math.Cos(

                        Math.Abs( CharAngle[i] - 270 ) * Math.PI / 180 ) ) );

                else

                    recChars[i] = new PointF(

                        _rectcircle.X + _rectcircle.Width / 2

                        +(float)( _rectcircle.Width / 2 *

                        Math.Sin( Math.Abs( CharAngle[i] - 270 ) * Math.PI / 180 ) ) ,

                        _rectcircle.Y + _rectcircle.Width / 2

                        -(float)( _rectcircle.Width / 2 * Math.Cos(

                        Math.Abs( CharAngle[i] - 270 ) * Math.PI / 180 ) ) );

 

                //Get total sweep angle with interval space

                fSweepAngle = ( CharWidth[i] + _letterspace ) * 360 / fCircleLength;

                StartAngle += fSweepAngle;

 

            }

        }

 

        /// <summary>

        /// Generate seal bitmap

        /// </summary>

        /// <returns></returns>

        public Bitmap TextOnPathBitmap()

        {

            // Create bitmap and graphics

            Bitmap bit = new Bitmap( _rect.Width, _rect.Height );

            Graphics g = Graphics.FromImage( bit );

 

            // Compute string length in graphics

            float[] fCharWidth = new float[_text.Length];

            float fTotalWidth = ComputeStringLength( _text, g, fCharWidth,

                _letterspace, _chardirect );

 

            // Compute arc's start-angle and end-angle

            double fStartAngle, fSweepAngle;

            fSweepAngle = fTotalWidth * 360 / ( _rectcircle.Width * Math.PI );

            fStartAngle = 270 - fSweepAngle / 2;

 

            // Compute every character's position and angle

            PointF[] pntChars = new PointF[ _text.Length ];

            double[] fCharAngle = new double[ _text.Length ];

            ComputeCharPos( fCharWidth, pntChars, fCharAngle, fStartAngle );

 

            g.SmoothingMode = SmoothingMode.HighQuality;

            g.CompositingQuality = CompositingQuality.HighQuality;

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

 

            DrawSealBase( g );

 

            // Draw every character

            for( int i = 0; i < _text.Length; i++ )

                DrawRotatedText( g, _text[i].ToString(), (float)(fCharAngle[i] + _degree), pntChars[i] );

 

            g.Dispose();

 

            // Return bitmap

            return bit;

        }

 

        /// <summary>

        /// Draw seal base

        /// </summary>

        /// <param name="g"></param>

        private void DrawSealBase( Graphics g )

        {

            // Draw background

            g.FillRectangle( Brushes.Black, _rect );

            g.FillEllipse( new SolidBrush( _fillcolor ),

                new Rectangle( 1,1, _rect.Width - 2, _rect.Height - 2 ) );

            g.FillEllipse( Brushes.White,

                new Rectangle( 4, 4, _rect.Width - 8, _rect.Height - 8 ) );

 

            // Draw start signal

            StringFormat sf = new StringFormat();

            string strStar = "★";

            Font fnt = new Font( _font.FontFamily, _font.Size * 3 );

            sf.Alignment = StringAlignment.Center;

            sf.LineAlignment = StringAlignment.Center;

            SizeF siz = g.MeasureString( strStar, fnt );

            g.DrawString( strStar, fnt, new SolidBrush( _fillcolor ),

                new RectangleF( _rect.Width / 2 - siz.Width / 2,

                _rect.Height / 2 - siz.Height/ 2,

                siz.Width, siz.Height ), sf );

 

            // Draw base string

            float[] fCharWidth = new float[_basestring.Length];

            float fTotalWidths = ComputeStringLength( _basestring, g, fCharWidth, 0,

                Char_Direction.Center );

            float fLeftPos = ( _rect.Width - fTotalWidths ) / 2;

            PointF pt;

            for( int i = 0; i < _basestring.Length; i++ )

            {

                pt = new PointF( fLeftPos + fCharWidth[i] / 2,

                    _rect.Height / 2 + siz.Height / 2 + 10 );

                DrawRotatedText( g, _basestring[i].ToString(), 0, pt );

                fLeftPos += fCharWidth[i];

            }

        }

 

        /// <summary>

        /// Draw every rotated character

        /// </summary>

        /// <param name="g"></param>

        /// <param name="_text"></param>

        /// <param name="_angle"></param>

        /// <param name="_PointCenter"></param>

        private void DrawRotatedText( Graphics g, string _text, float _angle, PointF _PointCenter )

        {

            // Init format

            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;

            sf.LineAlignment = StringAlignment.Center;

 

            // Create graphics path

            GraphicsPath gp = new GraphicsPath( System.Drawing.Drawing2D.FillMode.Winding );

            int x = (int)_PointCenter.X;

            int y = (int)_PointCenter.Y;

 

            // Add string

            gp.AddString( _text, _font.FontFamily, (int)_font.Style,

                _font.Size, new Point( x, y ), sf );

 

            // Rotate string and draw it

            Matrix m = new Matrix();

            m.RotateAt( _angle, new PointF( x,y ) );

            g.Transform = m;

            g.DrawPath( new Pen( _color), gp );

            g.FillPath( new SolidBrush( _fillcolor ), gp );

        }

 

    }

 

    public enum Char_Direction

    {

        Center          = 0,

        OutSide         = 1,

        ClockWise       = 2,

        AntiClockWise   = 3,

    }

}