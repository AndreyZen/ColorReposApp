using ColorSetApp.Pages;
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

namespace ColorSetApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Идем на первую страницу
            MainFrame.Navigate(new AuthPage());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.Content is AuthPage)
                DpUpBar.Visibility = Visibility.Collapsed;
            else
            {
                TbUserName.Text = App.CurrentUser.FullName;
                BtnUsers.Visibility = App.CurrentUser.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
                DpUpBar.Visibility = Visibility.Visible;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AuthPage());
        }

        private void BtnSelection_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ColorSelectionPage());
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UsersPage());
        }

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsPage());
        }

        private void BtnProductBox_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductboxPage());
        }
    }
}
