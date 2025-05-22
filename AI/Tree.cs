using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class Tree
    {
        public Tree(Box box)
        {
            Root = new TreeNode();
            Root.Data = box;
        }

        public TreeNode Root { get; set; }

        public TreeNode Insert(TreeNode parent , Box oldBox , int row , int col)
        {
            Box newBox = oldBox;
            TreeNode node = new TreeNode();
            node.Parent = parent;
            for (int i = 1; i < 10; i++)
            {
                newBox.Data[row, col] = i;
                node.Data = newBox;
                parent.Children.Add(node);
            }
            return node;
        }
    }

    public class TreeNode
    {
        public TreeNode()
        {
            Children = new List<TreeNode>();
        }

        public TreeNode Parent { get; set; }

        public List<TreeNode> Children { get; set; }

        public Box Data { get; set; }

    }
}
