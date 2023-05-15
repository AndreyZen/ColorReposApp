using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSetApp.Entities
{
    public partial class Receipt
    {
        public decimal Sum => ReceiptProduct.Sum(p => p.Product.Price * p.Count);

        public string Order => string.Join("\n", ReceiptProduct.Select(p => $"{p.Product.Name} {p.Product.Price.ToString("C2", CultureInfo.GetCultureInfo("Ru-ru"))} x{p.Count}"));
    }
}
