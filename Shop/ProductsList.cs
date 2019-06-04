using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class ProductsList
    {
        public static List<ProductsList> prodList = new List<ProductsList>();
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public int ammount { get; set; }
        public string category { get; set; }
        public string nameProducer { get; set; }

        public ProductsList(int i, string n, double p, string d, int a, string c, string np)
        {
            id = i;
            name = n;
            price = p;
            description = d;
            ammount = a;
            category = c;
            nameProducer = np;
        }

    }
}
