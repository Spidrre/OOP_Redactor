using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Redactor
{
    class LoadCommand: Command
    {
        private Storage _stor;
        private Storage _rtos;
        private Form1 a;
        private string _name;
        private string _path;
        private int leg;
        public LoadCommand(Storage _new, Form1 _a)
        {
            _name = "LoadCommand";
            _stor = _new;
            _rtos = new Storage();
            a = _a;
        }

        public override void execute()
        {
            string _path = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _path = ofd.FileName;
            }
            leg = _stor.length();
            Factory _fac = new Factory();
            using (StreamReader sr = new StreamReader(_path))
            {               
                int l = int.Parse(sr.ReadLine());
                string line;
                for (int i = 0; i < l;)
                {
                    line = sr.ReadLine();
                    line = line.TrimStart(new char[] { ' ' });
                    string[] stroka = line.Split(' ');                   
                    if ((line.Equals("}") == false && (line.Equals("{") == false)))
                    {
                        Loader loa = new Loader(stroka, sr, _fac);
                        i++;
                        IShape new1 = _fac.createShape(stroka[0]);
                        new1.accept(loa);
                        _stor.Add(new1);
                        _rtos.Add(new1);
                    }
                }
                Mover a1 = new Mover(0, 0, a.pictureBox1.Height, a.pictureBox1.Width);
                Mover a2 = new Mover(0, 0, a.pictureBox1.Height, a.pictureBox1.Width, "");
                for (int i=0; i<_stor.length(); i++)
                {
                    if (_stor.get_element(i).Stickiness())
                        glue(i);
                        
                }
            }
        }

        public override void unexecute()
        {
           for (int i= _stor.length()-1; i >= leg; i--)
           {
                _stor.Delete(i);
           }
        }

        public override void Rexecute()
        {
            leg = _stor.length();
            for (_rtos.first(); _rtos.eol() != true; _rtos.next())
                _stor.Add(_rtos.get_curr());
        }

        public override Command clone()
        {
            return new LoadCommand(_stor, a);
        }

        public override string name()
        {
            return _name;
        }


        private void glue(int num)
        {
            for (int i = _stor.length() - 1; i >= 0; i--)
            {
                if (_stor.get_element(num).findObs(_stor.get_element(i)) == false)
                {
                    if (i != num)
                    {
                        if (_stor.get_element(i).isA("Group"))
                        {
                            if (is_group(_stor.get_element(num), _stor.get_element(i)))
                            {
                                _stor.get_element(i).addObs(_stor.get_element(num));
                                _stor.get_element(num).addObs(_stor.get_element(i));
                            }
                        }
                        else
                        {
                            if (not_group(_stor.get_element(num), _stor.get_element(i)))
                            {
                                _stor.get_element(i).addObs(_stor.get_element(num));
                                _stor.get_element(num).addObs(_stor.get_element(i));
                            }
                        }
                    }
                }
            }
        }

        private bool not_group(IShape st, IShape a)
        {
            int a1 = Math.Abs(a.getX() - st.getX());
            int a2 = Math.Abs(a.getY() - st.getY());
            int a3 = a1 * a1 + a2 * a2;
            int b = a.getDiam() / 2 + st.getDiam() / 2;
            return (a3 <= (b * b));
        }

        private bool is_group(IShape st, IShape gr)
        {
            bool flag = false;
            for (gr.getStor().first(); gr.getStor().eol() != true; gr.getStor().next())
            {
                if (gr.getStor().get_curr().isA("Group"))
                {
                    if (is_group(st, gr.getStor().get_curr()))
                        flag = true;
                }
                else
                {
                    if (not_group(st, gr.getStor().get_curr()))
                        flag = true;
                }
                if (flag == true)
                {
                    break;
                }
            }
            return flag;
        }
    }
}
