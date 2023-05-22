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
    /// Логика взаимодействия для ProductboxPage.xaml
    /// </summary>
    public partial class ProductboxPage : Page
    {
        public ProductboxPage()
        {
            InitializeComponent();
            UpdateLvSource();
        }


        private void TbCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (int.TryParse(textBox.Text, out int count))
            {
                App.Products.Find(p => p == textBox.DataContext as ReceiptProduct).Count = count;
                UpdateLvSource();
            }
            else
            {
                MessageBox.Show("Введено не корректное значение!", "Ошибка преобразования", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox.Text = "1";
            }
        }

        private void UpdateLvSource()
        {
            if (LvProduct != null)
            {
                LvProduct.ItemsSource = null;
                if (App.Products.Count != 0)
                {
                    TbNullValue.Visibility = Visibility.Collapsed;
                    LvProduct.ItemsSource = App.Products;
                }
                else
                    TbNullValue.Visibility = Visibility.Visible;
            }
        }

        private void BtnRemouveCount_Click(object sender, RoutedEventArgs e)
        {
            var product = App.Products.Find(p => p == (sender as Button).DataContext as ReceiptProduct);
            if (product.Count > 1)
                product.Count--;
            else
            {
                if (MessageBox.Show("Вы действительно хотите удалить продукт из корзины?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    App.Products.Remove(product);
                }
            }
            UpdateLvSource();
        }

        private void BtnAddCount_Click(object sender, RoutedEventArgs e)
        {
            App.Products.Find(p => p == (sender as Button).DataContext as ReceiptProduct).Count++;
            UpdateLvSource();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (App.Products.Count > 0)
            {
                var receipt = new Receipt()
                {
                    Date = DateTime.Now,
                    User = App.CurrentUser
                };
                App.Context.Receipt.Add(receipt);

                foreach (var product in App.Products)
                    product.Receipt = receipt;

                App.Context.ReceiptProduct.AddRange(App.Products);
                try
                {
                    App.Context.SaveChanges();

                    if (MessageBox.Show("Данные успешно сохранены, хотите распечатать чек сейчас?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Question)
                        == MessageBoxResult.Yes)
                    {
                        //ToDo: Метод печати чека
                    }
                    //ToDo: Переход на страницу промотнра сохраненных данных
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении данных\n" + ex.Message, "Сохранение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("Корзина пуста, нечего сохранять", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.Products.Count > 0)
            {
                LvProduct.Visibility = Visibility.Visible;
                BtnSave.Visibility = Visibility.Visible;
                TbNullValue.Visibility = Visibility.Collapsed;
            }
            else
            {
                LvProduct.Visibility = Visibility.Collapsed;
                BtnSave.Visibility = Visibility.Collapsed;
                TbNullValue.Visibility = Visibility.Visible;
            }
        }
    }
}
