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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        Praktika2Entities1 content = new Praktika2Entities1();
        public Window4()
        {
            InitializeComponent();
            TableWindow.ItemsSource = content.Store.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void InsertStoreButton_Click(object sender, RoutedEventArgs e)
        {
            Store s = new Store();

            s.StoreName = StoreTextBox1.Text;
            s.StoreCityPlace = StoreTextBox2.Text;
            s.Director_ID = Convert.ToInt32(StoreTextBox3.Text);
            content.Store.Add(s);

            content.SaveChanges();
            TableWindow.ItemsSource = content.Store.ToList();
        }

        private void UpdateStoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (TableWindow.SelectedItem != null)
            {
                var select = TableWindow.SelectedItem as Store;

                select.StoreName = StoreTextBox1.Text;
                select.StoreCityPlace = StoreTextBox2.Text;
                select.Director_ID = Convert.ToInt32(StoreTextBox3.Text);

                content.SaveChanges();
                TableWindow.ItemsSource = content.Store.ToList();
            }
        }

        private void DeleteStoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (TableWindow.SelectedItem != null)
            {
                content.Store.Remove(TableWindow.SelectedItem as Store);

                content.SaveChanges();
                TableWindow.ItemsSource = content.Store.ToList();
            }
        }

        private void TableWindow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TableWindow.SelectedItem != null)
            {
                var select = TableWindow.SelectedItem as Store;

                StoreTextBox1.Text = select.StoreName;
                StoreTextBox2.Text = select.StoreCityPlace;
                StoreTextBox3.Text = Convert.ToString(select.Director_ID);
            }
        }
    }
}
