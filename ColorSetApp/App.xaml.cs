using ColorSetApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ColorSetApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            if(App.Context.User.ToList().Count < 1)
            {
                App.Context.User.Add(new User()
                {
                    EmployeeCode = "123",
                    FirstName = "Михаил",
                    LastName = "Зубенко",
                    Patroniumic = "Петрович",
                    IsActive = true,
                    IsAdmin = true
                });
                App.Context.SaveChanges();
            }
        }
        public static Entities.ColorBaseEntities Context { get; } = new Entities.ColorBaseEntities();
        public static Entities.User CurrentUser { get; set; }
        public static List<ReceiptProduct> Products { get; set; }
    }
}
