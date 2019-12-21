using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samsonov_ProjectForTech
{
    class RunAndStrartTree
    {
        public RunAndStrartTree(int id)
        {
            Graph graph = new Graph(id);
            Tree tree = new Tree(graph);
            GenealogicalTree genealogicalTree = new GenealogicalTree(tree);
            genealogicalTree.Show();
        }
        public static void Run(int id)
        {
            Graph graph = new Graph(id);
            Tree tree = new Tree(graph);
            GenealogicalTree genealogicalTree = new GenealogicalTree(tree);
            genealogicalTree.Show();
        }
    }
}
