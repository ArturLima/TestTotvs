using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.Domain;

namespace Totvs.Infra.Repository.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProduct();
        Product GetProduct(int id);
    }
}
