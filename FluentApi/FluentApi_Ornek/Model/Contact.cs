using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi_Ornek.Model
{
    public class Contact
    {
        public int ID { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
