using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Shop
{
    class DB
    {
        SqlConnection conn;
        public void openConnection(string connStr)
        {         
          conn = new SqlConnection(connStr);
            conn.Open();
        }

        public void closeConnection()
        {
            conn.Close();
        }

        public void getAllDelivery()
        {
            using (SqlCommand cmd = new SqlCommand("getAllDelivery", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                     Delivery.dList.Clear();
                    while (reader.Read())
                    {
                        Delivery d = new Delivery(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3),
                        reader.GetString(4),reader.GetInt32(5),reader.GetString(6), reader.GetInt32(7), reader.GetDouble(8), reader.GetDateTime(9).ToString());
                        Delivery.dList.Add(d);
                    }
                }
                reader.Close();

            }
        }

        public void buySelectedProduct(int id, int ammount)
        {
            using (SqlCommand cmd = new SqlCommand("buySelectedProduct", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@am", ammount);
                cmd.ExecuteNonQuery();
            }
        }

        public bool getAllEmplLogPass(string l, string p)
        {
            using (SqlCommand cmd = new SqlCommand("getAllUsers", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(0).Equals(l) & reader.GetString(1).Equals(p) & reader.GetString(2).Equals("Продавец"))
                        {
                            return true;
                        }
                    }
                }
                reader.Close();
            }
            return false;
        }

        public void filtrProduct(int id)
        {
            using (SqlCommand cmd = new SqlCommand("filtrProduct", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    ProductsList.prodList.Clear();
                    while (reader.Read())
                    {
                        ProductsList pl = new ProductsList(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3),
                        reader.GetInt32(4), reader.GetString(5), reader.GetString(6));
                        ProductsList.prodList.Add(pl);
                    }
                }
                reader.Close();
            }
        }

        public void getAllProducts()
        {
            using (SqlCommand cmd = new SqlCommand("selectProducts", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
                         
                if (reader.HasRows)
                {
                    ProductsList.prodList.Clear();
                    while (reader.Read())
                    {
                        ProductsList pl = new ProductsList(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3),
                        reader.GetInt32(4), reader.GetString(5), reader.GetString(6));
                        ProductsList.prodList.Add(pl);
                    }
                }
                reader.Close();

            }
        }

        public void startDelivery(int id, double price, int idP, string log, int ammount)
        {
            using (SqlCommand cmd = new SqlCommand("startDelivery", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@idP", idP);
                cmd.Parameters.AddWithValue("@log", log);
                cmd.Parameters.AddWithValue("@am", ammount);
                cmd.ExecuteNonQuery();
            }
        }

        public void addNewProduct(string name, double price, int idP, int idC, string desc, int am)
        {
            using (SqlCommand cmd = new SqlCommand("addNewProduct", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nameP", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@idP", idP);
                cmd.Parameters.AddWithValue("@idC", idC);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Parameters.AddWithValue("@am", am);
                cmd.ExecuteNonQuery();
            }
        }

        public void deleteProductId(int id)
        {
            using (SqlCommand cmd = new SqlCommand("deleteProductId", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public bool getAllUsers(string l, string p)
        {
            using (SqlCommand cmd = new SqlCommand("getAllUsers", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(0).Equals(l) & reader.GetString(1).Equals(p) & reader.GetString(2).Equals("Администратор"))
                        {
                            return true;
                        }               
                    }
                }
                reader.Close();
            }
            return false;
        }

        public void getAllSales()
        {
            using (SqlCommand cmd = new SqlCommand("getAllSales", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Sales.sList.Clear();
                    while (reader.Read())
                    {
                        Sales s = new Sales(reader.GetInt32(0), reader.GetDateTime(1).ToString(), reader.GetInt32(2),reader.GetString(3), reader.GetInt32(4), reader.GetDouble(5));
                        Sales.sList.Add(s);
                    }
                }
                reader.Close();
            }
        }

        public void getAllProducers()
        {
            using (SqlCommand cmd = new SqlCommand("getAllProducers", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Producers.producerList.Clear();
                    while (reader.Read())
                    {
                        Producers pc = new Producers(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                        Producers.producerList.Add(pc);
                    }
                }
                reader.Close();
            }
        }

        public void getAllEmployee()
        {
            using (SqlCommand cmd = new SqlCommand("selectEmployee", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    EmployeeList.emplList.Clear();
                    while (reader.Read())
                    {
                        EmployeeList el = new EmployeeList(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDouble(6));
                        EmployeeList.emplList.Add(el);
                    }
                }
                reader.Close();
            }            
        }

        public void deleteEmplId(int id)
        {
            using (SqlCommand cmd = new SqlCommand("deleteEmployeeId", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void updatePriceProduct(int id, double price)
        {
            using (SqlCommand cmd = new SqlCommand("updatePriceProduct", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.ExecuteNonQuery();
            }
        }

        public void updateEmployee(int id, string name, string surname, string post, string log, string pass, double salary)
        {
            using (SqlCommand cmd = new SqlCommand("updateEmployeeId", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",id);
                cmd.Parameters.AddWithValue("@name_employee", name);
                cmd.Parameters.AddWithValue("@surname_employee", surname);
                cmd.Parameters.AddWithValue("@post", post);
                cmd.Parameters.AddWithValue("@empl_login", log);
                cmd.Parameters.AddWithValue("@empl_passw", pass);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.ExecuteNonQuery();
            }
        }

        public void deleteAllEmpl()
        {
            using (SqlCommand cmd = new SqlCommand("deleteAllEmployee", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }

        public void addEmploye(string nameEmpl, string surnameEmpl, string post,string log, string pass, double salary)
        {
            using (SqlCommand cmd = new SqlCommand("addNewEmployee", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name_employee", nameEmpl);
                cmd.Parameters.AddWithValue("@surname_employee", surnameEmpl);
                cmd.Parameters.AddWithValue("@post", post);
                cmd.Parameters.AddWithValue("@log", log);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.ExecuteNonQuery();
            }

        }

        public void setDiscountCategory(int id, int disc)
        {
            using (SqlCommand cmd = new SqlCommand("setDiscountCategory", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@discount", disc);
                cmd.ExecuteNonQuery();
            }
        }

        public void updateCategory(int id,string newname)
        {
            using (SqlCommand cmd = new SqlCommand("updateCategory", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@newname", newname);
                cmd.ExecuteNonQuery();
            }
        }
        public void getAllCategories()
        {
            using (SqlCommand cmd = new SqlCommand("getAllCat", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Categories.categoriesList.Clear();
                    while (reader.Read())
                    {
                        Categories catg = new Categories(reader.GetInt32(0), reader.GetString(1));
                        Categories.categoriesList.Add(catg);
                    }
                }
                reader.Close();
            }
        }
    }
}



