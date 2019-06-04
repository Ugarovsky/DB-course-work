using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
   public class EmployeeList
    {
        public static List<EmployeeList> emplList = new List<EmployeeList>();
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string post { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public double salary { get; set; }

       public EmployeeList(int i, string n, string s, string p, string l,
            string pass, double sal)
        {
            id = i;
            name = n;
            surname = s;
            post = p;
            login = l;
            password = pass;
            salary = sal;
        }
    }
}
