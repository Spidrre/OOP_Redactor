using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    public class Node
    {
        public Node(IShape data)
        {
            obj = data;
        }
        public IShape obj;
        public Node next;
        public int id;
    }
}