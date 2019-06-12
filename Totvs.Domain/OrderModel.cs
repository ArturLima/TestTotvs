using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.Domain
{
    public class OrderModel
    {
        public int IdPedido { get; set; }
        public string NameCustomer { get; set; }
        public int TotalValue { get; set; }
    }
}
