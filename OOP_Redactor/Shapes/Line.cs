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
    public class Line : IShape
    {
        public int X;
        public int Y;
        public int Diam;
        public int colour;
        public bool chosen;
        public bool sticky;

        public Line(int x, int y, int color, int diam) : base()
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
            vs.visitLine(this);
        }

        public override bool inShape(int X, int Y)
        {
            bool flag = false;
            if ((X > this.X - this.Diam / 2) && (X < this.X + this.Diam / 2) && (Y == this.Y))
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

        public override string Name()
        {
            return "Line";
        }

        public override bool isA(string s) { return s == "Line"; }
        public override int getColour() { return colour; }
        public override Storage getStor() { return null; }
    }
}