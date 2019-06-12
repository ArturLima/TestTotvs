using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.Domain
{
    public class Product
    {
        [Key]
        [Column("Id")]
        public int ProductId { get; set; }

        [Column("Product")]
        public string ProductName { get; set; }

        [Column("Amount")]
        public int Amount { get; set; }

        [Column("Value")]
        public float Value { get; set; }
        
    }
}
