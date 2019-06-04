using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Categories
    {
        public static List<Categories> categoriesList = new List<Categories>();
        public int id { get; set; }
        public string name_category { get; set; }

        public Categories()
        {

        }

        public Categories(int i, string n)
        {
            id = i;
            name_category = n;
        }
    }
}
