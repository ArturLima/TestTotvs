using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.Domain;
using Totvs.Infra.Persistence;
using Totvs.Infra.Repository.Interfaces;

namespace Totvs.Infra.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        ApplicationDBContext _context { get; }
        public CustomerRepository(ApplicationDBContext ctx)
        {
            _context = ctx;
        }

        public List<Customer> GetAllCustomer()
        {
            var Customers = _context.Customers.ToList();
            return Customers;
        }
    }
}
