using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    class DeleteAllCommand : Command
    {
        private Storage _stor;
        private Storage _zap;
        private string _name;
        public DeleteAllCommand(Storage _new)
        {
            _name = "DeleteAllCommand";
            _stor = _new;           
        }

        public override void execute()
        {
            _zap = new Storage();
            for (int p = _stor.length() - 1; p >= 0; p--)
            {
                _zap.Add(_stor.get_element(p));
                _stor.Delete(p);
            }
        }
        public override void unexecute()
        {
            _zap.swap();
            for (_zap.first(); _zap.eol() != true; _zap.next())
            {
                _stor.Add(_zap.get_curr());
            }
        }
        public override void Rexecute()
        {
            _zap = new Storage();
            for (int p = _stor.length() - 1; p >= 0; p--)
            {
                _zap.Add(_stor.get_element(p));
                _stor.Delete(p);
            }
        }
        public override Command clone()
        {
            return new DeleteAllCommand(_stor);
        }
        public override string name()
        {
            return _name;
        }
        public override bool isA(string s)
        {
            return s == "DeleteAllCommand";
        }
        public override bool check()
        {
            //_zap.first();
            //return (_zap.get_curr() == null);
            return false;
        }
    }
}
