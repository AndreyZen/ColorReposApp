using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSetApp.Entities
{
    public partial class User
    {
        public string FullName { get => LastName + " " + FirstName + " " + Patroniumic; }

        public string Abbreviature
        {
            get
            {
                string pat = Patroniumic.Length != 0 ? Patroniumic[0] + "." : "";
                string nam = FirstName[0] + ". ";

                return LastName + " " + nam + pat;
            }
        }
    }
}
