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
    /// Логика взаимодействия для ReceiptPage.xaml
    /// </summary>
    public partial class ReceiptPage : Page
    {
        public ReceiptPage()
        {
            InitializeComponent();
            DPDate.SelectedDate = DateTime.Now;
            DPDate.DisplayDateEnd = DateTime.Now;
        }

        private void DPDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DGReceipt.ItemsSource = App.Context.Receipt.ToList().Where(p=> p.Date.Date == DPDate.SelectedDate).OrderByDescending(p=> p.Date).ToList();
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            //ToDo Печать чека
            NavigationService.Navigate(new ReportPage((sender as Button).DataContext as Receipt));
        }
    }
}
