using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samsonov_ProjectForTech
{
    class RelationShip
    {
        private Graph GRAPH;
        private List<List<int>> graph;
        private int me;
        private int it;
        public RelationShip(Graph graph, int me, int it)
        {
            this.GRAPH = graph;
            this.graph = graph.GetList();
            this.me = me;
            this.it = it;
        }
        public string MainSearch()
        {
            if (graph[0].IndexOf(it) == -1)
            {
                return "Не родственники";
            }
            else
            {
                return Search();
            }
        }
        private string Search()
        {
            if (graph[1][me] == graph[1][it] && Dataset.GetPersonList()[graph[0][me]].GetChildList() == Dataset.GetPersonList()[graph[0][it]].GetChildList() && 
                Dataset.GetPersonList()[graph[0][me]].GetChildList().Count != 0)
            {
                return "Супруги";
            }
            else if (graph[1][me] == graph[1][it] &&
                (Dataset.GetPersonList()[Dataset.GetPersonList()[graph[0][me]].GetMotherID()].GetFullName() == Dataset.GetPersonList()[Dataset.GetPersonList()[graph[0][it]].GetMotherID()].GetFullName() &&
                Dataset.GetPersonList()[Dataset.GetPersonList()[graph[0][me]].GetFatherID()].GetFullName() == Dataset.GetPersonList()[Dataset.GetPersonList()[graph[0][me]].GetFatherID()].GetFullName()))
            {
                return "Полнокровные братья/сестры";
            }
            else if (graph[1][me] == graph[1][it] &&
                Dataset.GetPersonList()[Dataset.GetPersonList()[graph[0][me]].GetMotherID()].GetFullName() == Dataset.GetPersonList()[Dataset.GetPersonList()[graph[0][it]].GetMotherID()].GetFullName())
            {
                return "Единоутробные братья/сестры";
            }
            else if (graph[1][me] == graph[1][it] &&
                Dataset.GetPersonList()[Dataset.GetPersonList()[graph[0][me]].GetFatherID()].GetFullName() == Dataset.GetPersonList()[Dataset.GetPersonList()[graph[0][it]].GetFatherID()].GetFullName())
            {
                return "Единокровные братья/сестры";
            }
            else
            {
                int[] t = GRAPH.Relation(me, it);
                if (t[0] == 0)
                {
                    return Dataset.GetPersonList()[graph[0][me]].GetFullName() + " и " + Dataset.GetPersonList()[graph[0][it]].GetFullName() +
                        " являются родственниками одного поколения со степенью родства " + t[1].ToString();
                }
                if (t[1] == 0)
                {
                    return Dataset.GetPersonList()[graph[0][me]].GetFullName() + " и " + Dataset.GetPersonList()[graph[0][it]].GetFullName() +
                        " являются родственниками по прямой нисходящей линии с разницей в " + t[1].ToString() + "поколений";
                }
                if (graph[1][me] > graph[1][it])
                {
                    return Dataset.GetPersonList()[graph[0][me]].GetFullName() + " и " + Dataset.GetPersonList()[graph[0][it]].GetFullName() +
                        " являются родственниками по непрямой нисходящей линии с разницей в " + t[1].ToString() + "поколений";
                }
                return "";
            }
        }
    }
}
