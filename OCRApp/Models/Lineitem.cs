using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRApp.Models
{
    class Lineitem
    {
        public int LineitemId { get; set; }
        public Nullable<int> InvoiceID { get; set; }
        public string ItemName { get; set; }
        public Nullable<double> ItemQty { get; set; }
        public Nullable<double> ItemAmount { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
