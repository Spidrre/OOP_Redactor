using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Redactor
{
    class CreateCommand: Command
    {
        private IShape _selection;
        private Storage _stor;
        private Form1 kek1;
        private int X;
        private int Y;
        private int col;
        private string _name;
        public CreateCommand(string n, Storage _new, Form1 l)
        {
            _name = n;
            _selection = null;
            _stor = _new;
            kek1 = l;
        }
        public override void execute()
        {
            Point coordinates = kek1.PointToClient(Cursor.Position);
            X = coordinates.X - kek1.pictureBox1.Location.X;
            Y = coordinates.Y - kek1.pictureBox1.Location.Y;
            for (int i = _stor.length() - 1; i >= 0; i--)
                if (_stor.get_element(i).inShape(X, Y))
                    return;
            if (_name == "Circle")
                _selection = new Circle(X, Y, kek1.colorDef, 100);
            else if (_name == "Square")
                _selection = new Square(X, Y, kek1.colorDef, 100);
            else
                _selection = new Line(X, Y, kek1.colorDef, 100);
            _stor.Add(_selection);
        }
        public override void unexecute()
        {
            _stor.Delete(_stor.length()-1);
        }
        public override void Rexecute()
        {
            _stor.Add(_selection);
        }
        public override Command clone()
        {
            return new CreateCommand(_name, _stor, kek1);
        }
        public override string name()
        {
            return _name;
        }
        public override bool check()
        {
            Point coordinates = kek1.PointToClient(Cursor.Position);
            X = coordinates.X - kek1.pictureBox1.Location.X;
            Y = coordinates.Y - kek1.pictureBox1.Location.Y;
            for (int i = _stor.length() - 1; i >= 0; i--)
                if (_stor.get_element(i).inShape(X, Y))
                    return true;
            return false;
        }
    }
}
