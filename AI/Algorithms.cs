using System;
using System.Collections.Generic;
using System.Linq;

namespace AI
{
    public static class Algorithms
    {
        #region BT

        private static Box Result { get; set; }
        private static Emptypoints endStat;
        public static Box BackTracking(Box oldBox, TreeNode parent = null, bool fc = false)
        {
            if (parent != null && parent.Data.Data[4, 4] != null && (parent.Data.Data[4, 4].ToString() == 9.ToString()))
            {
                Result = parent.Data;
                Form1 form1 = new Form1();
                form1.OutputFile("solve", Result, true);
                return oldBox;
            }
            Box copyBox = new Box(oldBox.Row, oldBox.Column);
            copyBox.Data = (object[,])oldBox.Data.Clone();
            Tree tree = new Tree(copyBox);

            if (parent == null)
            {
                parent = tree.Root;
                endStat = Emptypoints.StatEndEmpity(oldBox);
            }

            for (int i = 0; i < copyBox.Row; i++)
            {
                for (int j = 0; j < copyBox.Column; j++)
                {
                    if (copyBox.Data[i, j] is null)
                    {
                        if (fc)
                        {
                            var domain = Domain(copyBox, i, j);
                            if (domain is null)
                                Back(parent, i, j, fc);

                            parent = tree.Insert(parent, copyBox, i, j, domain).Children[0];
                        }
                        else
                            parent = tree.Insert(parent, copyBox, i, j).Children[0]; // Update parent tree node
                        if (parent.Data.IsValidRowAndColumn(parent.StatNewRow, parent.StatNewColumn))
                        {
                            var res = BackTracking(parent.Data, parent , fc);
                            return Result;
                        }
                        else
                        {
                            var res = Back(parent, i, j , fc); // Backtrack on first child
                            return Result;
                        }
                    }
                }
            }
            return Result;
        }

        public static Box Back(TreeNode node, int i, int j , bool fc = false)
        {
            node = node.Parent;
            if (node.Children.Count() == 0)
            {
                Back(node, node.StatNewRow, node.StatNewColumn , fc);
            }
            node.Children.RemoveAt(0); // Remove the first child because failed
            if (node.Children.Count() == 0)
            {
                Back(node, node.StatNewRow, node.StatNewColumn , fc);
            }
            try
            {
                if (!node.Children[0].Data.IsValidRowAndColumn(node.Children[0].StatNewRow, node.Children[0].StatNewColumn))
                {
                    Back(node.Children[0], node.Children[0].StatNewRow, node.Children[0].StatNewColumn , fc);
                    return node.Children[0].Data;
                }
            }
            catch
            {
                return null;
            }
            var res = BackTracking(node.Children[0].Data, node.Children[0] , fc); // backtrack on first child
            return res;
        }

        private static List<int> Domain(Box box, int row, int col)
        {
            List<int> domain = Enumerable.Range(1, 9).ToList();
            for (int i = row; i >= 0; i--)
            {
                if (box.Data[i, col] is Node)
                    break;

                if (box.Data[i, col] is int number)
                    if (number == -1)
                        break;
                    else
                        domain.Remove(number);
            }
            for (int i = col; i >= 0; i--)
            {
                if (box.Data[i, col] is Node)
                    break;

                if (box.Data[row, i] is int number)
                    if (number == -1)
                        break;
                    else
                        domain.Remove(number);
            }

            return domain;
        }

        #endregion

        #region MinConflict

        private static List<Tuple<int, int>> variables = new List<Tuple<int, int>>();
        private static Random _random = new Random();
        public static Box ResultMinConflict { get; set; }

        private static void InitializeVariables()
        {
            for (int i = 0; i < ResultMinConflict.Row; i++)
                for (int j = 0; j < ResultMinConflict.Column; j++)
                    if (ResultMinConflict.Data[i, j] is null)
                        variables.Add(Tuple.Create(i, j));
        }

        public static void MinConflict(Box box, int maxSteps = 10000)
        {
            ResultMinConflict = box;
            InitializeVariables();

            InitializeRandomValues();

            for (int step = 0; step < maxSteps; step++)
            {
                var conflicts = variables.Where(v => !ResultMinConflict.IsValidRowAndColumn(v.Item1, v.Item2)).ToList();

                if (conflicts.Count == 0)
                {
                    return;
                }

                var randomVar = conflicts[_random.Next(conflicts.Count)];
                var (row, col) = randomVar;

                int currentValue = (int)ResultMinConflict.Data[row, col];
                int bestValue = currentValue;
                int minConflicts = int.MaxValue;

                foreach (int value in GetPossibleValues(row, col))
                {
                    ResultMinConflict.Data[row, col] = value;
                    int newConflicts = variables.Count(v => !ResultMinConflict.IsValidRowAndColumn(v.Item1, v.Item2));

                    if (newConflicts < minConflicts)
                    {
                        minConflicts = newConflicts;
                        bestValue = value;
                    }
                }

                ResultMinConflict.Data[row, col] = bestValue;
            }
        }

        private static List<int> GetPossibleValues(int row, int col)
        {
            return Enumerable.Range(1, 9)
                .OrderBy(x => _random.Next()) // برای جلوگیری از ترتیب ثابت
                .ToList();
        }

        private static void InitializeRandomValues()
        {
            foreach (var (i, j) in variables)
            {
                ResultMinConflict.Data[i, j] = _random.Next(1, 10);
            }
        }
    }

    #endregion


    public class Emptypoints
    {
        public static List<Emptypoints> emptypoints = new List<Emptypoints>();

        public int X { get; set; }
        public int Y { get; set; }
        public Emptypoints(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Emptypoints StatEndEmpity(Box Box)
        {
            for (int i = 0; i < Box.Row; i++)
            {
                for (int j = 0; j < Box.Column; j++)
                {
                    if (Box.Data[i, j] is null)
                        emptypoints.Add(new Emptypoints(i, j));
                }
            }
            return emptypoints[emptypoints.Count() - 1];
        }
    }
}
