using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Shop
{
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=StoreDB;Integrated Security=True";


        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.getAllProducts();
                prodGrid.ItemsSource = ProductsList.prodList;
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            TripleDes ecription = new TripleDes();
            try
            {
                string name = textBox.Text;
                string surname = textBox1.Text;
                string post = comboBox.Text;
                string log = textBox2.Text;
                string pass = ecription.Encrypt(passwordBox.Password, "300");
                double salary = Convert.ToDouble(textBox3.Text);
                if (salary == 0 || salary < 0 || name.Length == 0 || surname.Length == 0 || post.Length == 0
                    || log.Length == 0 || pass.Length == 0)
                {
                    MessageBox.Show("Проверьте данные сотрудника");
                }
                else
                {
                    DB db = new DB();
                    db.openConnection(connStr);
                    db.addEmploye(name, surname, post, log, pass, salary);
                    MessageBox.Show("Выполнено !!!");
                    db.closeConnection();
                }

            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            prodGrid.ItemsSource = null;
            prodGrid.ItemsSource = ProductsList.prodList;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.getAllEmployee();
                emplGrid.ItemsSource = EmployeeList.emplList;
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            emplGrid.ItemsSource = null;
            emplGrid.ItemsSource = EmployeeList.emplList;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox4.Text);
                DB db = new DB();
                db.openConnection(connStr);
                db.deleteEmplId(id);
                emplGrid.ItemsSource = null;
                emplGrid.ItemsSource = EmployeeList.emplList;
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmployeeList path = emplGrid.SelectedItem as EmployeeList;
                DB db = new DB();
                db.openConnection(connStr);
                db.updateEmployee(path.id, path.name, path.surname, path.post, path.login,
                    path.password, path.salary);

                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.deleteAllEmpl();
                EmployeeList.emplList.Clear();
                emplGrid.ItemsSource = null;
                emplGrid.ItemsSource = EmployeeList.emplList;
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();
                db.openConnection(connStr);
                ProductsList path = prodGrid.SelectedItem as ProductsList;
                db.updatePriceProduct(path.id, path.price);
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.getAllCategories();
                catGrid.ItemsSource = null;
                catGrid.ItemsSource = Categories.categoriesList;
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            catGrid.ItemsSource = null;
            catGrid.ItemsSource = Categories.categoriesList;
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();
                db.openConnection(connStr);
                Categories path = catGrid.SelectedItem as Categories;
                db.updateCategory(path.id, path.name_category);
                MessageBox.Show("Выполнено");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();
                db.openConnection(connStr);
                Categories path = catGrid.SelectedItem as Categories;
                int disc = Convert.ToInt32(textBox5.Text);
                if (disc == 0 || disc < 0)
                {
                    MessageBox.Show("Проверьте скидку");
                }
                else
                {
                    db.setDiscountCategory(path.id, disc);
                    MessageBox.Show("Выполнено");
                }

                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.addNewProduct(textBox6.Text, Convert.ToDouble(textBox7.Text), Convert.ToInt32(textBox8.Text),
                    Convert.ToInt32(textBox9.Text), textBox10.Text, Convert.ToInt32(textBox11.Text));
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.getAllProducers();
                pcGrid.ItemsSource = null;
                pcGrid.ItemsSource = Producers.producerList;
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button17_Click(object sender, RoutedEventArgs e)
        {
            pcGrid.ItemsSource = null;
            pcGrid.ItemsSource = Producers.producerList;
        }

        private void button18_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.deleteProductId(Convert.ToInt32(textBox12.Text));
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();
                db.openConnection(connStr);
                db.getAllSales();
                sGrid.ItemsSource = null;
                sGrid.ItemsSource = Sales.sList;
                MessageBox.Show("Выполнено !!!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка запроса");
            }
        }
        
    }
}