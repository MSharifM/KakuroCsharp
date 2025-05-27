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

        public TreeNode Insert(TreeNode parent, Box oldBox, int row, int col , List<int> domain = null)
        {
            if(domain is null)
                domain = Enumerable.Range(1, 9).ToList();

            foreach(var index in domain)
            {
                TreeNode node = new TreeNode();
                node.Parent = parent;
                Box newBox = new Box(oldBox.Row, oldBox.Column);
                var array = (object[,])oldBox.Data.Clone();
                array[row, col] = index;
                newBox.Data = (object[,])array.Clone();
                node.Data = newBox;
                node.StatNewRow = row;
                node.StatNewColumn = col;
                parent.Children.Add(node);
            }
            return parent;
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

        public int StatNewRow { get; set; }

        public int StatNewColumn { get; set; }

    }
}
