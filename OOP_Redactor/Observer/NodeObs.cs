using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    public interface NodeObs
    {
        void onSubjChange(My_TreeNode who);
    }
}
