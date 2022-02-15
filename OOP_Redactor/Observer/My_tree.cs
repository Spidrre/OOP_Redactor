using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace OOP_Redactor
{
    public class My_tree: TreeView, IMObserver
    {
        public void onSubjChange(Subj who) 
        {
            this.Nodes.Clear();
            Storage stor = (Storage)who;
            if (stor.length() != 0)
            {
                My_TreeNode main = new My_TreeNode("Storage (" + stor.length().ToString() + ")");
                for (stor.first(); stor.eol() != true; stor.next())
                {
                    u_nude(main, stor.get_curr());
                }
                this.Nodes.Add(main);
                main.ExpandAll();
            }
        }

        private void u_nude(My_TreeNode main, IShape jsh)
        {
            string s = "";
            {
                if (jsh.getColour() == 1)
                    s = "Blue";
                if (jsh.getColour() == 2)
                    s = "Red";
                if (jsh.getColour() == 3)
                    s = "Green";
                if (jsh.getColour() == 4)
                    s = "Black";
                if (jsh.getColour() == 5)
                    s = "Violet";
            }
            if (jsh.Stickiness())
                s += " Sticky";
            s += " " + jsh.Name();


            My_TreeNode driveNode = new My_TreeNode(s);
            driveNode.Checked = jsh.Selected();
            driveNode.addObs(jsh);
            if (jsh.Name() == "Group")
            {
                for (jsh.getStor().first(); jsh.getStor().eol() != true; jsh.getStor().next())
                {
                    u_nude(driveNode, jsh.getStor().get_curr());
                }
            }

            main.Nodes.Add(driveNode);
        }

        public void onSubjChange(IVisitor a)
        {

        }
    }
}
