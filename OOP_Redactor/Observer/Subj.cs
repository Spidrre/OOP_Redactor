using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_Redactor
{
    public class Subj
    {
        private List<IMObserver> obs;
        public Subj()
        {
            obs = new List<IMObserver>();
        }
        public void addObs(IMObserver n)
        {
            obs.Add(n);
        }
        public void removeObs(IMObserver n)
        {
            obs.Remove(n);
        }

        public void removeAllObs()
        {
            obs.Clear();
            //obs = new List<IMObserver>();
        }

        public void removeTypeObs(string s)
        {
            var a = obs[0];
            obs = new List<IMObserver>();
            obs.Add(a);
        }

        public bool check_obs(IMObserver n)
        {
            return obs.Contains(n);
        }

        public void NotifyAll()
        {
            foreach (IMObserver o in obs)
            {
                o.onSubjChange(this);
            }
        }

        public bool findObs(IMObserver n)
        {
            if (obs.Count != 0)
            {
                if ((obs.Contains(n)))
                    return true;
                else return false;
            }
            else return false;
        }

        public void NotifyAll(IVisitor a)
        {
            foreach (IMObserver o in obs)
            {
                o.onSubjChange(a);
            }
        }

        public void NotifyAllButThis(IVisitor a, IMObserver b)
        {
            foreach (IMObserver o in obs)
            {
                if (obs.IndexOf(o)!=obs.IndexOf(b))
                    o.onSubjChange(a);
            }
        }

        public void NotifyAllButThat(IVisitor a, Subj b)
        {
            b.NotifyAll(a);
        }
    }

}
