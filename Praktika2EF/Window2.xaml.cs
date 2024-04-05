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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Praktika2Entities1 content = new Praktika2Entities1();
        public Window2()
        {
            InitializeComponent();
            TableWindow.ItemsSource = content.Directors.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void InsertDirectorButton_Click(object sender, RoutedEventArgs e)
        {
            Directors d = new Directors();

            d.DirectorSurName = DirectorTextBox1.Text;
            d.DirectorName = DirectorTextBox2.Text;
            d.DirectorSecondName = DirectorTextBox3.Text;
            content.Directors.Add(d);

            content.SaveChanges();
            TableWindow.ItemsSource = content.Directors.ToList();
        }

        private void UpdateDirectorButton_Click(object sender, RoutedEventArgs e)
        {
            if (TableWindow.SelectedItem != null)
            {
                var select = TableWindow.SelectedItem as Directors;
                select.DirectorSurName = DirectorTextBox1.Text;
                select.DirectorName = DirectorTextBox2.Text;
                select.DirectorSecondName = DirectorTextBox3.Text;

                content.SaveChanges();
                TableWindow.ItemsSource = content.Directors.ToList();
            }
        }

        private void DeleteDirectorButton_Click(object sender, RoutedEventArgs e)
        {
            if (TableWindow.SelectedItem != null)
            {
                content.Directors.Remove(TableWindow.SelectedItem as Directors);

                content.SaveChanges();
                TableWindow.ItemsSource = content.Directors.ToList();
            }
        }

        private void TableWindow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TableWindow.SelectedItem != null)
            {
                var select = TableWindow.SelectedItem as Directors;

                DirectorTextBox1.Text = select.DirectorSurName;
                DirectorTextBox2.Text = select.DirectorName;
                DirectorTextBox3.Text = select.DirectorSecondName;
            }
        }
    }
}
