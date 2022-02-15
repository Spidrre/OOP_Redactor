using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Redactor
{
    class My_TreeNodeCommand:Command
    {
        private My_TreeNode _selection;
        private Storage _stor;
        private Selector sel;
        private Form1 kek1;
        private bool lol;
        private string _name;
        public My_TreeNodeCommand(Storage _new, Form1 l)
        {
            kek1 = l;
            _selection = null;
            _name = "My_TreeNodeCommand";
            _stor = _new;
            sel = new Selector();
        }
        public override void execute()
        {
            My_TreeNode k1 = (My_TreeNode)kek1.k.GetNodeAt(kek1.k.PointToClient(Cursor.Position));
            _selection = k1;

            if (_selection.Checked)
                lol = true;
            else lol = false;
            if (_selection != kek1.k.Nodes[0])
            {
                //while (node_checker(_selection, (My_TreeNode)kek1.k.Nodes[0]) == false)
                //{
                //    _selection = (My_TreeNode)_selection.Parent;
                //}
                //_selection.Checked = lol;
                this.CheckAllChildNodes(_selection, lol);
            }
            else
            {
                //this.CheckAllChildNodes(k1, lol);
                if (_selection.Checked)
                    _selection.Checked = false;
                else _selection.Checked = true;
            }

        }
        public override void unexecute()
        {
            _selection.Checked = !lol;
            if (_selection != null)
                this.CheckAllChildNodes(_selection, _selection.Checked);
        }
        public override void Rexecute()
        {
            _selection.Checked = lol;
            this.CheckAllChildNodes(_selection, lol);
        }
        private void CheckAllChildNodes(My_TreeNode treeNode, bool nodeChecked)
        {
            treeNode.NotifyAll();
            foreach (My_TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
        public override Command clone()
        {
            return new My_TreeNodeCommand(_stor, kek1);
        }
        public override string name()
        {
            return _name;
        }
        public override bool isA(string s)
        {
            return s == "My_TreeNodeCommand";
        }


        private bool node_checker(My_TreeNode tr1, My_TreeNode tr2)
        {
            for (int i = 0; i < tr2.Nodes.Count; i++)
                if (tr1 == tr2.Nodes[i])
                    return true;
            return false;
        }

        private void lol_whaat(My_TreeNode tn, Stack<int> stack)
        {
            if (stack.Count != 0)
            {
                int a = stack.Pop();
                lol_whaat((My_TreeNode)tn.Nodes[a], stack);
            }
            else
            {
                this.CheckAllChildNodes(tn, tn.Checked);
            }
        }
    }
}
