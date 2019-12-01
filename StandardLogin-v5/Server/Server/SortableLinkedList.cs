using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    // https://www.geeksforgeeks.org/merge-sort-for-linked-list/
    class SortableLinkedList <T> : LinkedList<T> where T : User
    {
        /*
        class node
        {
            public int UserId { get; set; }
            public string PasswordHash { get; set; }
            public string Salt { get; set; }
        }

        
        LinkedListNode<T> head = null;

        LinkedListNode<T> MergeSort(LinkedListNode<T> a, LinkedListNode<T> b)
        {
            LinkedListNode<T> result = null;
            if (a == null)
                return b;
            if (b == null)
                return a;

            if (a.Value <= b.Value)
            {
                result = a;
                result.Next = MergeSort(a.Next, b);
            }
            else
            {
                result = b;
                result.next = sortedMerge(a, b.next);
            }
            return result;
            */
            
    }

        /*
        // It returns the superclass as linkedlist
        private LinkedList<T> GetBase<T>()
            => base.GetType() as LinkedList<T>;
        */
}
