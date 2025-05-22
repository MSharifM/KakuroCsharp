using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace AI
{
    public partial class Form1 : Form
    {
        public Box Box { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ReadInputFile(string pathFile)
        {
            using (StreamReader stream = new StreamReader(pathFile))
            {
                int[] dimensions = stream.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Box = new Box(dimensions[0], dimensions[1]);

                int blackBoxsSize = int.Parse(stream.ReadLine());

                for (int i = 0; i < blackBoxsSize; i++)
                {
                    int[] dimensionsBlack = stream.ReadLine().Split(' ').Select(int.Parse).Select(n => n - 1).ToArray();
                    Box.Data[dimensionsBlack[0], dimensionsBlack[1]] = -1;
                }

                int detailBoxsSize = int.Parse(stream.ReadLine());
                for (int i = 0; i < detailBoxsSize; i++)
                {
                    int[] dimensionsDetail = stream.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    Node node = new Node()
                    {
                        Down = dimensionsDetail[2],
                        Up = dimensionsDetail[3]
                    };
                    Box.Data[dimensionsDetail[0] - 1, dimensionsDetail[1] - 1] = node;
                }
            }

            Algorithms.BackTracking(Box);
        }

        private void btnInputFile_Click(object sender, EventArgs e)
        {
            string pathFile = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathFile = openFileDialog1.FileName;
                ReadInputFile(pathFile);
            }

            
        }

        
    }

    public class Box
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public Box(int row, int column)
        {
            Row = row;
            Column = column;
            Data = new object[row, column];
        }
        public object[,] Data;

        #region IsValid

        public bool IsValidRowAndColumn(int row, int col)
        {
            if (IsValidRow(this, row, col) && IsValidColumn(this, row, col))
                return true;

            return false;
        }

        private bool IsValidRow(Box box, int row, int col)
        {
            int target = 0;
            for (int i = col; ; i--)
            {
                if (box.Data[row, i] is Node)
                {
                    target = (box.Data[row, i] as Node).Up;
                    break;
                }
            }

            int sum = 0;
            for (int i = col + 1; i < box.Column; i++)
            {
                if (box.Data[row, i] is null)
                    return true;

                if (box.Data[row, i] is Node || int.Parse(box.Data[row, i].ToString()) == -1)
                    break;

                sum += int.Parse(box.Data[row, i].ToString());
            }
            if (sum == target)
                return true;

            return false;
        }

        private bool IsValidColumn(Box box, int row, int col)
        {
            int target = 0;
            for (int i = row; ; i--)
            {
                if (box.Data[i, col] is Node)
                {
                    target = (box.Data[i, col] as Node).Down;
                    break;
                }
            }

            int sum = 0;
            for (int i = row + 1; i < box.Row; i++)
            {
                if (box.Data[i, col] is null)
                    return true;

                if (box.Data[i, col] is Node || int.Parse(box.Data[i, col].ToString()) == -1)
                    break;

                sum += int.Parse(box.Data[i, col].ToString());
            }
            if (sum == target)
                return true;

            return false;
        }

        #endregion
    }

    class Node
    {
        public Node()
        {

        }
        public int Up { get; set; }

        public int Down { get; set; }
    }
}
