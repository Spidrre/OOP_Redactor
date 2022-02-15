using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    public class SortIntDescending : IComparer<int>
    {
        int IComparer<int>.Compare(int a, int b)
        {
            if (a > b)
                return -1;
            if (a < b)
                return 1;
            else
                return 0;
        }
    }
}
