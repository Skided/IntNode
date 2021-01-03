using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Dynamic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
namespace IntNode
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> lst11 = new Node<int>(1);
            Node<int> lst12 = new Node<int>(2, lst11);
            Node<int> lst13 = new Node<int>(3, lst12);
            Node<int> lst14 = new Node<int>(4);
            Node<int> lst15 = new Node<int>(5, lst14);
            Node<int> lst16 = new Node<int>(6, lst15);
            Node<int> lst17 = new Node<int>(7, lst16);
            //end of list 2
            Node<int> lst21 = new Node<int>(1);
            Node<int> lst22 = new Node<int>(2, lst21);
            Node<int> lst23 = new Node<int>(3, lst22);
            Node<int> lst24 = new Node<int>(4, lst23);
            Node<int> lst25 = new Node<int>(5, lst24);
            Node<int> lst26 = new Node<int>(6, lst25);
            Node<int> lst27 = new Node<int>(7, lst26);

            //P98E44(int6);
            int num = P98E46(lst27, lst17);
            Console.WriteLine(num);
        }
        public static void P98E44(Node<int> node)
        {
            if (node != null && node.GetNext() != null)
            {
                Node<int> n = node.GetNext();
                Console.WriteLine(n.GetValue());
                P98E44(n.GetNext());
            }
        }
        public static int P98E45(Node<int> ist, Node<int> p, Node<int> q)
        {
            if (ist != null)
            {
                if (ist == p && p != q)
                {
                    return p.GetValue() + P98E45(ist.GetNext(), p.GetNext(), q);
                }
                return P98E45(ist.GetNext(), p, q);
            }
            return q.GetValue();
        }
        public static int P98E46(Node<int> lst1, Node<int> lst2)
        {
            if (lst1 == null && lst2 != null)
                return 1 + P98E46(lst1, lst2.GetNext());
            if (lst1 != null && lst2 == null)
                return 1 + P98E46(lst1.GetNext(), lst2);
            if(lst1 != null && lst2 != null)
                return P98E46(lst1.GetNext(), lst2.GetNext());
            return 0;
        }
        public static void DoesAppear(Node<int> node, int num)
        {
            int countnum = 0;
            Node<int> listv2 = node;
            while (listv2.GetValue() != null)
            {
                if (listv2.GetValue() == num)
                    countnum++;
                listv2 = listv2.GetNext();
            }
        }

        public static void DisplayList(Node<int> list)
        {
            string Shar = "[";
            while(list != null)
            {
                if (list.HasNext())
                {
                    Shar += list.GetValue() + ", ";
                }
                else
                {
                    Shar += list.GetValue() +"]";
                }
                list = list.GetNext();
            }
            Console.WriteLine(Shar);
        }
        private static bool IsInList(Node<int> nums, int Finder)
        {
            Node<int> lmao = nums;
            while(lmao != null)
            {
                if(lmao.GetValue() == Finder)
                {
                    return true;
                }
                lmao = lmao.GetNext();
            }
            return false;
        }

    }
}
