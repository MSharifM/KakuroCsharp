using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
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

        #region Read & Write output file functions

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
        }

        public void OutputFile(string path , Box box , bool solve = false)
        {
            path += ".html";

            using (StreamWriter stream = new StreamWriter(path))
            {
                stream.WriteLine("<!DOCTYPE html>\r\n<html lang=\"fa\">\r\n<head>\r\n  <meta charset=\"UTF-8\">\r\n  <title>جدول کاکورو دقیق</title>\r\n  <style>\r\n    table.kakuro {\r\n      border-collapse: collapse;\r\n      direction: ltr;\r\n    }\r\n    table.kakuro td {\r\n      width: 40px;\r\n      height: 40px;\r\n      border: 1px solid #222;\r\n      text-align: center;\r\n      vertical-align: middle;\r\n      position: relative;\r\n      font-family: Tahoma, Arial, sans-serif;\r\n      font-size: 16px;\r\n      padding: 0;\r\n      box-sizing: border-box;\r\n    }\r\n    .black {\r\n      background: #222;\r\n    }\r\n    .white {\r\n      background: #fff;\r\n    }\r\n    .clue {\r\n      background: #222;\r\n      color: #fff;\r\n      overflow: hidden;\r\n      position: relative;\r\n    }\r\n    .clue svg {\r\n      position: absolute;\r\n      top: 0; left: 0;\r\n      width: 100%; height: 100%;\r\n      pointer-events: none;\r\n    }\r\n    /* عدد بالا راست */\r\n    .clue .clue-top {\r\n      position: absolute;\r\n      top: 2px; right: 4px;\r\n      font-size: 14px;\r\n      z-index: 2;\r\n    }\r\n    /* عدد پایین چپ */\r\n    .clue .clue-bottom {\r\n      position: absolute;\r\n      bottom: 2px; left: 4px;\r\n      font-size: 14px;\r\n      z-index: 2;\r\n    }\r\n  </style>\r\n</head>\r\n<body>\r\n  <table class=\"kakuro\">");
                for (int i = 0; i < box.Row; i++)
                {
                    stream.WriteLine("<tr>");
                    for (int j = 0; j < box.Column; j++)
                    {
                        if (box.Data[i, j] is int number)
                        {
                            if (number == -1)
                                stream.WriteLine("<td class=\"black\"></td>");
                            else
                                stream.WriteLine($"<td class=\"white\">{number}</td>");
                        }
                        else if (box.Data[i, j] is Node)
                        {
                            Node node = box.Data[i, j] as Node;
                            if (node.Up == 0)
                                stream.WriteLine($"<td class=\"clue black\"><div class=\"clue-bottom\">{node.Down}</div></td>");
                            else if (node.Down == 0)
                                stream.WriteLine($"<td class=\"clue black\"><div class=\"clue-top\">{node.Up}</div></td>");
                            else
                                stream.WriteLine($"<td class=\"clue black\"><div class=\"clue-top\">{node.Up}</div><div class=\"clue-bottom\">{node.Down}</div></td>");
                        }
                        else
                        {
                            stream.WriteLine("<td class=\"white\"></td>");
                        }
                    }
                    stream.WriteLine("</tr>");
                }
            }

            if(!solve) 
                webBQuestion.Url = new Uri("C:\\Users\\Lenovo\\source\\repos\\AI\\AI\\bin\\Debug\\" + path);
            else
                webBSolve.Url = new Uri("C:\\Users\\Lenovo\\source\\repos\\AI\\AI\\bin\\Debug\\" + path);
            
        }

        #endregion 

        private void btnInputFile_Click(object sender, EventArgs e)
        {
            string pathFile = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathFile = openFileDialog1.FileName;
                ReadInputFile(pathFile);
                OutputFile("question" , Box);
            }


            Algorithms.BackTracking(Box);

            OutputFile("solve", Box, true);
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
            var num = box.Data[row, col]; // to check unique 

            int target = 0;
            bool flag = false;
            for (int i = col; ; i--)
            {
                if (box.Data[row, i] is int number && flag)
                    if(number.ToString() == num.ToString())
                        return false;

                if (box.Data[row, i] is Node)
                {
                    target = (box.Data[row, i] as Node).Up;
                    break;
                }
                flag = true;
            }

            int sum = 0;
            for (int i = col; i < box.Column; i++)
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
            var num = box.Data[row, col]; // to check unique 

            int target = 0;
            bool flag = false;
            for (int i = row; ; i--)
            {
                if (box.Data[i, col] is int number && flag)
                    if (number.ToString() == num.ToString())
                        return false;

                if (box.Data[i, col] is Node)
                {
                    target = (box.Data[i, col] as Node).Down;
                    break;
                }
                flag = true;
            }

            int sum = 0;
            for (int i = row; i < box.Row; i++)
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
