using ColorSetApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для ColorSelectionPage.xaml
    /// </summary>
    public partial class ColorSelectionPage : Page
    {
        public ColorSelectionPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CbPrimer.ItemsSource = await App.Context.Product.Where(prod => prod.Category.Id == 1).ToListAsync();
            CbColor.ItemsSource = await App.Context.Product.Where(prod => prod.Category.Id == 2).ToListAsync();
            CbPolish.ItemsSource = await App.Context.Product.Where(prod => prod.Category.Id == 3).ToListAsync();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string message = string.Empty;
            if (!double.TryParse(TbArea.Text, out double area))
                message = "Поле \"Площадь\" имеет не допустимые символы\n";
            if (CbPrimer.SelectedItem == null || CbColor.SelectedItem == null || CbPolish.SelectedItem == null)
                message = "Выбраны не все элементы\n";

            if (message.Count() > 0)
                MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                var receipt = new List<ReceiptProduct>();
                receipt.Add(new ReceiptProduct()
                {
                    Product = CbPrimer.SelectedItem as Product,
                    Count = (int)Math.Ceiling(GetCount(CbPrimer.SelectedItem as Product, area))
                });
                receipt.Add(new ReceiptProduct()
                {
                    Product = CbColor.SelectedItem as Product,
                    Count = (int)Math.Ceiling(GetCount(CbColor.SelectedItem as Product, area))
                });
                receipt.Add(new ReceiptProduct()
                {
                    Product = CbPolish.SelectedItem as Product,
                    Count = (int)Math.Ceiling(GetCount(CbPolish.SelectedItem as Product, area))
                });
                App.Products.AddRange(receipt);
            }
        }

        private decimal GetCount(Product product, double area)
        {
            return (product.Expenditure.Value * (decimal)area) / product.Volume.Value;
        }

        private void CbPrimer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BaseImg.DataContext = (CbPrimer.SelectedItem as Product).TexturePhoto;
        }

        private void CbColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainImg.DataContext = (CbColor.SelectedItem as Product).TexturePhoto;
        }

        private void CbPolish_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MetallImg.DataContext = (CbPolish.SelectedItem as Product).TexturePhoto;
        }
    }
}
