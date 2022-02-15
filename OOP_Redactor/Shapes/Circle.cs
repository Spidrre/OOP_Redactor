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
    //class Circle : Subj, IShape
    //{
    //    public int X;
    //    public int Y;
    //    public int Diam;
    //    public int colour;
    //    public bool chosen;
    //    Form1 my_form;
    //    public Circle(int x, int y, int color, int diam) : base()
    //    {
    //        Diam = diam;
    //        this.X = x;
    //        this.Y = y;
    //        chosen = false;
    //        colour = color;
    //        my_form = new Form1();
    //    }

    //    public void accept(IVisitor vs)
    //    {
    //        vs.visitCircle(this);
    //    }

    //    public bool Selected()
    //    {
    //        NotifyAll();
    //        return chosen;
    //    }

    //    public bool inShape(MouseEventArgs e)
    //    {
    //        bool flag = false;
    //        int newX2 = Math.Abs(e.X - (this.X));
    //        int newY2 = Math.Abs(e.Y - (this.Y));
    //        int coord = ((newX2) * (newX2)) + ((newY2) * (newY2));
    //        int Rad2 = (((this.Diam) / 2) * ((this.Diam) / 2));

    //        if (coord <= Rad2)
    //        {
    //            flag = true;
    //        }
    //        return flag;
    //    }

    //    public void loadShape(StreamReader sr, string[] x, Factory _fac)
    //    {
    //        this.X = int.Parse(x[1]);
    //        this.Y = int.Parse(x[2]);
    //        this.Diam = int.Parse(x[3]);
    //        this.chosen = bool.Parse(x[4]);
    //        this.colour = int.Parse(x[5]);
    //    }
    //    public string Name()
    //    {
    //        return "Circle";
    //    }
    //    public bool isA(string s) { return false; }
    //    public int getColour() { return colour; }
    //    public Storage getStor() { return null; }

    //}


    public class Circle : IShape
    {
        public int X;
        public int Y;
        public int Diam;
        public int colour;
        public bool chosen;
        public bool sticky;
        public Circle(int x, int y, int color, int diam) : base()
        {
            Diam = diam;
            this.X = x;
            this.Y = y;
            chosen = false;
            sticky = false;
            colour = color;
        }

        public override void accept(IVisitor vs)
        {
            vs.visitCircle(this);
        }

        public override bool Selected()
        { 
            return chosen;
        }

        public override bool Stickiness()
        {
            return sticky;
        }

        public override int getDiam()
        {
            return Diam;
        }
        public override int getX()
        {
            return X;
        }
        public override int getY()
        {
            return Y;
        }

        public override bool inShape(int X, int Y)
        {
            bool flag = false;
            int newX2 = Math.Abs(X - (this.X));
            int newY2 = Math.Abs(Y - (this.Y));
            int coord = ((newX2) * (newX2)) + ((newY2) * (newY2));
            int Rad2 = (((this.Diam) / 2) * ((this.Diam) / 2));

            if (coord <= Rad2)
            {
                flag = true;
            }
            return flag;
        }

        public override string Name()
        {
            return "Circle";
        }
        public override bool isA(string s) { return s == "Circle"; }
        public override int getColour() { return colour; }
        public override Storage getStor() { return null; }

    }

}