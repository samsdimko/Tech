using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samsonov_ProjectForTech
{
    class TableMain
    {
        static string[] Names = new string[Dataset.GetPersonList().Count];
        private static void GetList()
        {
            for (int i = 0; i < Dataset.GetPersonList().Count; i++)
            {
                Names[i] = Dataset.GetPersonList()[i].GetFullName();
            }
        }
        public static string[] SetList()
        {
            GetList();
            return Names;
        }
    }
}
