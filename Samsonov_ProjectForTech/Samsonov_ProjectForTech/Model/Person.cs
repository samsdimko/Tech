using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace Samsonov_ProjectForTech
{
    class Person
    {
        [JsonProperty]
        private int id;
        [JsonProperty]
        private string Surname;
        [JsonProperty]
        private string Maiden_Name;
        [JsonProperty]
        private string Name;
        [JsonProperty]
        private string Patronymic;
        [JsonProperty]
        private string Birthday;
        [JsonProperty]
        private bool Birth = false;
        [JsonProperty]
        private string Place_of_birth;
        [JsonProperty]
        private string Date_of_death;
        [JsonProperty]
        private bool Death = false;
        [JsonProperty]
        private string Place_of_death;
        [JsonProperty]
        private string Nationality;
        [JsonProperty]
        private string Sosial;
        [JsonProperty]
        private string Educations;
        [JsonProperty]
        private string Proffesions;
        [JsonProperty]
        private string Address;
        [JsonProperty]
        private string From_ty;
        [JsonProperty]
        private string Source;
        [JsonProperty]
        private string Curriculum;
        [JsonProperty]
        private string Mother;
        [JsonProperty]
        private string Father;
        [JsonProperty]
        private int idF = -1;
        [JsonProperty]
        private int idM = -1;
        [JsonProperty]
        private List<int> idch = new List<int>();       
       

        
        [JsonConstructor]
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
                this.Birth = true;
            else
                this.Birth = false;
            this.Place_of_birth = Place_of_birth;
            this.Date_of_death = Date_of_death;
            if (Death == "yes")
            {
                this.Death = true;
            }
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

            var m = Dataset.PersonList.FirstOrDefault(x => x.GetFullName() == Mother);
            this.idM = m == null ? -1 : m.GetId();
            var f = Dataset.PersonList.FirstOrDefault(x => x.GetFullName() == Father);         
            this.idF = f == null ? -1 : f.GetId();

            id = Dataset.GetID();
        }

        public string GetFullName()
        {
            return this.Surname + " " + this.Name + " " + this.Patronymic;
        }
        public bool IsNameValid(string Name, string Surname, string Patronymic)
        {
            if (this.Name.Contains(Name) != false && (this.Surname.Contains(Surname) != false || this.Maiden_Name.Contains(Surname) != false) && this.Patronymic.Contains(Patronymic) != false)
                return true;
            else return false;
        }
        public bool IsBirthDayValid(string Place_of_birth)
        {
            if (this.Place_of_birth.Contains(Place_of_birth) != false)
                return true;
            else return false;
        }
        public string GetAddress()
        {
            return Address;
        }

        public bool IsAddressValid(string Address)
        {
            if (this.Address.Contains(Address) != false)
            {
                return true;
            }
            return false;
        }

        public string GetPlaceOfBirth() 
        {
            return Place_of_birth;
        }
        public int GetId()
        {
            return id;
        }       
        public int GetFatherID()
        {
            return idF;
        }
        public int GetMotherID()
        {
            return idM;
        }
        public List<int> GetChildList()
        {
            return idch;
        }
    }
}
