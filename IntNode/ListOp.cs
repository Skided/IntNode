using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntNode
{
    class ListOp
    {

        // Insert - inserts a node (newNode) into the list (first) after node (insertAfter)
        // It returns the pointer to the first node in chain
        // The list first may be empty (first = null)
        // It is assumed that node insertAfter is in the list
        public static Node<T> Insert<T>(Node<T> first, Node<T> newNode, Node<T> insertAfter)
        {
            if (first == null)           // list is empty
                return newNode;

            if (insertAfter == null)   // insert as first
            {
                newNode.SetNext(first);
                return newNode;
            }

            newNode.SetNext(insertAfter.GetNext());  // insert after the parameter insertAfter
            insertAfter.SetNext(newNode);
            return first;
        }

        // Remove - removes a node (toRemove) from the list (first)
        // It returns the pointer to the first node in chain
        // The list first may be empty after the operation (first = null)
        // It is assumed that toRemove is in the list
        public static Node<T> Remove<T>(Node<T> first, Node<T> toRemove)
        {
            if (first == toRemove)              // removal of first node in chain
                return toRemove.GetNext();

            Node<T> prev = first;
            while (prev.GetNext() != toRemove)
                prev = prev.GetNext();
            prev.SetNext(toRemove.GetNext());
            return first;
        }

        // ToStringList builds a string describing the entire list, in the format [xx,xx,xx]
        public static string ToStringList<T>(Node<T> first)
        {
            string s = "[";
            Node<T> p = first;
            while (p != null)
            {
                s += p.GetValue().ToString();
                if (p.HasNext())
                    s += ", ";
                p = p.GetNext();
            }
            s += "]";
            return s;
        }

        // IsInList checks whether the value (toFind) is in the list (first) 
        // and returns true or false accordingly
        public static bool IsInList<T>(Node<T> first, T toFind)
        {
            Node<T> p = first;
            while (p != null)
            {
                if (p.GetValue().Equals(toFind))
                    return true;
                p = p.GetNext();
            }
            return false;
        }

        // PointerInList checks whether the value (toFind) is in the list (first) 
        // and returns the pointer to the first appearance (or null if it is not found)
        public static Node<T> PointerInList<T>(Node<T> first, T toFind)
        {
            Node<T> p = first;
            while (p != null)
            {
                if (p.GetValue().Equals(toFind))
                    return p;
                p = p.GetNext();
            }
            return null;
        }

        // NumberOfNodes returns the number of nodes of the list (first)
        public static int NumberOfNodes<T>(Node<T> first)
        {
            int numOfNodes = 0;
            Node<T> p = first;
            while (p != null)
            {
                numOfNodes++;
                p = p.GetNext();
            }
            return numOfNodes;
        }

        // LastNode returns a pointer to the last node in the list (first) and null if the list is empty
        public static Node<T> LastNode<T>(Node<T> first)
        {
            Node<T> p = first;
            Node<T> last = null;

            while (p != null)
            {
                last = p;
                p = p.GetNext();
            }
            return last;
        }
        // display chain (recursive)
        public static void DisplayChain<T>(Node<T> p)
        {
            Console.WriteLine("[" + ChainString1(p) + "]");
        }

        private static string ChainString1<T>(Node<T> p)
        {
            if (p.HasNext())
                return p.GetValue().ToString() + " --> " + ChainString1(p.GetNext());
            else
                return p.GetValue().ToString();
        }
    }
}
