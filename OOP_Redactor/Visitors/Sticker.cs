using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    class Sticker: IVisitor
    {
        public void visitCircle(Circle c)
        {
            if (c.sticky == true)
                c.sticky = false;
            else c.sticky = true;
            c.NotifyAll();
        }
        public void visitSquare(Square s)
        {
            if (s.sticky == true)
                s.sticky = false;
            else s.sticky = true;
        }
        public void visitLine(Line l)
        {
            if (l.sticky == true)
                l.sticky = false;
            else l.sticky = true;
        }
        public void visitGroup(Group g)
        {
            for (g.getStor().first(); g.getStor().eol() != true; g.getStor().next())
                g.getStor().get_curr().accept(this);
        }
    }
}
