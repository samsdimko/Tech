using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class RunAndStrartTree
    {

        RunAndStrartTree(string Name)
        {
            Graph graph = new Graph(Search.SearchAll(Name)[0]);
            Tree tree = new Tree(graph);
            GenealogicalTree genealogicalTree = new GenealogicalTree(tree);
            genealogicalTree.Show();
        }
    }
}
