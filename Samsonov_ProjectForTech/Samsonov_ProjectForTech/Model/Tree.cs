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
            this.Width = GenerationNumber[1].Max() * (25 * 3 * 12 + 10) + 40;
            this.Height = GenerationNumber[0].Count * 40 + 40;
            this.width = 25 * 3 * 12 + 10;
            this.heigth = 50;
            this.graph = GRAPH.GetList();
            this.GenerationNumber = GRAPH.GetGenerations();
            this.bmp = new Bitmap(Width, Height);
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
            numberPrev = new int[3,b];
            numberNext = new int[3,b];
            for (int i = 0; i < graph[0].Count; i++)
            {
                int j = i;
                while (graph[1][j] == graph[1][j - 1] || j == i)
                {
                    graphics.DrawRectangle(new Pen(Color.Black), X, Y, width, heigth);
                    graphics.DrawString(Dataset.GetPersonList()[graph[0][j]].GetFullName(), new System.Drawing.Font("Arial Black", 9, FontStyle.Regular, GraphicsUnit.Point), new SolidBrush(Color.Black), X + 5, Y + 2);
                    if (i != graph[0].Count - 1)
                    {
                        if (Dataset.GetPersonList()[graph[0][j]].GetChildList()[0] == Dataset.GetPersonList()[graph[0][j + 1]].GetChildList()[0])
                        {
                            graphics.DrawLine(new Pen(Color.Black), X + (width / 2), Y + heigth, X + width + 10, Y + heigth + 10);
                            numberNext[0,j - i] = Dataset.GetPersonList()[graph[0][j]].GetId();
                            numberNext[1,j - i] = X + width + 10;
                            numberNext[2,j - i] = Y + heigth + 10;
                        }
                        else if (i > 0)
                        {
                            if (Dataset.GetPersonList()[graph[0][j]].GetChildList()[0] == Dataset.GetPersonList()[graph[0][j - 1]].GetChildList()[0])
                            {
                                graphics.DrawLine(new Pen(Color.Black), X + (width / 2), Y + heigth, X - width - 10, Y + heigth + 10);
                                numberNext[0,j - i] = Dataset.GetPersonList()[graph[0][j]].GetId();
                                numberNext[1,j - i] = X - width - 10;
                                numberNext[2,j - i] = Y + heigth + 10;
                            }
                        }
                        else
                        {
                            graphics.DrawLine(new Pen(Color.Black), X + (width / 2), Y + heigth, X + (width / 2), Y + heigth + 10);
                            numberNext[0,j - i] = Dataset.GetPersonList()[graph[0][j]].GetId();
                            numberNext[1,j - i] = X + (width / 2);
                            numberNext[2,j - i] = Y + heigth + 10;
                        }
                        for (int t = 0; t < numberPrev.Length; t++)
                        {
                            if (Dataset.GetPersonList()[graph[0][j]].GetFatherID() == numberPrev[0,t] || Dataset.GetPersonList()[graph[0][j]].GetMotherID() == numberPrev[0,t])
                            {
                                graphics.DrawLine(new Pen(Color.Black), X + (width / 2), Y, numberPrev[1,t], numberPrev[2,t]);
                                break;
                            }
                        }
                    }
                    X += width + 10;
                }
                numberPrev = numberNext;
                Y += 20;
                j++;
            }
        }

        public Bitmap GetTree()
        {
            return bmp;
        }
    }
}
