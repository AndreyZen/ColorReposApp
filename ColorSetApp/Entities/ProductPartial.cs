using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorSetApp.Entities
{
    public partial class Product
    {
        public string BtnContent => IsActual ? "Удалить" : "Вернуть";
        public Brush Back => IsActual ? Brushes.Transparent : Brushes.Red;
    }
}
