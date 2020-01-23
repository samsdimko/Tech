using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Samsonov_ProjectForTech
{
    static class Dataset
    {
        public static List<Person> PersonList = new List<Person>();
        public static int ID = 0;
        public static void RecreateDataset()
        {
            using (StreamReader file = File.OpenText("Dataset.json"))
            {
                JsonSerializer a = new JsonSerializer();
                PersonList = (List<Person>)a.Deserialize(file, typeof(List<Person>));
                if (PersonList != null)
                {
                    ID = PersonList.Count;
                }
            }
        }
        public static void DatasetAdd(Person person)
        {
            using (StreamWriter file = File.CreateText("Dataset.json"))
            {
                PersonList.Add(person);
                JsonSerializer b = new JsonSerializer();
                b.Serialize(file, PersonList);
                ID++;
                file.Close();
            }

        }
        public static List<Person> GetPersonList()
        {
            return PersonList;
        }
        public static int GetID()
        {
            return ID;
        }

        public static Person GetPersonByName(string name) 
        {
            var person = PersonList.FirstOrDefault(x => x.GetFullName().Contains(name));
            return person;
        }
    }
}
