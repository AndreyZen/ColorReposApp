using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSetApp.Entities
{
    public partial class User
    {
        public string FullName { get => LastName + " " + FirstName + " " + Patroniumic;}
    }
}
