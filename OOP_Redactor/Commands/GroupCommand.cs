using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    class GroupCommand: Command
    {
        private Storage _stor;
        private Storage _zap;
        private Group _group;
        private List<int> ind;
        private string _name;
        private int leng;
        public GroupCommand(Storage _new)
        {
            _name = "CreateCommand";
            _stor = _new;
        }
        public override void execute()
        {
            _zap = new Storage();
            ind = new List<int>();
            _group = new Group();
            int k = _stor.length();
            for (int i = k - 1; i >= 0; i--)
            {
                if (_stor.get_element(i).Selected() && _stor.get_element(i).Stickiness()==false)
                {
                    ind.Add(i);
                    _group.addShape(_stor.get_element(i));
                    _stor.Delete(i);
                }
            }
            _group.getStor().swap();
            _group.ind_list(ind);
            _stor.Add(_group);
            leng = _stor.length() - 1;
        }
        public override void unexecute()
        {
            _zap = _group.getStor();
            _stor.Delete(leng);
            ind.Sort();
            _zap.first();
            foreach (int i in ind)
            {
                _stor.insert_at(i, _zap.get_curr());
                _zap.next();
            }
        }

        public override Command clone()
        {
            return new GroupCommand(_stor);
        }
        public override string name()
        {
            return _name;
        }
    }
}
