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
            if(Root == null)
                Root = new TreeNode(value);
            else
            {
                TreeNode node = new(value);
            }
        }
    }
}
