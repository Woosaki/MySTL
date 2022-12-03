using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySTL
{
    internal class MyQueue
    {
        public Node First { get; set; }
        public Node Last { get; set; }
        public int Length { get; set; }

        public MyQueue()
        {
            First = null;
            Last = null;
            Length = 0;
        }

        public int Peek()
        {
            return First.Value;
        }

        public void Enqueue(int value) 
        {
            Node node = new(value);
            if(Length == 0)
            {
                First = node;
                Last = node;
            }
            else
            { 
                Last.Next = node;
                Last = node;
            }
            Length++;
        }

        public int Dequeue()
        {
            if (First == null)
                return -1;
            if (First == Last)
                Last = null;
            
            Node nodeToRemove = First;
            First = First.Next;
            Length--;
            return nodeToRemove.Value;
        }

        public bool IsEmpty()
        {
            if (Length == 0)
                return true;
            return false;
        }
    }
}
