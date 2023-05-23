using ColorSetApp.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
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

namespace ColorSetApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Window
    {

        private byte[] _preview = null;
        private byte[] _texture = null;
        public AddEditProductPage()
        {
            InitializeComponent();
            LoadCB();
            DataContext = new Product();
        }

        public AddEditProductPage(Product product)
        {
            InitializeComponent();
            LoadCB();
            DataContext = product;
            _preview = product.PreviewPhoto;
            _texture = product.TexturePhoto;
        }

        private void LoadCB()
        {
            CBxmanufacturer.ItemsSource = App.Context.Manufacturer.ToList();
            CBxCategory.ItemsSource = App.Context.Category.ToList();
        }

        private void ImgPreview_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Images |*.png;*.jpg;*.jpeg;"
            };
            if (ofd.ShowDialog() == true)
            {
                _preview = File.ReadAllBytes(ofd.FileName);
                ImgPreview.DataContext = _preview;
            }
        }

        private void ImgTexture_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Images |*.png;*.jpg;*.jpeg;"
            };
            if (ofd.ShowDialog() == true)
            {
                _texture = File.ReadAllBytes(ofd.FileName);
                ImgTexture.DataContext = _texture;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var product = DataContext as Product;

            string error = "";

            if (string.IsNullOrWhiteSpace(product.Name))
                error += "• Вы не ввели название продукта!\n";
            if (product.Category == null)
                error += "• Вы не выбрали категорию продукта!\n";
            if (product.Manufacturer == null && string.IsNullOrWhiteSpace(CBxmanufacturer.Text))
                error += "• Вы не выбрали производителя продукта!\n";
            if (product.Price <= 0.0m)
                error += "• Цена должна быть больше 0!\n";
            if (product.Category != null && product.Category.Id != 7 && (product.Volume == null || product.Volume <= 0))
                error += "• Для данной категории обезательно наличие веса, который больше 0!\n";
            if (product.Category != null && product.Category.Id < 3 && (product.Expenditure == null || product.Expenditure <= 0))
                error += "• Для данной категории обезательно наличие расхода, который больше 0!\n";
            if (product.Category != null && product.Category.Id < 3 && _texture == null)
                error += "• Для данной категории обезательно наличие фото текстуры!\n";
           

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Добавление невозможно по следующим причинам:\n\n" + error, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (product.Manufacturer == null)
                product.Manufacturer = App.Context.Manufacturer.FirstOrDefault(p => p.Name == CBxmanufacturer.Text) is Manufacturer manufacturer ? manufacturer :
                    new Manufacturer()
                    {
                        Name = CBxmanufacturer.Text
                    };
            product.TexturePhoto = _texture;
            product.PreviewPhoto = _preview;
            if (product.Id ==0)
            {
                product.IsActual = true;
                App.Context.Product.Add(product);
            }

            try
            {
                App.Context.SaveChanges();
                MessageBox.Show("Товар добавлен успешно!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Error);
                DialogResult = true;
            }
            catch (Exception ex)
            {
                string message = string.Empty;
                if (ex is DbEntityValidationException dbEx)
                {
                    foreach (var validErrors in dbEx.EntityValidationErrors)
                        foreach (var validErr in validErrors.ValidationErrors)
                            message += validErr.ErrorMessage + "\n";
                }
                if (ex is DbUpdateException dbUdEx)
                    message = dbUdEx.InnerException.InnerException.Message;
                MessageBox.Show(message);
                App.Context.Product.Remove(product);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ImgTexture.DataContext = _texture;
            ImgPreview.DataContext = _preview;
        }
    }
}
