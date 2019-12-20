using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Samsonov_ProjectForTech
{
    class Dataset
    {
        public static List<Person> PersonList = new List<Person>();
        public static int ID = 0;
        static Dataset()
        {
            JsonSerializer a = new JsonSerializer();
            PersonList = (List<Person>)a.Deserialize(File.OpenText("Dataset.json"), typeof(List<Person>));
        }
        public static void DatasetAdd(Person person)
        {
            PersonList.Add(person);
            JsonSerializer b = new JsonSerializer();
            b.Serialize(File.CreateText("Dataset.json"), PersonList);
            ID++;
        }
        public static List<Person> GetPersonList()
        {
            return PersonList;
        }
        public static int GetID()
        {
            return ID;
        }
    }
}
