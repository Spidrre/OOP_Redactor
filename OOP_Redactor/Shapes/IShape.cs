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
    //interface IShape
    //{
    //    int getColour();
    //    bool inShape(MouseEventArgs e);
    //    bool Selected();
    //    bool isA(string s);
    //    Storage getStor();
    //    string Name();
    //    void loadShape(StreamReader sr, string[] x, Factory _fac);
    //    void accept(IVisitor vs);
    //}

    public class IShape : Subj, NodeObs, IMObserver
    {
        public virtual int getColour() { return 10; }
        public virtual int getDiam() { return 10; }
        public virtual int getX() { return 10; }
        public virtual int getY() { return 10; }
        public virtual bool inShape(int X, int Y) { return false; }
        public virtual bool Selected() { return false; }
        public virtual bool Stickiness() { return false; }
        public virtual bool isA(string s) { return false; }
        public virtual Storage getStor() { return null; }
        public virtual string Name() { return null; }
        public virtual void loadShape(StreamReader sr, string[] x, Factory _fac) { }
        public virtual void accept(IVisitor vs) { }
        public void onSubjChange(My_TreeNode who)
        {
            Selector wer = new Selector("a", who.Checked);
            this.accept(wer); 
        }
        public void onSubjChange(IVisitor a)
        {
            this.accept(a);
        }
        public void onSubjChange(Subj a)
        {
            
        }
    }
}