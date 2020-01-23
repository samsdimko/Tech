using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samsonov_ProjectForTech
{
    public static class Search
    {
        public static int[] SearchAll(string str)
        {
            var searchQuery = str;
            int[] find = Dataset.PersonList.Where(x => x.GetFullName().Contains(searchQuery) ||
                                                       x.GetAddress().Contains(searchQuery) ||
                                                       x.GetPlaceOfBirth().Contains(searchQuery))
                                                       .Select(x => x.GetId()).ToArray();
            return find;
        }
        public static int[] SearchByName(string str)
        {
            var searchQuery = str;
            int[] find = Dataset.PersonList.Where(x => x.GetFullName().Contains(searchQuery)).Select(x => x.GetId()).ToArray();
            return find;
        }
    }
}
