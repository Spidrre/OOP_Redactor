using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    class Saver:IVisitor
    {
        private string path;
        private int depth;
        public Saver(string Wpath, int _d)
        {
            path = Wpath;
            depth = _d;
        }
        public void visitCircle(Circle c)
        {
            string text = "C " + c.X.ToString() + " " + c.Y.ToString() + " " + c.Diam.ToString() + " " + c.chosen.ToString() + " " + c.colour.ToString() + " " + c.sticky.ToString();
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(text);
            }
        }
        public void visitSquare(Square s)
        {
            string text = "S " + s.X.ToString() + " " + s.Y.ToString() + " " + s.Diam.ToString() + " " + s.chosen.ToString() + " " + s.colour.ToString() + " " + s.sticky.ToString();
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(text);
            }
        }
        public void visitLine(Line l)
        {
            string text = "L " + l.X.ToString() + " " + l.Y.ToString() + " " + l.Diam.ToString() + " " + l.chosen.ToString() + " " + l.colour.ToString() + " " + l.sticky.ToString();
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(text);
            }
        }
        public void visitGroup(Group g)
        {
            int zap = depth;
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                string t = "G " + g.getStor().length().ToString();
                foreach (int f in g.get_ind())
                    t += " " + f.ToString();
                t += " endl";
                sw.WriteLine(t);
                for (int j = 0; j < depth; j++)
                {
                    string k = "  ";
                    sw.Write(k);
                }
                sw.WriteLine("{");
            }
            depth++;
            for (g.getStor().first(); g.getStor().eol() != true; g.getStor().next())
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    for (int j = 0; j < depth; j++)
                    {
                        string k = "  ";
                        sw.Write(k);
                    }
                }
                g.getStor().get_curr().accept(this);
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int j = 0; j < depth - 1; j++)
                {
                    string k = "  ";
                    sw.Write(k);
                }
                string t = "}";
                sw.WriteLine(t);
            }
            depth = zap;
        }
    }
}
