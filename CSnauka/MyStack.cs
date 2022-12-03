using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySTL
{
    internal class MyStack
    {
        public Node Top { get; set; }
        public Node Bottom { get; set; }
        public int Length { get; set; }
        public MyStack()
        {
            Top = null;
            Bottom = null;
            Length = 0;
        }
        public void Push(int value)
        {
            Node node = new(value);
            if (Length == 0)
            {
                Bottom = node;
                Top = node;
            }
            else
            {
                Node temp = Top;
                Top = node;
                Top.Next = temp;
            }
            Length++;
        }
        
        public int Peek()
        {
            if (Top == null)
                return -1;
            return Top.Value;
        }
        
        public void Pop()
        {
            if (Top == null)
                return;
            if (Top == Bottom)
                Bottom = null;
            Top = Top.Next;
            Length--;
        }
        
        public bool IsEmpty()
        {
            if (Length == 0)
                return true;
            return false;
        }
    }
}
