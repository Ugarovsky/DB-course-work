using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Delivery
    {
        public static List<Delivery> dList = new List<Delivery>();

        public int id { set; get; }
        public int id_producer { set; get; }
        public string name_producer { set; get; }
        public int id_employee { set; get; }
        public string login_employee { set; get; }
        public int id_product { set; get; }
        public string name_product { set; get; }
        public int ammount { set; get; }
        public double sum_delivery { set; get; }
        public string date_delivery { set; get; }


        public Delivery()
        {

        }

        public Delivery(int i, int idP, string nP,int idE, 
            string l,int idPr, string nPr, int a, double s, string d)
        {
            id = i;
            id_producer = idP;
            name_producer = nP;
            id_employee = idE;
            login_employee = l;
            id_product = idPr;
            name_product = nPr;
            ammount = a;
            sum_delivery = s;
            date_delivery = d;
        }
    }
}
