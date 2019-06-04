using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Producers
    {
        public static List<Producers> producerList = new List<Producers>();
        public int id { set; get; }
        public string name { set; get; }
        public string country { set; get; }
        public string city { set; get; }

        public Producers()
        {

        }

        public Producers(int i,string n, string c, string ct)
        {
            id = i;
            name = n;
            country = c;
            city = ct;
        }
    }
}
