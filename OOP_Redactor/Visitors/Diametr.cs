using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    class Diametr: IVisitor
    {
        private int _dx;
        private int height;
        private int width;
        public Diametr(int dx, int _height, int _width)
        {
            _dx = dx;
            height = _height;
            width = _width;
        }
        public void visitCircle(Circle c)
        {
            if (inC(c) == false)
            {
                c.Diam += _dx;
            }
        }
        public void visitSquare(Square s)
        {
            if (inS(s) == false)
            {
                s.Diam += _dx;
            }
        }
        public void visitLine(Line l)
        {
            if (inL(l) == false)
            {
                l.Diam += _dx;
            }
        }
        public void visitGroup(Group g)
        {
            for (g.getStor().first(); g.getStor().eol() != true; g.getStor().next())
                g.getStor().get_curr().accept(this);
        }

        public bool checker(IShape a)
        {
            if (a.isA("Circle"))
            {
                Circle c = (Circle)a;
                return inC(c);
            }
            else if (a.isA("Square"))
            {
                Square c = (Square)a;
                return inS(c);
            }
            else if (a.isA("Line"))
            {
                Line c = (Line)a;
                return inL(c);
            }
            else if (a.isA("Group"))
            {
                Group c = (Group)a;
                for (c.getStor().first(); c.getStor().eol() != true; c.getStor().next())
                {
                    if (checker(c.getStor().get_curr()))
                        return true;
                }
            }
            return false;
        }
        private bool inC(Circle c)
        {
            if (((c.X - ((c.Diam / 2) + _dx)) < 0))
            {
                return true;
            }
            if ((c.Y + ((c.Diam / 2) + _dx)) >= height)
            {
                return true;
            }

            if ((c.X + ((c.Diam / 2) + _dx)) >= width)
            {
                return true;
            }
            if (((c.Y - ((c.Diam / 2) + _dx)) <= 0))
            {
                return true;
            }
            if (c.Diam + _dx <= 0)
                return true;
            return false;
    }

        private bool inS(Square s)
        {
            if (((s.X - s.Diam / 2 + _dx) < 0))
                return true;
            if (((s.Y - s.Diam / 2 + _dx) < 0))
                return true;
            if ((s.X + s.Diam / 2 + _dx) > width)
                return true;
            if ((s.Y + s.Diam / 2 + _dx) > height)
                return true;


            if (s.Diam + _dx <= 0)
                return true;
            return false;
        }

        private bool inL(Line l)
        {
            if (((l.X - l.Diam / 2 + _dx) < 0))
                return true;
            if (((l.Y - l.Diam / 2 + _dx) < 0))
                return true;
            if ((l.X + l.Diam / 2 + _dx) > width)
                return true;
            if ((l.Y + l.Diam / 2 + _dx) > height)
                return true;

            if (l.Diam + _dx <= 0)
                return true;
            return false;
        }
    }
}
