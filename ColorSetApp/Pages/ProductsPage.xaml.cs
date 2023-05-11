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
            UpdateLvSource();
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
            var categories = App.Context.Category.ToList();
            categories.Insert(0, new Category() { Name = "Все категории" });
            CBxCategory.ItemsSource = categories;
            CBxCategory.SelectedIndex = 0;

            var manufacturers = App.Context.Manufacturer.ToList();
            manufacturers.Insert(0, new Manufacturer() { Name = "Все производители" });
            CBxManufacturer.ItemsSource = manufacturers;
            CBxManufacturer.SelectedIndex = 0;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Product product = (sender as Button).DataContext as Product;
            product.IsActual = !product.IsActual;
            App.Context.SaveChanges();
        }

        private void UpdateLvSource()
        {
            var products = App.Context.Product.ToList();

            if (CBxCategory.SelectedIndex != 0 && CBxCategory.SelectedItem is Category category)
                products = products.Where(x => x.Category == category).ToList();

            if (CBxManufacturer.SelectedIndex != 0 && CBxManufacturer.SelectedItem is Manufacturer manufacturer)
                products = products.Where(x => x.Manufacturer == manufacturer).ToList();

            if (!string.IsNullOrWhiteSpace(TBxSearch.Text))
                products = products.Where(x => x.Name.ToLower().Trim().Contains(TBxSearch.Text.ToLower().Trim())).ToList();

            switch (CBxSort.SelectedIndex)
            {
                case 1:
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                case 2:
                    products = products.OrderByDescending(p => p.Price).ToList();
                    break;
                default:
                    break;
            }

            if (LVProducts != null)
                LVProducts.ItemsSource = products;
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

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void CBxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateLvSource();
        }

        private void TBxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateLvSource();
        }
    }
}
