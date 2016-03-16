using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRApp.Models
{
    class Invoice
    {
        public Invoice()
        {
            this.Lineitems = new List<Lineitem>();
        }

        public string InvoiceID { get; set; }
        public string VendorName { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public string TotalAmount { get; set; }
        public virtual ICollection<Lineitem> Lineitems { get; set; }
    }
}
