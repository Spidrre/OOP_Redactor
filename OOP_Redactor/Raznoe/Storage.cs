using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{

    public class Storage : Subj, IMObserver
    {
        Node head;
        Node curr;
        Node temp;
        public int len;
        bool flag;
        public Storage(): base()
        {
            head = null;
            temp = null;
            curr = null;
            len = 0;
        }

        public void Add(IShape a)
        {
            Node n = new Node(a);
            n.next = null;
            len++;
            n.id = len - 1;
            Node z = curr;
            if (head != null)
            {
                curr = head;
                while (curr.next != null)
                    curr = curr.next;
                curr.next = n;
            }
            else
            {
                head = n;
            }
            curr = z;
            a.addObs(this);
            NotifyAll();
        }

        public void insert_at(int x, IShape a)
        {
            Node n = new Node(a);
            len++;
            n.id = x;

            temp = head;
            curr = head;
            if (head == null)
            {
                head = n;
            }
            else
            {
                if (x == 0)
                {
                    n.next = head;
                    head = n;
                    curr = head.next;
                }
                else
                {
                    int i = 0;
                    while (i != x)
                    {
                        i++;
                        temp = curr;
                        curr = curr.next;
                    }
                    temp.next = n;
                    n.next = curr;
                }
                while (curr != null)
                {
                    curr.id++;
                    curr = curr.next;
                }
            }
            a.addObs(this);
            NotifyAll();
        }

        public void Delete(int x)
        {
            Node del = null;
            temp = head;
            curr = head;

            int i = 0;
            while (i != x && curr != null)
            {
                i++;
                temp = curr;
                curr = curr.next;
            }
            if (curr != null)
            {
                del = curr;
                del.obj.removeObs(this);
                curr = curr.next;
                temp.next = curr;
                //if (len == 1)
                //{
                //    head = null;
                //    temp = null;
                //}
                //else
                    if (del == head)
                    {
                        head = head.next;
                        temp = null;
                    }
                len = len - 1;
                Node z = curr;
                while (curr != null)
                {
                    curr.id--;
                    curr = curr.next;
                }
                curr = z;
                flag = false;
            };
            NotifyAll();
        }

        public void delete_curr()
        {
            Node del;
            if (curr != null)
            {
                del = curr;
                del.obj.removeObs(this);
                curr = curr.next;
                temp.next = curr;
                if (del == head)
                {
                    head = head.next;
                }
                len = len - 1;
                flag = false;
                Node z = curr;
                while (curr != null)
                {
                    curr.id--;
                    curr = curr.next;
                }
                curr = z;
            };
            NotifyAll();
        }

        public void Delete_that(IShape thi)
        {
            Node m;
            for (m = head; m != null; m = m.next)
                if (m.obj == thi)
                {
                    m.obj.removeObs(this);
                    Delete(m.id);
                    return;
                }
            NotifyAll();
        }

        public IShape get_curr()
        {
            return curr.obj;
        }

        public IShape get_element(int x)
        {
            for (curr = head; curr != null; curr = curr.next)
               if (curr.id == x)
                  return curr.obj;
            return null;
        }

        public Node get_(int x)
        {
            Node m;
            for (m = head; m != null; m = m.next)
                if (m.id == x)
                    return m;
            return null;
        }

        public void swap()
        {
            int lel;
            if (len % 2 == 0)
                lel = len / 2;
            else
                lel = len / 2+1;
            first();
            for (int i=0; i<lel; i++)
            {
                IShape tek = curr.obj;
                curr.obj = get_(len - 1 - i).obj;
                get_(len - 1 - i).obj = tek;
                next();
            }
        }

        public void new_obj(IShape sel)
        {
            curr.obj = sel;
        }

        public int length()
        {
            return len;
        }

        public void first()
        {
            curr = head;
            temp = head;
            flag = true;
        }
        public void next()
        {
            if (flag!=false)
            {
                temp = curr;
                curr = curr.next;
            }
            flag = true;
        }
        public bool eol()
        {
            if (curr == null)
                return true;
            else return false;
        }

        public void onSubjChange(IVisitor a)
        {

        }

        public void onSubjChange(Subj who)
        {
            NotifyAll();
        }
    };
}