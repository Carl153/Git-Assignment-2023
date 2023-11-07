using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListWithErrors
{
    public class DLList
    {
        public DLLNode head; // pointer to the head of the list
        public DLLNode tail; // pointer to the tail of the list
        public DLList() { head = null; tail = null; } // constructor
        /*-------------------------------------------------------------------
        * The methods below includes several errors. Your  task is to write
        * unit test to discover these errors. During delivery the tutor may
        * add or remove errors to adjust the scale of the effort required by
        */
        public void addToTail(DLLNode p)
        {

            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                tail.next = p;
                //  tail = p;  
                p.previous = tail;
                tail = p; //moved this line to the end
            }
        } // end of addToTail

        public void addToHead(DLLNode p)
        {
            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                p.next = this.head;
                this.head.previous = p;
                head = p;
            }
        } // end of addToHead

        public void removeHead()
        {
            if (this.head == null)
                return;
            this.head = this.head.next;
            this.head.previous = null;
        } // removeHead

        public void removeTail()
        {
            if (tail == null)
            {
                return; // List is empty, nothing to remove
            }
            else if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.previous; // Update tail to the previous node
                tail.next = (null);
            }
        }


        /*-------------------------------------------------
         * Return null if the string does not exist.
         * ----------------------------------------------*/
        public DLLNode search(int num)
        {
            DLLNode p = head;
            while (p != null)
            {
                if (p.num == num)
                {
                    return p;
                }
                p = p.next;
            }
            return null;
        }

        public void removeNode(DLLNode p)
        {
            if (p == null)
            {
                return; // Invalid input, nothing to remove
            }
            if (p.previous != null)
            {
                p.previous.next = p.next;
            }
            else
            {
                head = p.next;
            }
            if (p.next != null)
            {
                p.next.previous = p.previous;
            }
            else
            {
                tail = p.previous;
            }
        }

        public int total()
        {
            DLLNode p = head;
            int tot = 0;
            while (p != null)
            {
                tot += p.num;
                p = p.next; //was p.next
            }
            return (tot);
        } // end of total
    } // end of DLList class
}
