using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    class DeleteCommand: Command
    {
        private IShape _selection;
        private Storage _stor;
        private Storage _zap;
        private List<int> ind;
        private string _name;
        private int i;
        public DeleteCommand(Storage _new)
        {   
            _name = "DeleteCommand";
            _selection = null;
            _stor = _new;
        }
        public override void execute()
        {
            ind = new List<int>();
            _zap = new Storage();
            for (int p = _stor.length() - 1; p >= 0; p--)
            {
                if (_stor.get_element(p).Selected())
                {
                    _zap.Add(_stor.get_element(p));
                    ind.Add(p);
                    _stor.Delete(p);                   
                }
            }
        }
        public override void unexecute()
        {
            ind.Sort();
            _zap.swap();
            _zap.first();
            foreach (int i in ind)
            {
                _stor.insert_at(i, _zap.get_curr());
                _zap.next();
            }
        }
        public override void Rexecute()
        {
            ind.Sort(new SortIntDescending());
            foreach (int i in ind)
            {
                _stor.Delete(i);
            }
        }
        public override Command clone()
        {
            return new DeleteCommand(_stor);
        }
        public override string name()
        {
            return _name;
        }
        public override bool isA(string s)
        {
            return s == "DeleteCommand";
        }
        public override bool check()
        {
            return false;
        }
    }
}
