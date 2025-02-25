using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Orders
    {
        public int Id { get; set; }
        public int Id_user { get; set; }
        public int Final_sum { get; set; }
        public string Status_orders { get; set; }
        public string Date_order { get; set; }
        public string Date_end { get; set; }
        public string comment { get; set; }
    }
}
