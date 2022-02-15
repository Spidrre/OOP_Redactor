using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    class StickyCommand2 : Command
    {
        private IShape _selection;
        private List<IShape> _selection1;
        private List<IShape> _selection2;
        private Storage _stor;
        private Sticker sel;
        private string _name;
        private Form1 kek1;
        public StickyCommand2(Storage _new, Form1 l)
        {
            kek1 = l;
            _selection = null;
            _selection1 = new List<IShape>();
            _name = "SelectionCommand";
            _stor = _new;
            sel = new Sticker();
        }
        public override void execute()
        {
            for (int i = _stor.length() - 1; i >= 0; i--)
                if (_stor.get_element(i).Stickiness() && _stor.get_element(i).Selected())
                {
                    _selection1.Add(_stor.get_element(i));
                    _stor.get_element(i).removeTypeObs("notNode");
                    _stor.get_element(i).accept(sel);
                }
        }
        public override void unexecute()
        {
            _selection2 = new List<IShape>();
            foreach (IShape a in _selection1)
            {
                _selection2.Add(a);
                a.removeTypeObs("");
                a.accept(sel);
            }
        }
        public override void Rexecute()
        {
            _selection1.Clear();
            foreach (IShape a in _selection2)
            {
                _selection1.Add(a);
                a.accept(sel);
            }
        }
        public override Command clone()
        {
            return new StickyCommand2(_stor, kek1);
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
