using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Sales
    {
        public static List<Sales> sList = new List<Sales>();
        public int id { set; get; }
        public string date { set; get; }
        public int idProduct { set; get; }
        public string nameProduct { set; get; }
        public int ammount { set; get; }
        public double sumSales { set; get; }

        public Sales()
        {

        }

        public Sales(int i, string d, int iP,string nP, int a, double sumS)
        {
            id = i;
            date = d;
            idProduct = iP;
            nameProduct = nP;
            ammount = a;
            sumSales = sumS;
        }
    }
}
