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
using System.Drawing.Drawing2D;

namespace OOP_Redactor
{
    public class Square : IShape
    {
        //public int X { get; set; }
        //public int Y { get; set; }
        //public int Diam { get; set; }
        //public override bool chosen { get; set; }
        //public override int colour { get; set; }
        //public Form1 my_form { get; set; }
        public int X;
        public int Y;
        public int Diam;
        public int colour;
        public bool chosen;
        public bool sticky;
        public Square(int x, int y, int color, int diam) : base()
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
            vs.visitSquare(this);
        }

        public override bool inShape(int X, int Y)
        {
            bool flag = false;
            int newX2 = Math.Abs(X - (this.X));
            int newY2 = Math.Abs(Y - (this.Y));
            int coord = (newX2) + (newY2);
            int Rad2 = ((this.Diam) / 2);

            if (coord <= Rad2)
            {
                flag = true;
            }
            return flag;
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

        public override string Name()
        {
            return "Square";
        }
        public override bool isA(string s) { return s == "Square"; }
        public override int getColour() { return colour; }
        public override Storage getStor() { return null; }
    }
}