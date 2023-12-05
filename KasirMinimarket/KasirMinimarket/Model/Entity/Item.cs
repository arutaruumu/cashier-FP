using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirMinimarket.Model.Entity
{
    public class Item
    {
        public string id_item { get; set; }
        public string nama_item { get; set; }
        public int harga { get; set; }
        public string id_supplier { get; set; }
        public int stock { get; set; }
    }
}
