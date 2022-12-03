using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MySTL
{
    internal class DoubleNode
    {
        public int Value { get; set; }
        public DoubleNode Next { get; set; }
        public DoubleNode Previous { get; set; }
        public DoubleNode(int value) 
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }

    internal class MyDoublyLinkedList
    {
        public DoubleNode Head { get; private set; }
        public DoubleNode Tail { get; private set; }
        public int Length { get; private set; }

        public MyDoublyLinkedList(int value)
        {
            Head = new DoubleNode(value);
            Tail = Head;
            Length = 1;
        }

        public void Prepend(int value)
        {
            DoubleNode node = new(value);
            Head.Previous = node;
            node.Next = Head;
            Head = node;
            Length++;
        }

        public void Append(int value)
        {
            DoubleNode node = new(value);
            Tail.Next = node;
            node.Previous = Tail;
            Tail = node;
            Length++;
        }

        public void Insert(int value, int index)
        {
            if(index <= 0)
            {
                Prepend(value);
                return;
            }
            if(index>=Length)
            {
                Append(value);
                return;
            }
            
            DoubleNode node = new(value);
            DoubleNode leader = TraverseToIndex(index - 1);
            DoubleNode follower = leader.Next;
            
            node.Next = follower;
            node.Previous = leader;
            leader.Next = node;
            follower.Previous = node;
            Length++;
        }

        public int Remove(int index)
        {
            DoubleNode leader = TraverseToIndex(index - 1);
            DoubleNode nodeToRemove = leader.Next;
            leader.Next = nodeToRemove.Next;
            leader.Next.Previous = leader;
            Length--;
            return nodeToRemove.Value;
        }

        public void Reverse()       
        {
            if (Head.Next == null)
                return;
            DoubleNode first = Head;
            DoubleNode second = first.Next;
            Tail = Head;
            DoubleNode temp;
            while(second != null)
            {
                temp = second.Next;
                
                second.Next = first;
                first.Previous = second;
                second.Previous = temp;
                
                first = second;
                second = temp;
            }
            Head.Next = null;
            Head = first;
        }

        public DoubleNode TraverseToIndex(int index)
        {
            int counter = 0;
            DoubleNode currentNode = Head;
            while (counter != index)
            {
                currentNode = currentNode.Next;
                counter++;
            }
            return currentNode;
        }
        
        public void PrintList() 
        {
            DoubleNode currentNode = Head;
            while (currentNode != null)
            {
                Console.Write(currentNode.Value + "<-->");
                currentNode = currentNode.Next;
            }
            Console.Write("null");
            Console.WriteLine();
        }
    }
}
