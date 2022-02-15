using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Redactor
{
    class SelectionCommand : Command
    {
        private IShape _selection;
        private Storage _stor;
        private Selector sel;
        private string _name;
        private Form1 kek1;
        private int X;
        private int Y;
        public SelectionCommand(Storage _new, Form1 l)
        {
            kek1 = l;
            _selection = null;
            _name = "SelectionCommand";
            _stor = _new;
            sel = new Selector();
        }
        public override void execute()
        {
            Point coordinates = kek1.PointToClient(Cursor.Position);
            X = coordinates.X - kek1.pictureBox1.Location.X;
            Y = coordinates.Y - kek1.pictureBox1.Location.Y;
            for (int i = _stor.length() - 1; i >= 0; i--)
                if (_stor.get_element(i).inShape(X, Y))
                {               
                    _selection = _stor.get_element(i);
                    _stor.get_element(i).accept(sel);
                    return;
                }
        }
        public override void unexecute()
        {
            if (_selection!=null)
                _selection.accept(sel);
        }
        public override void Rexecute()
        {
            _selection.accept(sel);
        }
        public override Command clone()
        {
            return new SelectionCommand(_stor, kek1);
        }
        public override string name()
        {
            return _name;
        }
        public override bool isA(string s)
        {
            return s == "SelectionCommand";
        }
    }
}
