using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    class Command
    {
        public virtual void execute() { }
        public virtual void Rexecute() { }
        public virtual void unexecute() { }
        public virtual Command clone() { return null; }
        public virtual bool check() { return false; }
        public virtual string name() { return "s"; }
        public virtual bool isA(string s) { return false; }
    };

}
