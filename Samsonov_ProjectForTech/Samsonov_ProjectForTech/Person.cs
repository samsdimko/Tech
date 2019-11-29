using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Samsonov_ProjectForTech
{
    class Person
    {
        static private int ID = 0;
        private int id;
        private string Surname;
        private string Maiden_Name;
        private string Name;
        private string Patronymic;
        private string Birthday;
        private bool Birt = false;
        private string Place_of_birth;
        private string Date_of_death;
        private bool Death = false;
        private string Place_of_death;
        private string Nationality;
        private string Sosial;
        private string Educations;
        private string Proffesions;
        private string Address;
        private string From_ty;
        private string Source;
        private string Curriculum;
        private string Mother;
        private string Father;
        private int idF;
        private int idM;
        private List<int> idch = new List<int>();
        public static List<Person> PersonList = new List<Person>();
        public static void DatasetAdd(Person person)
        {
            PersonList.Add(person);
        }
        public Person(string Surname,
            string Maiden_Name,
            string Name,
            string Patronymic,
            string Birthday,
            string Birt,
            string Place_of_birth,
            string Date_of_death,
            string Death,
            string Place_of_death,
            string Nationality,
            string Sosial,
            string Educations,
            string Proffesions,
            string Address,
            string From_ty,
            string Source,
            string Curriculum,
            string Mother,
            string Father)
        {
            this.Surname = Surname;
            if (Maiden_Name != "-")
                this.Maiden_Name = Maiden_Name;
            this.Name = Name;
            this.Patronymic = Patronymic;
            this.Birthday = Birthday;
            if (Birt == "yes")
                this.Birt = true;
            else
                this.Birt = false;
            this.Place_of_birth = Place_of_birth;
            this.Date_of_death = Date_of_death;
            if (Death == "yes")
                this.Death = true;
            else
                this.Death = false;
            this.Place_of_death = Place_of_death;
            this.Nationality = Nationality;
            this.Sosial = Sosial;
            this.Educations = Educations;
            this.Proffesions = Proffesions;
            this.Address = Address;
            this.From_ty = From_ty;
            this.Source = Source;
            this.Curriculum = Curriculum;
            this.Mother = Mother;
            this.Father = Father;
            ID++;
            id = ID;
            idF = Search.SearchAll(Father)[0];
            idM = Search.SearchAll(Mother)[0];
            PersonList[idF].idch.Add(this.id);
        }


        public bool GetName(string Name, string Surname, string Patronymic)
        {
            if (this.Name.Contains(Name) != false && (this.Surname.Contains(Surname) != false || this.Maiden_Name.Contains(Surname) != false) && this.Patronymic.Contains(Patronymic) != false)
                return true;
            else return false;
        }
        public bool GetBirthPlace(string Place_of_birth)
        {
            if (this.Place_of_birth.Contains(Place_of_birth) != false)
                return true;
            else return false;
        }
        public bool GetAddress(string Address)
        {
            if (this.Address.Contains(Address) != false)
            {
                return true;
            }
            return false;
        }
        public static int GetID()
        {
            return ID;
        }
        public int Getid()
        {
            return id;
        }
        public static List<Person> GetPersonList()
        {
            return PersonList;
        }
    }
}
