using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.Domain;

namespace Totvs.Infra.Repository.Interfaces
{
    public interface ICustomerRepository 
    {
        List<Customer> GetAllCustomer();
    }
}
