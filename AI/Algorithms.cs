﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AI
{
    public static class Algorithms
    {
        #region BT

        public static Box BackTracking(Box oldBox, TreeNode treeNode = null, bool fc = false, bool mrv = false)
        {
            Box copyBox = new Box(oldBox.Row, oldBox.Column);
            copyBox.Data = (object[,])oldBox.Data.Clone();
            Tree tree = new Tree(copyBox);

            if (treeNode == null)
                treeNode = tree.Root;

            bool full = true;
            for (int i = 0; i < copyBox.Row; i++)
            {
                for (int j = 0; j < copyBox.Column; j++)
                {
                    if (copyBox.Data[i, j] is null)
                    {
                        full = false;
                        if (fc) // BackTrack with FC
                        {
                            var domain = Domain(copyBox, i, j);
                            if (domain is null)
                            {
                                treeNode = Back(treeNode, i, j, fc, mrv);
                                copyBox = treeNode.Data;
                            }

                            treeNode = tree.Insert(treeNode, copyBox, i, j, domain).Children[0];
                        }
                        else if (mrv) // BackTrack with MRV
                        {
                            var blockStat = SearchMRV(copyBox);
                            if (blockStat.Item1 is null)
                                break;

                            treeNode = tree.Insert(treeNode, copyBox,
                                blockStat.Item2.Item1, blockStat.Item2.Item2, blockStat.Item1).Children[0];
                        }
                        else // BackTrack without FC & MRV
                        {
                            treeNode = tree.Insert(treeNode, copyBox, i, j).Children[0]; // Update parent tree node
                        }

                        if (treeNode.Data.IsValidRowAndColumn(treeNode.StatNewRow, treeNode.StatNewColumn))
                        {
                            copyBox = BackTracking(treeNode.Data, treeNode, fc, mrv);
                        }
                        else
                        {
                            treeNode = Back(treeNode, i, j, fc, mrv); // Backtrack on first child
                            copyBox = treeNode.Data;
                        }
                    }
                }
            }

            if (mrv && !CheckFull(copyBox))
                copyBox = BackTracking(copyBox, treeNode, fc, mrv);

            return copyBox;
        }

        private static TreeNode Back(TreeNode node, int i, int j, bool fc = false, bool mrv = false)
        {
            node = node.Parent;
            node.Children.RemoveAt(0); // Remove the first child because failed
            
            if (node.Children.Count == 0)
                return Back(node, node.StatNewRow, node.StatNewColumn, fc, mrv);
            
            if (!node.Children[0].Data.IsValidRowAndColumn(node.Children[0].StatNewRow, node.Children[0].StatNewColumn))
                return Back(node.Children[0], node.Children[0].StatNewRow, node.Children[0].StatNewColumn, fc, mrv);

            return node.Children[0];
        }

        private static List<int> Domain(Box box, int row, int col)
        {
            List<int> domain = Enumerable.Range(1, 9).ToList();
            // search left
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
            //down
            for (int i = row; i < box.Row; i++)
            {
                if (box.Data[i, col] is Node)
                    break;

                if (box.Data[i, col] is int number)
                    if (number == -1)
                        break;
                    else
                        domain.Remove(number);
            }
            //right
            for (int i = col; i < box.Column; i++)
            {
                if (box.Data[row, i] is Node)
                    break;

                if (box.Data[row, i] is int number)
                    if (number == -1)
                        break;
                    else
                        domain.Remove(number);
            }
            // search up
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

        private static Tuple<List<int>, Tuple<int, int>> SearchMRV(Box box)
        {
            int row = 0, col = 0;
            List<int> domain = new List<int>();
            for (int i = 0; i < box.Row; i++)
            {
                for (int j = 0; j < box.Column; j++)
                {
                    if (box.Data[i, j] is null)
                    {
                        var temp = Domain(box, i, j);
                        if (domain.Count() <= temp.Count())
                        {
                            domain = temp;
                            row = i;
                            col = j;
                        }
                    }
                }
            }
            if (row == 0 && col == 0)
                return null;

            return Tuple.Create(domain, Tuple.Create(row, col));
        }

        private static bool CheckFull(Box box)
        {
            for (int i = 0; i < box.Row; i++)
            for (int j = 0; j < box.Column; j++)
                if (box.Data[i, j] is null)
                    return false;

            return true;
        }

        #endregion

        #region MinConflict

        private static List<Tuple<int, int>> _empityBlocks = new List<Tuple<int, int>>();
        private static Random _random = new Random();
        public static Box ResultMinConflict { get; set; }

        public static void MinConflict(Box box, int maxSteps = 10000)
        {
            ResultMinConflict = box;
            FindEmpityBlocks();
            InitializeRandomValues();

            for (int step = 0; step < maxSteps; step++)
            {
                var conflicts = _empityBlocks.Where(v => !ResultMinConflict.IsValidRowAndColumn(v.Item1, v.Item2)).ToList();

                if (conflicts.Count == 0)
                    return;

                var randomVar = conflicts[_random.Next(conflicts.Count)]; // select a block conflict 
                var row = randomVar.Item1;
                var col = randomVar.Item2;
                int currentValue = (int)ResultMinConflict.Data[row, col];
                int bestValue = currentValue;
                int minConflicts = int.MaxValue;

                foreach (int value in GetPossibleValues(row, col))
                {
                    ResultMinConflict.Data[row, col] = value;
                    int newConflicts = _empityBlocks.Count(v => !ResultMinConflict.IsValidRowAndColumn(v.Item1, v.Item2));

                    if (newConflicts < minConflicts)
                    {
                        minConflicts = newConflicts;
                        bestValue = value;
                    }
                }

                ResultMinConflict.Data[row, col] = bestValue;
            }
        }

        private static void FindEmpityBlocks()
        {
            for (int i = 0; i < ResultMinConflict.Row; i++)
                for (int j = 0; j < ResultMinConflict.Column; j++)
                    if (ResultMinConflict.Data[i, j] is null)
                        _empityBlocks.Add(Tuple.Create(i, j));
        }

        private static List<int> GetPossibleValues(int row, int col)
        {
            return Enumerable.Range(1, 9).OrderBy(x => _random.Next()).ToList(); // return a random list betwwen 1-9
        }

        private static void InitializeRandomValues()
        {
            foreach (var (i, j) in _empityBlocks)
                ResultMinConflict.Data[i, j] = _random.Next(1, 10);
        }
    }

    #endregion
}