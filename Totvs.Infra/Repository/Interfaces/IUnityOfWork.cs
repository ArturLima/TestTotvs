using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.Infra.Repository.Interfaces
{
    public interface IUnityOfWork
    {
        ICustomerRepository Customers { get; }

        IProductRepository Products { get; }

        IOrderRepository Orders { get; }

        void Salvar();
    }
}
