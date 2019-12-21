using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samsonov_ProjectForTech
{
    class TableMain
    {
        static List<string> Names = new List<string>();
        private static void GetList()
        {
            for (int i = 0; i < Dataset.GetPersonList().Count; i++)
            {
                Names.Add(Dataset.GetPersonList()[i].GetFullName());
            }
        }
        public static List<string> SetList()
        {
            return Names;
        }
        TableMain()
        {
            GetList();
            SetList();
        }
    }
}
