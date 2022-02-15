using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    public interface IVisitor
    {
        void visitCircle(Circle c);
        void visitSquare(Square s);
        void visitLine(Line l);
        void visitGroup(Group g);
    }
}
