using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Redactor
{
    class ColorCommand : Command
    {
        private Storage _stor;
        private List<int> cel = new List<int>();
        private IShape _selection;
        private Form1 kek1;
        Colorist cl;
        Colorist cl2;
        Selector sel;
        private string _name;
        private int _col;
        private int _cZap;
        private bool flag;
        private int X;
        private int Y;
        public ColorCommand(Storage _new, Form1 l)
        {
            kek1 = l;
            _col = kek1.colorDef;
            cl = new Colorist(_col);
            sel = new Selector();
            _name = _col.ToString();
            _selection = null;
            _stor = _new;
        }
        public override void execute()
        {
            Point coordinates = kek1.PointToClient(Cursor.Position);
            X = coordinates.X - kek1.pictureBox1.Location.X;
            Y = coordinates.Y - kek1.pictureBox1.Location.Y;
            for (int i = _stor.length() - 1; i >= 0; i--)
            {
                if (_stor.get_element(i).inShape(X, Y))
                {
                    _selection = _stor.get_element(i);
                    flag = false;
                    if (_selection.Selected())
                    {
                        flag = true;
                        _selection.accept(sel);
                    }
                    cl2 = new Colorist(_selection.getColour());
                    _selection.accept(cl);
                }
            }
        }
        public override void unexecute()
        {
            _selection.accept(cl2);
            if (flag)
            {
                _selection.accept(sel);
            }
        }
        public override void Rexecute()
        {
            flag = false;
            if (_selection.Selected())
            {
                flag = true;
                _selection.accept(sel);
            }
            cl2 = new Colorist(_selection.getColour());
            _selection.accept(cl);
        }
        public override Command clone()
        {
            return new ColorCommand(_stor, kek1);
        }
        public override string name() 
        {
            return _name;
        }
    }
}
