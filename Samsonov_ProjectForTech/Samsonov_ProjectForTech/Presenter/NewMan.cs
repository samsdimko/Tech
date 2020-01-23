using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samsonov_ProjectForTech
{
    class NewMan
    {
        public NewMan(string Surname,
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
            Person person = new Person(Surname,
            Maiden_Name,
            Name,
            Patronymic,
            Birthday,
            Birt,
            Place_of_birth,
            Date_of_death,
            Death,
            Place_of_death,
            Nationality,
            Sosial,
            Educations,
            Proffesions,
            Address,
            From_ty,
            Source,
            Curriculum,
            Mother,
            Father);
            Dataset.DatasetAdd(person);
            Dataset.RecreateDataset();
        }

    }
}
