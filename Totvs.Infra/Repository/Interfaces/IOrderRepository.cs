using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.Domain;

namespace Totvs.Infra.Repository.Interfaces
{
    public interface IOrderRepository
    {
        void Save(Order order);
        List<OrderModel> GetOrder(int id);
        List<OrderModel> GetOrderEntryDate(int id, string dataIni, string dataFim);

        List<OrderModel> GetAllOrder();
    }
}
