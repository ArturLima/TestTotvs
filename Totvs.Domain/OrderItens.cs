using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.Domain
{
    public class OrderItens
    {
        public int id { get; set; }
        public int IdOrd { get; set; }
        public int IdProduct { get; set; }
        public int Amount { get; set; }
        public int Value { get; set; }
    }
}
