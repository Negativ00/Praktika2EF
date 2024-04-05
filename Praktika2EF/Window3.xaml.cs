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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        Praktika2Entities1 content = new Praktika2Entities1();
        public Window3()
        {
            InitializeComponent();
            TableWindow.ItemsSource = content.Purchases.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void InsertPurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            Purchases p = new Purchases();

            p.PurchaseName = PurchaseTextBox1.Text;
            p.PurchasePrice = Convert.ToInt32(PurchaseTextBox2.Text);
            p.Customer_ID = Convert.ToInt32(PurchaseTextBox3.Text);
            p.Store_ID = Convert.ToInt32(PurchaseTextBox4.Text);
            content.Purchases.Add(p);

            content.SaveChanges();
            TableWindow.ItemsSource = content.Purchases.ToList();
        }

        private void UpdatePurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (TableWindow.SelectedItem != null)
            {
                var select = TableWindow.SelectedItem as Purchases;

                select.PurchaseName =PurchaseTextBox1.Text;
                select.PurchasePrice = Convert.ToInt32(PurchaseTextBox2.Text);
                select.Customer_ID = Convert.ToInt32(PurchaseTextBox3.Text);
                select.Store_ID = Convert.ToInt32(PurchaseTextBox4.Text);
            }
        }

        private void DeletePurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (TableWindow.SelectedItem != null)
            {
                content.Purchases.Remove(TableWindow.SelectedItem as Purchases);

                content.SaveChanges();
                TableWindow.ItemsSource = content.Purchases.ToList();
            }
        }

        private void TableWindow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TableWindow.SelectedItem != null)
            {
                var select = TableWindow.SelectedItem as Purchases;

                PurchaseTextBox1.Text = select.PurchaseName;
                PurchaseTextBox2.Text = Convert.ToString(select.PurchasePrice);
                PurchaseTextBox3.Text = Convert.ToString(select.Customer_ID);
                PurchaseTextBox4.Text = Convert.ToString(select.Store_ID);
            }
        }
    }
}
