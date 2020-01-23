using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Samsonov_ProjectForTech
{

    public class ContainerId
    {
        public int ID;
    }
    public class SearchPresenter
    { 
        public SearchPresenter(string str)
        {
            int[] find = Search.SearchAll(str);
            if (find == null)
            {
                MessageBox.Show("No such person");
            }
            else if (find.Length == 1)
            {
                RunAndStrartTree runAndStrartTree = new RunAndStrartTree(find[0]);
            }
            else
            {
                var contId = new ContainerId();
                ShowTreeList showTreeList = new ShowTreeList(find, contId);
                showTreeList.ShowDialog();
                RunAndStrartTree runAndStrartTree = new RunAndStrartTree(contId.ID);

            }
        }

        private void DoStuff()
        {
            MessageBox.Show("Do stuff on close");
        }
        public SearchPresenter(string str1, string str2, ref string text)
        {
            int[] find = Search.SearchByName(str1);
            if (find == null)
            {
                MessageBox.Show("No such person");
            }
            else
            {
                if (find.Length == 1)
                {
                    int id = find[0];
                    int[] find1 = Search.SearchByName(str2);
                    if (find1 == null)
                    {
                        MessageBox.Show("No such person");
                    }
                    else
                    {
                        if (find1.Length == 1)
                        {
                            int id1 = find1[0];
                            Graph graph = new Graph(id);
                            RelationShip relationShip = new RelationShip(graph, id, id1);
                            text = relationShip.MainSearch();
                        }
                        else
                        {
                            var contId1 = new ContainerId();
                            ShowTreeList showTreeList1 = new ShowTreeList(find1, contId1);
                            showTreeList1.ShowDialog();
                            Graph graph = new Graph(id);
                            RelationShip relationShip = new RelationShip(graph, id, contId1.ID);
                            text = relationShip.MainSearch();
                        }
                        
                    }
                }
                else
                {
                    var contId = new ContainerId();
                    ShowTreeList showTreeList = new ShowTreeList(find, contId);
                    showTreeList.ShowDialog();
                    int[] find1 = Search.SearchByName(str2);
                    if (find1 == null)
                    {
                        MessageBox.Show("No such person");
                    }
                    else
                    {
                        if (find1.Length == 1)
                        {
                            int id1 = find1[0];
                            Graph graph = new Graph(contId.ID);
                            RelationShip relationShip = new RelationShip(graph, contId.ID, id1);
                            text = relationShip.MainSearch();
                        }
                        else
                        {
                            var contId1 = new ContainerId();
                            ShowTreeList showTreeList1 = new ShowTreeList(find1, contId);
                            showTreeList1.ShowDialog();
                            Graph graph = new Graph(contId.ID);
                            RelationShip relationShip = new RelationShip(graph, contId.ID, contId1.ID);
                            text = relationShip.MainSearch();
                        }
                    }
                }
            }
        } 
    }
}
