using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AI
{
    public class Algorithms
    {
        public static void BackTracking(Box oldBox)
        {
            #region false
            //var emptyPoints = new List<Emptypoints>();
            //for (int row = 0; row < box.Row; row++)
            //{
            //    for (int column = 0; column < box.Column; column++)
            //    {
            //        if (box.data[row, column] == null)
            //        {
            //            emptyPoints.Add(new Emptypoints(row, column));
            //        }
            //    }
            //}
            //var current = emptyPoints[index];
            //int xCurrent = current.X;
            //int yCurrent = current.Y;

            //for (int num = 1; num <= 9; num++)
            //{
            //    box.data[xCurrent, yCurrent] = num;
            //    if (box.IsValidRowAndColumn(xCurrent, yCurrent))
            //    {
            //        if (BackTracking(box, index + 1))
            //        {
            //            return true;
            //        }
            //        box.data[xCurrent, yCurrent] = null;
            //    }
            //}

            //return false;
            #endregion  
            var newBox = oldBox;
            Tree tree = new Tree(newBox);
            TreeNode parent = tree.Root;

            for (int i = 0; i < newBox.Row; i++)
            {
                for (int j = 0; j < newBox.Column; j++)
                {
                    if (newBox.Data[i, j] is null)
                    {
                        parent = tree.Insert(parent, newBox, i, j); // Update parent tree node
                        if (newBox.IsValidRowAndColumn(i, j))
                            BackTracking(newBox);
                        else
                        {
                            
                        }

                    }
                }
            }
        }

        public void Back(TreeNode parent)
        {
            parent = parent.Parent;
            parent.Children.RemoveAt(0); // Remove the first child because failed
            if (parent.Children[0] is null)
            {
                Back(parent);
            }

            BackTracking(parent.Children[0].Data); // backtrack on first child
        }
    }

    public class Emptypoints
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Emptypoints(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
