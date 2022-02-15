using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OOP_Redactor
{
    //class Group: IShape
    //{
    //    public Storage _shapes;
    //    private List<int> l;
    //    public Group() : base()
    //    {
    //        _shapes = new Storage();
    //    }

    //    public void accept(IVisitor vs)
    //    {
    //        vs.visitGroup(this);
    //    }

    //    public void addShape(IShape sh)
    //    {
    //        getStor().Add(sh);
    //    }

    //    public bool inShape(MouseEventArgs e)
    //    {
    //        bool kek = false;
    //        for (getStor().first(); getStor().eol() != true; getStor().next())
    //        {
    //            if (getStor().get_curr().inShape(e))
    //            {
    //                kek = true;
    //                break;
    //            }
    //        }
    //        return kek;
    //    }

    //    public bool Selected()
    //    {
    //        getStor().first();
    //        return getStor().get_curr().Selected();
    //    }

    //    public Storage getStor()
    //    {
    //        return _shapes;
    //    }

    //    public bool isA(string s)
    //    {
    //        return (s == "Group");
    //    }

    //    public void ind_list(List<int> _list)
    //    {
    //        l = new List<int>();
    //        foreach (int i in _list)
    //        {
    //            l.Add(i);
    //        }
    //    }

    //    public List<int> get_ind()
    //    {
    //        return l;
    //    }

    //    public string Name()
    //    {
    //        return "Group";
    //    }

    //    public void loadShape(StreamReader sr, string[] x, Factory _fac)
    //    {
    //        string line;
    //        int j = 2;
    //        l = new List<int>();
    //        while (x[j] != "endl")
    //        {
    //            l.Add(int.Parse(x[j]));
    //            j++;
    //        }
    //        for (int i = 0; i < int.Parse(x[1]);)
    //        {
    //            line = sr.ReadLine();
    //            line = line.TrimStart(new char[] { ' ' });
    //            string[] stroka = line.Split(' ');
    //            if ((line.Equals("}") == false && (line.Equals("{") == false)))
    //            {
    //                i++;
    //                IShape new1 = _fac.createShape(stroka[0]);
    //                new1.loadShape(sr, stroka, _fac);
    //                getStor().Add(new1);
    //            }
    //        }
    //    }

    //    public int getColour() { return getStor().get_element(0).getColour(); }
    //}



    public class Group : IShape
    {
        public Storage _shapes;
        private List<int> l;
        public Group() : base()
        {
            _shapes = new Storage();
        }

        public override void accept(IVisitor vs)
        {
            vs.visitGroup(this);
        }

        public void addShape(IShape sh)
        {
            getStor().Add(sh);
        }

        public override bool inShape(int x, int y)
        {
            bool kek = false;
            for (getStor().first(); getStor().eol() != true; getStor().next())
            {
                if (getStor().get_curr().inShape(x,y))
                {
                    kek = true;
                    break;
                }
            }
            return kek;
        }

        public override bool Selected()
        {
            bool flag = false;

            for (getStor().first(); getStor().eol() != true; getStor().next())
            {
                if (getStor().get_curr().Selected())
                {
                    flag = true;
                    return flag;
                }
            }
            return flag;
            //getStor().first();
            //return getStor().get_curr().Selected();
        }

        public override bool Stickiness()
        {
            return getStor().get_element(0).Stickiness();
        }

        public override Storage getStor()
        {
            return _shapes;
        }

        public override bool isA(string s)
        {
            return (s == "Group");
        }

        public void ind_list(List<int> _list)
        {
            l = new List<int>();
            foreach (int i in _list)
            {
                l.Add(i);
            }
        }

        public List<int> get_ind()
        {
            return l;
        }

        public override string Name()
        {
            return "Group";
        }

        public override int getColour() { return getStor().get_element(0).getColour(); }
    }
}