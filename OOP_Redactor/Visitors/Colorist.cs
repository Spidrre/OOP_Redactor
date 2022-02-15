using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    class Colorist:IVisitor
    {
        private int _col;
        public Colorist(int col)
        {
            _col = col;
        }
        public void visitCircle(Circle c)
        {
            c.colour = _col;
            c.NotifyAll();
        }
        public void visitSquare(Square s)
        {
            s.colour = _col;
            s.NotifyAll();
        }
        public void visitLine(Line l)
        {
            l.colour = _col;
            l.NotifyAll();
        }
        public void visitGroup(Group g)
        {
            for (g.getStor().first(); g.getStor().eol() != true; g.getStor().next())
                g.getStor().get_curr().accept(this);
            g.NotifyAll();
        }
    }
}
