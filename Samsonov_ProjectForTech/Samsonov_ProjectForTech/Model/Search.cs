using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samsonov_ProjectForTech
{

    class Search
    {
        private string Name = null;
        private string Surname = null;
        private string Patronymic = null;
        private string Address = null;
        private int[] persons = null;

        private Search(string str)
        {
            bool a = false;
            foreach (char num in str)
            {
                if (Char.IsNumber(num))
                {
                    a = true;
                    break;
                }
            }
            if (a == false)
            {
                int len = str.IndexOf(' ');
                Name = str.Substring(0, len - 1);
                int len1 = str.IndexOf(' ', len + 1);
                Surname = str.Substring(len + 1, len1 - 1);
                Patronymic = str.Substring(len1 + 1);
            }
            else
                Address = str;
        }
        private void Ser()
        {
            if (Address != null)
            {
                foreach (Person person in Dataset.GetPersonList())
                {
                    if (person.GetAddress(Address) == true)
                    {
                        persons.Append(person.Getid());
                    }
                }
            }
            else
            {
                foreach (Person person in Dataset.GetPersonList())
                {
                    if (person.GetName(Name, Surname, Patronymic) == true)
                    {
                        persons.Append(person.Getid());
                    }
                }
            }
        }
        public static int[] SearchAll(string str)
        {
            Search Str = new Search(str);
            Str.Ser();
            return Str.persons;
        }
        public static bool CheckName(string name)
        {
            if (name.IndexOf(' ') == -1 || name.IndexOf(' ', (name.IndexOf(' ') + 1)) == -1)
            {
                return false;
            }
            else
                return true;
        }
    }
}