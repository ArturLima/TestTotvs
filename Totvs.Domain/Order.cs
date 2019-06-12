using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.Domain
{
    public class Order
    {
        [Key]
        [Column("Number")]
        public int Number { get; set; }

        [Column("DeliveryDate")]
        public DateTime DeliveryDate { get; set; }

        [Column("Customer_id")]
        public int IdCustomer { get; set; }

        [NotMapped]
        public Customer Customer { get; set; }

        [Column("TotalValue")]
        public float TotalValue { get; set; }

        [NotMapped]
        public List<OrderItens> Products { get; set; }
    }
}
