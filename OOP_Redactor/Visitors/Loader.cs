using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    class Loader: IVisitor
    {
        private string[] x;
        private Factory _fac;
        private StreamReader sr;
        public Loader(string[] strok, StreamReader _sr, Factory f)
        {
            x = strok;
            _fac = f;
            sr = _sr;
        }
        public void visitCircle(Circle c)
        {
            c.X = int.Parse(x[1]);
            c.Y = int.Parse(x[2]);
            c.Diam = int.Parse(x[3]);
            c.chosen = bool.Parse(x[4]);
            c.colour = int.Parse(x[5]);
            c.sticky = bool.Parse(x[6]);
        }
        public void visitSquare(Square s)
        {
            s.X = int.Parse(x[1]);
            s.Y = int.Parse(x[2]);
            s.Diam = int.Parse(x[3]);
            s.chosen = bool.Parse(x[4]);
            s.colour = int.Parse(x[5]);
            s.sticky = bool.Parse(x[6]);
        }
        public void visitLine(Line l)
        {
            l.X = int.Parse(x[1]);
            l.Y = int.Parse(x[2]);
            l.Diam = int.Parse(x[3]);
            l.chosen = bool.Parse(x[4]);
            l.colour = int.Parse(x[5]);
            l.sticky = bool.Parse(x[6]);
        }
        public void visitGroup(Group g)
        {
            string line;
            int j = 2;
            List<int> l = new List<int>();
            while (x[j] != "endl")
            {
                l.Add(int.Parse(x[j]));
                j++;
            }
            g.ind_list(l);
            for (int i = 0; i < int.Parse(x[1]);)
            {
                line = sr.ReadLine();
                line = line.TrimStart(new char[] { ' ' });
                string[] stroka = line.Split(' ');
                if ((line.Equals("}") == false && (line.Equals("{") == false)))
                {
                    i++;
                    IShape new1 = _fac.createShape(stroka[0]);
                    Loader k = new Loader(stroka, this.sr, this._fac);
                    new1.accept(k);
                    g.addShape(new1);
                }
            }
        }
    }
}
