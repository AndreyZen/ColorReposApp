using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ColorSetApp.Entities
{
    public partial class Product
    {
        public string BtnContent => IsActual ? "Удалить" : "Вернуть";
        public Brush Back => IsActual ? Brushes.Transparent : Brushes.Red;

        public uint CountOnBasket
        {
            get => App.Products.FirstOrDefault(p => p.Product.Id == Id) is ReceiptProduct receipt ? (uint)receipt.Count : 0;
            set => App.Products.FirstOrDefault(p => p.Product.Id == Id).Count = (int)value;
        }

        public Visibility VisibilityButtonCount => CountOnBasket == 0 ? Visibility.Hidden : Visibility.Visible;

        public Visibility VisibilityButtonCountInvers => VisibilityButtonCount == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
    }
}
