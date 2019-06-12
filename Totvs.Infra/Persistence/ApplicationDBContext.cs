using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.Domain;

namespace Totvs.Infra.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItens> OrderItens { get; set; }

        public ApplicationDBContext() : base("DefaultConnection")
        {
        }

    }
}
