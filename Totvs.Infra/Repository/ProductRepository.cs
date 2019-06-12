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
    public class ProductRepository : IProductRepository
    {
        ApplicationDBContext _context { get; }
        public ProductRepository(ApplicationDBContext ctx)
        {
            _context = ctx;
        }
        public List<Product> GetAllProduct()
        {
            var Products = _context.Products.ToList();
            return Products;
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }
    }
}
