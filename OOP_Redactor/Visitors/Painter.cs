using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace OOP_Redactor
{
    class Painter: IVisitor
    {
        private Graphics _g;
        public Painter(Graphics g)
        {
            _g = g;
        }
        public void visitCircle(Circle c)
        {
            Pen pen = new Pen(Color.Red);
            chooseCol(c, pen);             
            _g.DrawEllipse(pen, c.X - c.Diam / 2, c.Y - c.Diam / 2, c.Diam, c.Diam);
            SolidBrush solidBrush = new SolidBrush(Color.Gray);
            if (c.sticky)
                solidBrush.Color = Color.Pink;
            _g.FillEllipse(solidBrush, c.X - c.Diam / 2 + 1, c.Y - c.Diam / 2 + 1, c.Diam - 2, c.Diam - 2);
        }
        public void visitSquare(Square s)
        {
            Pen pen = new Pen(Color.Red);
            chooseCol(s, pen);

            _g.DrawLine(pen, s.X, s.Y + s.Diam / 2, s.X + s.Diam / 2, s.Y);
            _g.DrawLine(pen, s.X - s.Diam / 2, s.Y, s.X, s.Y + s.Diam / 2);
            _g.DrawLine(pen, s.X - s.Diam / 2, s.Y, s.X, s.Y - s.Diam / 2);
            _g.DrawLine(pen, s.X, s.Y - s.Diam / 2, s.X + s.Diam / 2, s.Y);
            SolidBrush solidBrush = new SolidBrush(Color.Gray);
            if (s.sticky)
                solidBrush = new SolidBrush(Color.HotPink);
            GraphicsPath gp = new GraphicsPath(FillMode.Winding);
            gp.AddPolygon(new Point[] { new Point(s.X, s.Y + s.Diam / 2 - 2), new Point(s.X - s.Diam / 2 + 2, s.Y), new Point(s.X, s.Y - s.Diam / 2 + 2), new Point(s.X + s.Diam / 2 - 2, s.Y) });
            _g.FillPath(solidBrush, gp);
        }
        public void visitLine(Line l)
        {
            Pen pen = new Pen(Color.Red);
            chooseCol(l, pen);

            _g.DrawLine(pen, l.X - l.Diam / 2, l.Y, l.X + l.Diam / 2, l.Y);
            _g.DrawLine(pen, l.X - l.Diam / 2, l.Y + 3, l.X - l.Diam / 2, l.Y - 3);
            _g.DrawLine(pen, l.X + l.Diam / 2, l.Y + 3, l.X + l.Diam / 2, l.Y - 3);
        }
        public void visitGroup(Group g)
        {
            for (g.getStor().first(); g.getStor().eol() != true; g.getStor().next())
                g.getStor().get_curr().accept(this);
        }

        private void chooseCol(IShape IS, Pen pen)
        {
            if (IS.Selected())
                pen.Color = Color.Blue;
            else if (IS.Selected() == false)
            {
                if (IS.getColour() == 1)
                    pen.Color = Color.Blue;
                if (IS.getColour() == 2)
                    pen.Color = Color.Red;
                if (IS.getColour() == 3)
                    pen.Color = Color.Green;
                if (IS.getColour() == 4)
                    pen.Color = Color.Black;
                if (IS.getColour() == 5)
                    pen.Color = Color.Violet;
            }
            pen.Width = 3;
        }
    }
}
