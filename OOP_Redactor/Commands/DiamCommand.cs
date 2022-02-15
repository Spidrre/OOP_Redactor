using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Redactor
{
    class DiamCommand : Command
    {
        private List<IShape> _selection;
        private Form kek;
        private Diametr di;
        private Storage _stor;
        private int _dx;
        private int _height;
        private int _width;
        private string _name;
        public DiamCommand(int dx, Storage _new)
        {
            _stor = _new;
            _dx = dx;            
            _selection = null;
            kek = Form1.ActiveForm;
            if (kek != null)
            {
                _height = kek.ClientSize.Height;
                _width = kek.ClientSize.Width;
            }
            _selection = new List<IShape>();
            if (_dx < 0)
                _name = "-";
            if (_dx > 0)
                _name = "+";
        }
        public override void execute()
        {
            di = new Diametr(_dx, _height, _width);
            for (int i = _stor.length() - 1; i >= 0; i--)
                if (_stor.get_element(i).Selected())
                {
                    if (di.checker(_stor.get_element(i)) == false)
                    {
                        {
                            _selection.Add(_stor.get_element(i));
                            _stor.get_element(i).accept(di);
                        }
                    }
                }
        }
        public override void Rexecute()
        {
            di = new Diametr(_dx, _height, _width);
            foreach (IShape s in _selection)
                s.accept(di);
        }
        public override void unexecute()
        {
            di = new Diametr(-_dx, _height, _width);
            foreach (IShape s in _selection)
                s.accept(di);
        }
        public override Command clone()
        {
            return new DiamCommand(_dx, _stor);
        }
        public override string name()
        {
            return _name;
        }
        public override bool isA(string s)
        {
            return s == "DiamCommand";
        }
    };
}
