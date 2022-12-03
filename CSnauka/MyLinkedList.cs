using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MySTL
{
    internal class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
       
        public Node(int value) 
        { 
            Value = value;
            Next = null;
        }
    }
    
    internal class MyLinkedList
    {
        public Node Head  { get; private set; }
        public Node Tail { get; private set; }
        public int Length { get; private set; }
        
        public MyLinkedList(int value)
        {
            Head = new Node(value);
            Tail = Head;
            Length = 1;
        }
        
        public void Append(int value)
        {
            Node node = new(value);
            Tail.Next = node;
            Tail = node;
            Length++;
        }
        
        public void Prepend(int value)
        {
            Node node = new(value);
            node.Next = Head;
            Head = node;
            Length++;
        }
        
        public void Insert(int value, int index)
        {
            if(index <= 0)
            {
                Prepend(value);
                return;
            }
            if(index >= Length)
            {
                Append(value);
                return;
            }

            Node node = new(value);
            Node leader = TraverseToIndex(index - 1);
            Node follower = leader.Next;
            
            node.Next = follower;
            leader.Next = node;
            Length++;
        }
        
        public int Remove(int index)
        {
            Node leader = TraverseToIndex(index - 1);
            Node nodeToRemove = leader.Next;
            leader.Next = nodeToRemove.Next;
            Length--;
            return nodeToRemove.Value;
        }
        
        private Node TraverseToIndex(int index)
        {
            int counter = 0;
            Node currentNode = Head;
            while (counter != index)
            {
                currentNode = currentNode.Next;
                counter++;
            }
            return currentNode;
        }
        
        public void Reverse()
        {
            if (Head.Next == null)
                return;
            Node first = Head;
            Tail = Head;
            Node second = first.Next;
            Node temp;
            while (second != null)
            {
                temp = second.Next;
                
                second.Next = first;
                
                first = second;                
                second = temp;
            }
            Head.Next = null;
            Head = first;
        }

        public void PrintList()
        {
            if (Head == null)
                return;
            Node currentNode = Head;
            while(currentNode != null)
            {
                Console.Write(currentNode.Value + "-->");
                currentNode = currentNode.Next;
            }
            Console.Write("null");
            Console.WriteLine();
        }
    }
}
