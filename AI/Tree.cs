using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class Tree
    {
        public Tree(Box box)
        {
            Root.Parent = null;
            Root.Data = box;
        }

        public TreeNode Root { get; set; }

        public void Insert(TreeNode parent , Box data)
        {
            TreeNode node = new TreeNode();
            node.Data = data;
            node.Parent = parent;
            parent.Children.Add(node);
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
