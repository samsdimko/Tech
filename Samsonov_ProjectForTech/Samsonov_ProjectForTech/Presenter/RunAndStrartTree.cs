using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samsonov_ProjectForTech
{
    public class RunAndStrartTree
    {
        GenealogicalTree genealogicalTree;
        GenealogicalTreeTable genealogicalTreeTable;
        public RunAndStrartTree(int id)
        {
            Graph graph = new Graph(id);
            Tree tree = new Tree(graph);
            genealogicalTree = new GenealogicalTree(tree, graph, this);
            genealogicalTree.Show();
        }
        public void StartTable(Graph graph)
        {
            genealogicalTree.Hide();
            genealogicalTreeTable = new GenealogicalTreeTable(new Table(graph).GetTable(), this);
            genealogicalTreeTable.Show();
        }
        public void StartTree()
        {
            genealogicalTreeTable.Close();
            genealogicalTree.Show();
        }
    }
}
