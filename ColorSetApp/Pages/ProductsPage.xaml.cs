using ColorSetApp.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorSetApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
        }

        private void ColumnDefinition_MouseEnter(object sender, MouseEventArgs e)
        {
            var a = (sender as ColumnDefinition).Parent as Grid;
        }

        private void ColumnDefinition_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ColumnDefinition_MouseEnter1(object sender, MouseEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LVProducts.ItemsSource = App.Context.Product.ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Product product = (sender as Button).DataContext as Product;
            product.IsActual = !product.IsActual;
            App.Context.SaveChanges();

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddBuy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
