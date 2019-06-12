using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.Infra.Persistence;
using Totvs.Infra.Repository;
using Totvs.Infra.Repository.Interfaces;

namespace Totvs.Infra.Persistence
{
    public class UnityOfWork : IUnityOfWork
    {
        ApplicationDBContext _context;
        public ICustomerRepository Customers { get; set; }
        public IProductRepository Products { get; set; }
        public IOrderRepository Orders { get; set; }

        public UnityOfWork(ApplicationDBContext ctx)
        {
            _context = ctx;
            Customers = new CustomerRepository(_context);
            Products = new ProductRepository(_context);
            Orders = new OrderRepository(_context);

        }
        public void Salvar()
        {
            _context.SaveChanges();
        }

    }
}
