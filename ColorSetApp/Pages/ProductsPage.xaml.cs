using ColorSetApp.Entities;
using ColorSetApp.Windows;
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
            if (new AddEditProductPage((sender as Button).DataContext as Product).ShowDialog() == true)
            {
                //ToDo Update
            }
        }

        private void BtnAddBuy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (new AddEditProductPage().ShowDialog() == true)
            {
                //ToDo Update
            }
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            Point point = e.GetPosition(grid);
            (grid.Children[1] as Image).Visibility = point.X > grid.ActualWidth / 2 ? Visibility.Collapsed : Visibility.Visible;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            (grid.Children[1] as Image).Visibility = Visibility.Visible;
        }
    }
}
