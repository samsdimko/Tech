using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samsonov_ProjectForTech
{
    public class Graph
    {
        List<Person> personList = Dataset.GetPersonList();
        int ID;
        int count;
        List<int> IDList = new List<int>();
        List<int> RelationList = new List<int>();
        List<List<int>> GenerationNumber = new List<List<int>>(2);
        List<List<int>> gr = new List<List<int>>(2);
        
        public Graph(int ID)
        {            
            this.ID = ID;
            IDList.Add(ID);
            RelationList.Add(0);
            this.count = 0;
            FindUp(this.ID);
            FindDown(this.ID);
            MakeArray();
            SortArray();
        }
        private Graph(int ID, int count)
        {
            this.ID = ID;
            IDList.Add(this.ID);
            RelationList.Add(count);
            this.count = count;
            FindUp(this.ID);
            FindDown(this.ID);
        }
        private void FindUp(int ID)
        {
            if (personList[ID].GetFatherID() != -1)
            {
                if (IDList.IndexOf(personList[ID].GetFatherID()) != -1)
                {
                    IDList.Add(personList[ID].GetFatherID());
                    RelationList.Add(count);
                    Graph graphUp = new Graph(personList[ID].GetFatherID(), count + 1);
                }
            }
            else if (personList[ID].GetMotherID() != -1)
            {
                if (IDList.IndexOf(personList[ID].GetMotherID()) != -1)
                {
                    IDList.Add(personList[ID].GetMotherID());
                    RelationList.Add(count);
                    Graph graphUp = new Graph(personList[ID].GetMotherID(), count + 1);
                }
            }
        }
        private void FindDown(int ID)
        {
            int numberChild = personList[this.ID].GetChildList().Count;
            if (numberChild != 0)
            {
                for (int i = 0; i < numberChild; i++)
                {
                    if (IDList.IndexOf(personList[this.ID].GetChildList()[i]) != -1)
                    {
                        IDList.Add(personList[this.ID].GetChildList()[i]);
                        RelationList.Add(count);
                        Graph graphDown = new Graph(personList[this.ID].GetChildList()[i]);
                    }
                }
            }
        }
        private void MakeArray()
        {
            for (int i = 0; i < this.IDList.Count; i++)
            {
                this.gr[0].Add(IDList[i]);
                this.gr[1].Add(RelationList[i]);
            }
            for (int i = 0, k = RelationList.Max(); i < IDList.Count; i++)
            {
                bool l = false;
                for (int j = i; j < IDList.Count; j++)
                {
                    if (this.gr[1][j] == k)
                    {
                        int change = this.gr[1][i];
                        this.gr[1][i] = this.gr[1][j];
                        this.gr[1][j] = change;
                        change = gr[0][i];
                        this.gr[0][i] = this.gr[0][j];
                        this.gr[0][j] = change;
                        l = true;
                        break;
                    }
                }
                if (l == false)
                {
                    this.GenerationNumber[0].Append(k);
                    this.GenerationNumber[1].Append(i+1);
                    k--;
                }
            }            
        }
        private void SortArray()
        {
            for (int i = 0; i < this.IDList.Count; i++)
            {
                int t = i;
                while (this.gr[1][i] == this.gr[1][t] && t < gr[1].Count)
                {
                    t++;
                }
                for (int j = i + 1; j < t; j++) 
                {
                    if (personList[gr[0][i]].GetChildList()[0] == personList[gr[0][j]].GetChildList()[0] && personList[gr[0][i]].GetChildList() != null)
                    {
                        int change = this.gr[1][i];
                        this.gr[1][i] = this.gr[1][j];
                        this.gr[1][j] = change;
                        change = this.gr[0][i];
                        this.gr[0][i] = this.gr[0][j];
                        this.gr[0][j] = change;
                        i += 2;
                        break;
                    }
                }
            }
        }        
        public List<List<int>> GetList()
        {
            return this.gr;
        }
        public List<List<int>> GetGenerations()
        {
            return this.GenerationNumber;
        }
        
    }
}