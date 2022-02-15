using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Redactor
{
    class UngroupCommand: Command
    {
        private Storage _stor;
        private Storage _zap;
        private List<int> ind;
        private List<int> dni;
        private string _name;
        public UngroupCommand(Storage _new)
        {
            _name = "CreateCommand";
            _stor = _new;
        }
        public override void execute()
        {
            _zap = new Storage();
            ind = new List<int>();
            dni = new List<int>();
            //dni.Add(_stor.length());
            int y = _stor.length();

            for (int i = y - 1; i >= 0; i--)
            {
                if (_stor.get_element(i).isA("Group") && _stor.get_element(i).Selected() && chto_eto(dni, i))
                {
                    _zap.Add(_stor.get_element(i));
                    ind.Add(i);
                    Group kek = (Group)_stor.get_element(i);
                    _stor.Delete(i);
                    List<int> t = new List<int>();
                    List<int> r = kek.get_ind();
                    foreach (int h in r)
                    {
                        t.Add(h);
                    }
                    t.Sort();

                    kek.getStor().first();
                    foreach (int o in t)
                    {
                        for (int g = 0; g < dni.Count; g++)
                        {
                            if (dni[g] >= o)
                            {
                                dni[g]++;
                            }
                        }
                        i++;
                        dni.Add(o);
                        _stor.insert_at(o, kek.getStor().get_curr());
                        kek.getStor().next();
                    }
                }
            }
        }

        private bool chto_eto(List<int> dni, int e)
        {
            for (int g = 0; g < dni.Count; g++)
            {
                if (dni[g] == e)
                    return false;
            }
            return true;
        }

        public override void unexecute()
        {
            _zap.swap();
            ind.Sort();
            _zap.first();
            foreach (int i in ind)
            {
                Group kek = (Group)_zap.get_curr();
                List<int> t = new List<int>();
                List<int> r = kek.get_ind();
                r.Sort(new SortIntDescending());
                foreach (int h in r)
                {
                    _stor.Delete(h);
                }
                _stor.Add(_zap.get_curr());
                _zap.next();
            }
        }

        public override Command clone()
        {
            return new UngroupCommand(_stor);
        }
        public override string name()
        {
            return _name;
        }
    }
}
