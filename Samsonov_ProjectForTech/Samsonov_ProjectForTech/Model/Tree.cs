using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samsonov_ProjectForTech
{
    public class Tree
    {
        int Width;
        int Height;
        int width;
        int heigth;
        int id;
        List<List<int>> GenerationNumber;
        List<List<int>> graph;
        int X0;
        int Y0;
        int X;
        int Y;
        int[,] numberPrev;
        int[,] numberNext;
        Bitmap bmp;
        public Tree(Graph GRAPH)
        {
            GenerationNumber = GRAPH.GetGenerations();
            Width = GenerationNumber[1].Max() * 270 + 40;
            Height = GenerationNumber[0].Count * 200 + 40;
            width = 250;
            heigth = 30;
            graph = GRAPH.GetList();
            bmp = new Bitmap(Width, Height);
            id = GRAPH.GetMainId();
            DrawTree();
        }
        private void DrawTree()
        {
            X0 = 20;
            Y0 = 20;
            X = X0;
            Y = Y0;
            Graphics graphics = Graphics.FromImage(bmp);
            int b = graph[0].Count;
            numberPrev = new int[3, b];
            numberNext = new int[3, b];
            for (int i = 0, k = 0; i < graph[0].Count; i++)
            {
                int j = i;
                if (j < graph[0].Count)
                {
                    while (j < i + GenerationNumber[1][k])
                    {                        
                        graphics.DrawRectangle(new Pen(Color.Black), X, Y, width, heigth);
                        if (Dataset.GetPersonList()[graph[0][j]].GetId() == id)
                        {
                            graphics.FillRectangle(new SolidBrush(Color.Gray), X, Y, width, heigth);
                        }
                        graphics.DrawString(Dataset.GetPersonList()[graph[0][j]].GetFullName(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Point), new SolidBrush(Color.Black), X + 5, Y + 5);
                        if (Dataset.GetPersonList()[graph[0][j]].GetChildList().Count != 0)
                        {
                            bool Tr = false;
                            
                                if (Dataset.GetPersonList()[graph[0][j + 1]].GetChildList().Count != 0)
                                {
                                    if (Dataset.GetPersonList()[graph[0][j]].GetChildList()[0] == Dataset.GetPersonList()[graph[0][j + 1]].GetChildList()[0])
                                    {
                                    var x1 = 0;
                                        graphics.DrawLine(new Pen(Color.Black), X + (width / 2), Y + heigth, X + width + 10, Y + heigth + 100);
                                        numberNext[0, j - i] = Dataset.GetPersonList()[graph[0][j]].GetId();
                                        numberNext[1, j - i] = X + width + 10;
                                        numberNext[2, j - i] = Y + heigth + 100;
                                        Tr = true;
                                    }
                                }
                            
                            if (j > 0 && Tr == false)
                            {
                                if (Dataset.GetPersonList()[graph[0][j - 1]].GetChildList().Count != 0)
                                {
                                    if (Dataset.GetPersonList()[graph[0][j]].GetChildList()[0] == Dataset.GetPersonList()[graph[0][j - 1]].GetChildList()[0])
                                    {
                                        graphics.DrawLine(new Pen(Color.Black), X + (width / 2), Y + heigth, X - 10, Y + heigth + 100);
                                        numberNext[0, j - i] = Dataset.GetPersonList()[graph[0][j]].GetId();
                                        numberNext[1, j - i] = X - 10;
                                        numberNext[2, j - i] = Y + heigth + 100;
                                        Tr = true;
                                    }

                                }
                            }
                            if (Tr == false)
                            {
                                graphics.DrawLine(new Pen(Color.Black), X + (width / 2), Y + heigth, X + (width / 2), Y + heigth + 100);
                                numberNext[0, j - i] = Dataset.GetPersonList()[graph[0][j]].GetId();
                                numberNext[1, j - i] = X + (width / 2);
                                numberNext[2, j - i] = Y + heigth + 100;
                            }
                        }
                        if (Dataset.GetPersonList()[graph[0][j]].GetFatherID() != -1)
                        {
                            for (int t = 0; t < b; t++)
                            {
                                if (Dataset.GetPersonList()[graph[0][j]].GetFatherID() == numberPrev[0, t])
                                {
                                    if(numberPrev[1, t] == 0)
                                    {
                                        continue;
                                    }
                                    graphics.DrawLine(new Pen(Color.Black), X + (width / 2), Y, numberPrev[1, t], numberPrev[2, t]);
                                    break;
                                }
                            }
                        }
                        if (Dataset.GetPersonList()[graph[0][j]].GetMotherID() != -1)
                        {
                            for (int t = 0; t < b; t++)
                            {
                                if (Dataset.GetPersonList()[graph[0][j]].GetMotherID() == numberPrev[0, t])
                                {
                                    if (numberPrev[1, t] == 0)
                                    {
                                        continue;
                                    }
                                    graphics.DrawLine(new Pen(Color.Black), X + (width / 2), Y, numberPrev[1, t], numberPrev[2, t]);
                                    break;
                                }
                            }

                        }                       
                        X += width + 20;
                        j++;
                    }
                    numberPrev = numberNext;
                    Y += 200;
                    X = X0;
                    i = j - 1;
                    k++;
                }
            }
        }

        public Bitmap GetTree()
        {
            return bmp;
        }
    }
}
