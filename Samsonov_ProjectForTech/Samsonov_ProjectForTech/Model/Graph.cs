using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samsonov_ProjectForTech
{
    public class Graph
    {
        private List<Person> personList = Dataset.GetPersonList();
        private int ID;
        private int count;
        private List<int> IDList = new List<int>();
        private List<int> RelationList = new List<int>();
        private List<List<int>> GenerationNumber = new List<List<int>>(2);
        private List<List<int>> gr = new List<List<int>>(2);
        private int[,] Floid;
        
        public Graph(int ID)
        {            
            this.ID = ID;
            IDList.Add(ID);
            RelationList.Add(0);
            count = 0;
            FindUp(this.ID, count);
            FindDown(this.ID, count);            
            MakeArray();
            SortArray();
            Floid = new int[gr[0].Count, gr[0].Count];
            DoFloid();
        }
        private void FindUp(int id, int count)
        {
            if (id < 0 || personList.Count <= id) {
                return;
            }
            if (personList[id].GetFatherID() != -1)
            {
                if (IDList.IndexOf(personList[id].GetFatherID()) == -1)
                {
                    IDList.Add(personList[id].GetFatherID());
                    RelationList.Add(count - 1);
                    FindUp(personList[id].GetFatherID(), count - 1);
                    FindDown(personList[id].GetFatherID(), count - 1);
                }
            }
            if (personList[id].GetMotherID() != -1)
            {
                if (IDList.IndexOf(personList[id].GetMotherID()) == -1)
                {
                    IDList.Add(personList[id].GetMotherID());
                    RelationList.Add(count - 1);
                    FindUp(personList[id].GetMotherID(), count - 1);
                    FindDown(personList[id].GetMotherID(), count - 1);
                }
            }
        }
        private void FindDown(int id, int count)
        {
            if (personList[id].GetChildList().Count != 0)
            {
                for (int i = 0; i < personList[id].GetChildList().Count; i++)
                {
                    if (IDList.IndexOf(personList[id].GetChildList()[i]) == -1)
                    {
                        IDList.Add(personList[id].GetChildList()[i]);
                        RelationList.Add(count + 1);
                        FindUp(personList[id].GetChildList()[i], count + 1);
                        FindDown(personList[id].GetChildList()[i], count + 1);
                    }
                }
            }
        }
        private void MakeArray()
        {
            gr.Add(new List<int>());
            gr.Add(new List<int>());
            GenerationNumber.Add(new List<int>());
            GenerationNumber.Add(new List<int>());
            gr[0] = IDList;
            gr[1] = RelationList;
            for (int i = 0; i < gr[1].Count; i++) 
            {
                int min = gr[1][i];
                int index = i;
                for (int j = i; j < gr[1].Count; j++)
                {
                    if (gr[1][j] < min)
                    {
                        min = gr[1][j];
                        index = j;
                    }
                }
                if (index != i)
                {
                    int change = gr[1][i];
                    gr[1][i] = gr[1][index];
                    gr[1][index] = change;
                    change = gr[0][i];
                    gr[0][i] = gr[0][index];
                    gr[0][index] = change;
                }
            }
            for (int i = 0; i < gr[0].Count; i++)
            {
                int k = gr[1][0];
                for (int j = i; j < gr[0].Count; j++)
                {
                    k++;
                    if (gr[1][i] != gr[1][j])
                    {
                        GenerationNumber[0].Add(gr[1][i]);
                        GenerationNumber[1].Add(j);
                        i = j;
                        break;
                    }
                }
            }
            GenerationNumber[0].Add(GenerationNumber[0][GenerationNumber.Count - 1] + 1);
            GenerationNumber[1].Add(gr[0].Count);
            for (int i = GenerationNumber[0].Count - 1; i > 0; i--)
            {
                GenerationNumber[1][i] -= GenerationNumber[1][i - 1];
            }
        }
        private void SortArray()
        {
            for (int i = 0, k = 0; i < IDList.Count; i++)
            {
                int p = i + 1;
                for (int j = p; j < i + GenerationNumber[1][k]; j++)
                {
                    if (personList[gr[0][i]].GetChildList().Count != 0 && personList[gr[0][j]].GetChildList().Count != 0)
                    {
                        if (personList[gr[0][i]].GetChildList() == personList[gr[0][j]].GetChildList())
                        {
                            int change = gr[1][i + 1];
                            gr[1][i + 1] = gr[1][j];
                            gr[1][j] = change;
                            change = gr[0][i + 1];
                            gr[0][i + 1] = gr[0][j];
                            gr[0][j] = change;
                            i += 2;
                        }
                    }
                    p = j;

                }
                k++;
                i = p;
            }
        }        
        private void DoFloid()
        {
            for(int i = 0; i < gr[0].Count; i++)
            {
                for (int j = i; j < gr[0].Count; j++)
                {
                    if(Dataset.GetPersonList()[gr[0][i]].GetChildList().Count != 0)
                    {
                        if(Dataset.GetPersonList()[gr[0][i]].GetChildList().IndexOf(gr[0][j]) != -1)
                        {
                            Floid[i, j] = Floid[j, i] = 1;
                        }
                    }
                    if(Dataset.GetPersonList()[gr[0][i]].GetFatherID() == gr[0][j] ||
                       Dataset.GetPersonList()[gr[0][i]].GetMotherID() == gr[0][j])
                    {
                        Floid[i, j] = Floid[j, i] = 1;
                    }
                    if(i == j)
                    {
                        Floid[i, i] = 1;
                    }
                }
            }
            for (int i = 0; i < gr[0].Count; i++)
            {
                for (int j = i; j < gr[0].Count; j++)
                {
                    if (Floid[i, j] == 0)
                    {
                        Floid[i, j] = Floid[j, i] = 10000000;
                    }
                }
            }
            for (int t = 0; t < gr[0].Count; t++)
            {
                for (int i = 0; i < gr[0].Count; i++)
                {
                    for (int j = 0; j < gr[0].Count; j++)
                    {
                        for (int k = 0; k < gr[0].Count; k++)
                        {
                            if (k != i && k != j)
                            {
                                if (Floid[i, j] > Floid[i, k] + Floid[k, j])
                                {
                                    Floid[i, j] = Floid[i, k] + Floid[k, j];
                                }
                            }
                        }
                    }
                }
            }
        }
        public int[] Relation(int me, int it)
        {
            int[] result = new int[2];
            int cas = Math.Abs(gr[1][me] - gr[1][it]);
            result[0] = cas;
            result[1] = Floid[me, it] - cas;            
            return result;
        }
        public List<List<int>> GetList()
        {
            return gr;
        }
        public List<List<int>> GetGenerations()
        {
            return GenerationNumber;
        }
        public int GetMainId()
        {
            return ID;
        }
    }
}