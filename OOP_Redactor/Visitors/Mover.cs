using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    class Mover: IVisitor
    {
        private int _dx;
        private int _dy;
        private int height;
        private int width;
        private bool flag=true;
        private bool st=false;
        private bool ntst=false;
        private IShape a;
        public Mover(int dx, int dy, int _height, int _width, string s)
        {
            _dx = dx;
            _dy = dy;
            height = _height;
            width = _width;
            st = true;
        }

        public Mover(int dx, int dy, int _height, int _width)
        {
            _dx = dx;
            _dy = dy;
            height = _height;
            width = _width;
            ntst = true;
        }

        public Mover(int dx, int dy, int _height, int _width, bool a)
        {
            _dx = dx;
            _dy = dy;
            height = _height;
            width = _width;
            flag = false;
        }

        public Mover(int dx, int dy, int _height, int _width, bool w, IShape b)
        {
            _dx = dx;
            _dy = dy;
            height = _height;
            width = _width;
            flag = false;
            a = b;
        }

        public void visitCircle(Circle c)
        {
            if (inC(c)==false)
            {
                c.X += _dx;
                c.Y += _dy;
                if (flag == false)
                {
                    if (c.Stickiness())
                    {
                        c.NotifyAllButThis(new Mover(_dx, _dy, height, width, true), a);
                    }
                    return;
                }

                if (st)
                {
                    c.NotifyAll(new Mover(_dx, _dy, height, width, true, c));
                    return;
                }

                if (ntst)
                {
                    c.NotifyAll(new Mover(_dx, _dy, height, width, true, c));
                    return;
                }
            }
        }
        public void visitSquare(Square s)
        {
            if (inS(s) == false)
            {
                s.X += _dx;
                s.Y += _dy;
                if (flag == false)
                {
                    if (s.Stickiness())
                    {
                        s.NotifyAllButThis(new Mover(_dx, _dy, height, width, true), a);
                    }
                    return;
                }


                if (st)
                {
                    s.NotifyAll(new Mover(_dx, _dy, height, width, true, s));
                    return;
                }

                if (ntst)
                {
                    s.NotifyAll(new Mover(_dx, _dy, height, width, true, s));
                    return;
                }
            }
        }
        public void visitLine(Line l)
        {
            if (inL(l) == false)
            {
                l.X += _dx;
                l.Y += _dy;
            }
        }
        public void visitGroup(Group g)
        {
            for (g.getStor().first(); g.getStor().eol() != true; g.getStor().next())
            {
                g.getStor().get_curr().accept(new Mover(_dx, _dy, height, width));
            }
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
            if (c.Y + _dy < c.Diam / 2)
            {
                c.Y = c.Diam / 2 + 1;
                return true;
            }
            if (c.X + _dx < c.Diam / 2)
            {
                c.X = c.Diam / 2 + 1;
                return true;
            }
            if (c.Y + _dy > height - c.Diam / 2)
            {
                c.Y = height - 1 - c.Diam / 2;
                return true;
            }
            if (c.X + _dx > width - c.Diam / 2)
            {
                c.X = width - 1 - c.Diam / 2;
                return true;
            }
            return false;
        }

        private bool inS(Square s)
        {
            if (s.Y + _dy < s.Diam / 2)
            {
                s.Y = s.Diam / 2 + 1;
                return true;
            }
            if (s.X + _dx < s.Diam / 2)
            {
                s.X = s.Diam / 2 + 1;
                return true;
            }
            if (s.Y + _dy > height - s.Diam / 2)
            {
                s.Y = height - 1 - s.Diam / 2;
                return true;
            }
            if (s.X + _dx > width - s.Diam / 2)
            {
                s.X = width - 1 - s.Diam / 2;
                return true;
            }
            return false;
        }

        private bool inL(Line l)
        {
            if (l.Y + _dy < 3)
            {
                l.Y = 3;
                return true;
            }
            if (l.X + _dx < l.Diam / 2)
            {
                l.X = l.Diam / 2;
                return true;
            }
            if (l.Y + _dy > height - 4)
            {
                l.Y = height - 4;
                return true;
            }
            if (l.X + _dx > width - l.Diam / 2)
            {
                l.X = width - l.Diam / 2 - 1;
                return true;
            }
            return false;
        }




    }
}
