using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    class Selector : IVisitor
    {
        private bool flag;
        private bool flag2;
        private string m = "";
        public Selector()
        {
            flag = true;
        }
        public Selector(int m)
        {
            flag = false;
        }
        public Selector(string s, bool fl)
        {
            m = s;
            flag2 = fl;
        }
        public void visitCircle(Circle c)
        {
            if (m!="")
            {
                c.chosen = flag2;
            }
            else
            {
                if (c.chosen == true)
                    c.chosen = false;
                else c.chosen = true;
                if (flag)
                    c.NotifyAll();
            }
        }
        public void visitSquare(Square s)
        {
            if (s.chosen == true)
                s.chosen = false;
            else s.chosen = true;
            if (flag)
                s.NotifyAll();
        }
        public void visitLine(Line l)
        {
            if (l.chosen == true)
                l.chosen = false;
            else l.chosen = true;
            if (flag)
                l.NotifyAll();
        }
        public void visitGroup(Group g)
        {
            if (m != "")
            {
                for (g.getStor().first(); g.getStor().eol() != true; g.getStor().next())
                    g.getStor().get_curr().accept(new Selector(m, flag2));
            }
            else
            {
                for (g.getStor().first(); g.getStor().eol() != true; g.getStor().next())
                    g.getStor().get_curr().accept(new Selector(1));
                if (flag)
                    g.NotifyAll();
            }
        }
    }
}