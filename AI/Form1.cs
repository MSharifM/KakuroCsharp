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
            string pathFile = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathFile = openFileDialog1.FileName;
                ReadInputFile(pathFile);
            }
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
                    Box.data[dimensionsBlack[0], dimensionsBlack[1]] = -1;
                }

                int detailBoxsSize = int.Parse(stream.ReadLine());
                for (int i = 0; i < detailBoxsSize; i++)
                {
                    int[] dimensionsDetail = stream.ReadLine().Split(' ').Select(int.Parse).Select(n => n - 1).ToArray();
                    Node node = new Node()
                    {
                        Down = dimensionsDetail[2],
                        Up = dimensionsDetail[3]
                    };
                    Box.data[dimensionsDetail[0], dimensionsDetail[1]] = node;
                }
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
            data = new object[row, column];
        }
        public object[,] data;


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
