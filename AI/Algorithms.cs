using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class Algorithms
    {
        public static void BackTracking(Box box , int index)
        {
            var Emptypoints = new List<Emptypoints>();
            Tree tree = new Tree(box);
            for (int column = 0; column < box.Column; column++)
            {
                for (int row = 0; row < box.Row; row++)
                {
                    if (box.data[row , column] == null)
                    {
                        Emptypoints.Add(new Emptypoints(column, row));
                    }
                }
            }
            var current = Emptypoints[index];
            int Xcurrent = current.X;
            int Ycurrent = current.Y;

            for (int num = 1; num <= 9; num++)
            {
                box.data[Xcurrent, Ycurrent] = num;
            }
        }

        public bool SumRowIsCorrect(int row)
        {

            return true;
        }
        public class Emptypoints
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Emptypoints(int x , int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
