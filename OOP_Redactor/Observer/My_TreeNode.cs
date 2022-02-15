using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Redactor
{
    public class My_TreeNode: TreeNode
    {
        private List<NodeObs> obs;
        public My_TreeNode(string s): base()
        {
            this.Text = s;
            obs = new List<NodeObs>();
        }
        public void addObs(NodeObs n)
        {
            obs.Add(n);
        }
        public void removeObs(NodeObs n)
        {
            obs.Remove(n);
        }
        public void NotifyAll()
        {
            foreach (NodeObs o in obs)
            {
                o.onSubjChange(this);
            }
        }

        public int cou()
        {
            return obs.Count;
        }
    }
}
