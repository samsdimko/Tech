using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samsonov_ProjectForTech
{
    class Table
    {
        private string[] table;
        public Table(Graph graph)
        {
            List<List<int>> gr = graph.GetList();
            table = new string[gr[0].Count];
            for (int i = 0; i < gr[0].Count; i++)
            {
                table[i] = Dataset.GetPersonList()[gr[0][i]].GetFullName() + " | " + (gr[1][i].ToString());
            }
        }
        public string[] GetTable()
        {
            return table;
        }
    }
}
