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

namespace Praktika2EF
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Praktika2Entities1 content = new Praktika2Entities1();
        public Window1()
        {
            InitializeComponent();
            TableWindow.ItemsSource = content.Customers.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void InsertCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            Customers c = new Customers();

            c.CustomerSurName = CustomerTextBox1.Text;
            c.CustomerName = CustomerTextBox2.Text;
            c.CustomerSecondName = CustomerTextBox3.Text;
            content.Customers.Add(c);

            content.SaveChanges();
            TableWindow.ItemsSource = content.Customers.ToList();
        }

        private void UpdateCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if(TableWindow.SelectedItem != null)
            {
                var select = TableWindow.SelectedItem as Customers;
                select.CustomerSurName = CustomerTextBox1.Text;
                select.CustomerName = CustomerTextBox2.Text;
                select.CustomerSecondName = CustomerTextBox3.Text;

                content.SaveChanges();
                TableWindow.ItemsSource = content.Customers.ToList();
            }
        }

        private void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (TableWindow.SelectedItem != null)
            {
                content.Customers.Remove(TableWindow.SelectedItem as  Customers);

                content.SaveChanges();
                TableWindow.ItemsSource = content.Customers.ToList();
            }
        }

        private void TableWindow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TableWindow.SelectedItem != null)
            {
                var select = TableWindow.SelectedItem as Customers;

                CustomerTextBox1.Text = select.CustomerSurName;
                CustomerTextBox2.Text = select.CustomerName;
                CustomerTextBox3.Text = select.CustomerSecondName;
            }
        }
    }
}
