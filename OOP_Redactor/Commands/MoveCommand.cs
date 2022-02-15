using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Redactor
{
    class MoveCommand : Command
    {
	    private List<IShape> _selection;
        private List<int> _stickyGuys;
        private Storage _stor;
        private int _dx; 
        private int _dy;
        private int _height;
        private int _width;
        private string _name;
        private bool glued;
        private Mover mov;
        private Mover mov1;
        private Form1 kek1;

        public MoveCommand(int dx, int dy, Storage _new, Form1 l)
        {            
            _stor = _new;
            _dx = dx;
            _dy = dy;
            kek1 = l;
            glued = false;
            
            if (kek1 != null)
            {
                _width = kek1.pictureBox1.Width;
                _height = kek1.pictureBox1.Height;
            }
            mov = new Mover(_dx, _dy, _height, _width);
            mov1 = new Mover(_dx, _dy, _height, _width, "");
            if (_dx < 0)
                _name = "A";
            if (_dy < 0)
                _name = "W";
            if (_dx > 0)
                _name = "D";
            if (_dy > 0)
                _name = "S";
        }
        public override void execute()
        {
            _selection = new List<IShape>();
            _stickyGuys = new List<int>();
            for (int i = _stor.length() - 1; i >= 0; i--)
            {
                if (_stor.get_element(i).Stickiness())
                {
                    _stickyGuys.Add(i);
                }
            }
            for (int i = _stor.length() - 1; i >= 0; i--)
                if (_stor.get_element(i).Selected())
                {
                    if (mov.checker(_stor.get_element(i)) == false)
                    {
                        if (_stor.get_element(i).Stickiness())
                        {
                            glue(i);
                            _stor.get_element(i).accept(mov1);
                        }
                        else
                        {
                            not_sticky_shape(i);
                            _stor.get_element(i).accept(mov);
                        }
                        _selection.Add(_stor.get_element(i));        
                    }
                }
        }


        private void not_sticky_shape(int num)
        {
            foreach (int i in _stickyGuys)
            {
                if (_stor.get_element(i).findObs(_stor.get_element(num)) == false)
                {
                    if (_stor.get_element(num).isA("Group"))
                    {
                        if (is_group(_stor.get_element(i), _stor.get_element(num)))
                        {
                            _stor.get_element(num).addObs(_stor.get_element(i));
                            _stor.get_element(i).addObs(_stor.get_element(num));
                            glued = true;
                        }
                    }
                    else
                    {
                        if (not_group(_stor.get_element(i), _stor.get_element(num)))
                        {
                            _stor.get_element(i).addObs(_stor.get_element(num));
                            _stor.get_element(num).addObs(_stor.get_element(i));
                            glued = true;
                        }
                    }
                }
            }
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
                                glued = true;
                            }
                        }
                        else
                        {
                            if (not_group(_stor.get_element(num), _stor.get_element(i)))
                            {
                                _stor.get_element(i).addObs(_stor.get_element(num));
                                _stor.get_element(num).addObs(_stor.get_element(i));
                                glued = true;
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
            for (gr.getStor().first(); gr.getStor().eol()!=true; gr.getStor().next())
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
                    kek1.groupBox1.Text = "a";
                    break;
                }
            }
            return flag;
        }


        public override void unexecute()
        {
            mov = new Mover(-_dx, -_dy, _height, _width);
            foreach (IShape s in _selection)
            {
                if (s.Stickiness())
                    s.accept(mov);
                else s.accept(mov1);
                if (glued)
                    s.removeAllObs();
            }
        }
        public override void Rexecute()
        {
            mov = new Mover(_dx, _dy, _height, _width);
            foreach (IShape s in _selection)
                s.accept(mov);
        }       
        public override Command clone()
        {
            return new MoveCommand(_dx, _dy, _stor, kek1);
        }
        public override string name()
        {
            return _name;
        }
        public override bool isA(string s)
        {
            return s == "MoveCommand";
        }
    };

}
