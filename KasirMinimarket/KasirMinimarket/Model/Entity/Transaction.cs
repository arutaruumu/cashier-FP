using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirMinimarket.Model.Entity
{
    public class Transaction
    {
        public string id_trans { get; set; }
        public string id_admin { get; set; }
        public string id_item { get; set; }
        public int subtotal { get; set; }
        public int diskon { get; set; }
        public int total { get; set; }

    }
}
