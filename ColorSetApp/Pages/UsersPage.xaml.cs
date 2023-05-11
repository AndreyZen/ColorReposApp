using ColorSetApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public List<User> Users = new List<User>();
        public UsersPage()
        {
            InitializeComponent();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            App.Context.User.AddRange(Users.Skip(App.Context.User.Count()));
            try
            {
                App.Context.SaveChanges();

                MessageBox.Show("Сохранение успешно!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
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

                App.Context.User.RemoveRange(Users.Skip(App.Context.User.Count()));
            }
            finally
            {
                UpdateData();
            }
        }

        private void UpdateData()
        {
            Users = App.Context.User.ToList();

            Users = Users.Where(p => p.FullName.ToLower().Trim().Contains(TbUserName.Text.ToLower().Trim())).ToList();

            DgUsers.ItemsSource = Users;
        }

        private void TbUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }
    }
}
