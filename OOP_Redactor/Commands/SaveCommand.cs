using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Redactor
{
    class SaveCommand:Command
    {
        private Storage _stor;
        private Storage _rtos;
        private string _name;
        private string _path;
        private int leg;
        public SaveCommand(Storage _new)
        {
            _name = "SaveCommand";
            _stor = _new;
            _rtos = new Storage();
        }

        public override void execute()
        {
            string _path = "";
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    _path = ofd.FileName;
            //}
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            else
                _path = ofd.FileName;
            using (StreamWriter sw = new StreamWriter(_path, false))
                sw.WriteLine(_stor.length().ToString());
            int depth = 0;
            Saver sv = new Saver(_path, depth);
            for (_stor.first(); _stor.eol() != true; _stor.next())
                _stor.get_curr().accept(sv);
        }

        public override Command clone()
        {
            return new SaveCommand(_stor);
        }

        public override string name()
        {
            return _name;
        }
    }
}
