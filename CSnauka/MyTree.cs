using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySTL
{
    internal class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int Value { get; set; }

        public TreeNode(int value) 
        { 
            Value = value;
            Left = null;
            Right = null;
        }
    }
    
    internal class MyTree
    {
        public TreeNode Root { get; set; }

        public MyTree()
        {
            Root = null;
        }

        public void Insert(int value)
        {
            TreeNode node = new(value);
            if (Root == null)
                Root = node;           
            else
            {
                TreeNode currentNode = Root;
                while (true)
                {
                    if (value < currentNode.Value)
                    {
                        if(currentNode.Left == null)
                        {
                            currentNode.Left = node;
                            return;
                        }
                        currentNode = currentNode.Left;
                    }
                    else
                    {
                        if (currentNode.Right == null)
                        {
                            currentNode.Right = node;
                            return;
                        }
                        currentNode = currentNode.Right;
                    }
                }
            }
        }

        public bool Lookup(int value)
        {          
            if(Root == null)
                return false;
            
            TreeNode currentNode = Root;
            while (currentNode != null)
            {
                if (value < currentNode.Value)
                    currentNode = currentNode.Left;
                else if (value > currentNode.Value)
                    currentNode = currentNode.Right;
                else if (value == currentNode.Value)
                    return true;
            }
            return false;
        }

        public void Remove(int value)
        {
            if (Root == null)
                return;
            if(Root.Left == null && Root.Right == null)
            {
                Root = null;
                return;
            }
            
            TreeNode currentNode = Root;
            TreeNode parentNode = null;
            while(currentNode != null)
            {
                if(value < currentNode.Value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.Left;
                }                   
                else if(value > currentNode.Value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.Right;
                }                    
                //Found a match!
                else if(value == currentNode.Value)
                {
                    //1. Our match has no right child
                    if (currentNode.Right == null)
                    {
                        //Our match is a Root
                        if (parentNode == null)
                            Root = currentNode.Left;
                        else
                        {
                            if (parentNode.Value > currentNode.Value)
                                parentNode.Left = currentNode.Left;
                            else if(parentNode.Value < currentNode.Value)
                                parentNode.Right = currentNode.Left;
                        }
                    }
                    //2. Our match's right child doesn't have a left child
                    else if(currentNode.Right.Left == null)
                    {
                        //Our match is a Root
                        if (parentNode == null)
                            Root = currentNode.Left;
                        else
                        {
                            if (parentNode.Value > currentNode.Value)
                                parentNode.Left = currentNode.Right;
                            else if (parentNode.Value < currentNode.Value)
                                parentNode.Right = currentNode.Right;
                        }
                    }
                    //3. Our match's right child has a left child
                    else
                    {
                        //TODO
                    }
                }
            }
        }
    }
}
