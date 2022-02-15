using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    class StickyCommand: Command
    {
        private IShape _selection;
        private List<IShape> _selection1;
        private Storage _stor;
        private Sticker sel;
        private string _name;
        private Form1 kek1;
        private bool flag = false;
        public StickyCommand(Storage _new, Form1 l)
        {
            kek1 = l;
            _selection = null;
            _name = "SelectionCommand";
            _stor = _new;
            sel = new Sticker();
        }
        public override void execute()
        {
            _selection1 = new List<IShape>();
            for (int i = _stor.length() - 1; i >= 0; i--)
                if (_stor.get_element(i).Selected())
                {
                    if (_stor.get_element(i).Stickiness() == false)
                    {
                        _selection1.Add(_stor.get_element(i));
                        _stor.get_element(i).accept(sel);
                    }
                }
        }
        public override void unexecute()
        {
            foreach (IShape a in _selection1)
            {
                a.removeTypeObs("");
                a.accept(sel);
            }
        }
        public override void Rexecute()
        {
            _selection1 = new List<IShape>();
            for (int i = _stor.length() - 1; i >= 0; i--)
                if (_stor.get_element(i).Selected())
                {
                    if (_stor.get_element(i).Stickiness() == false)
                    {
                        _selection1.Add(_stor.get_element(i));
                        _stor.get_element(i).accept(sel);
                    }
                }
        }
        public override Command clone()
        {
            return new StickyCommand(_stor, kek1);
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
