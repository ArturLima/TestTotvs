using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.Domain;
using Totvs.Infra.Persistence;
using Totvs.Infra.Repository.Interfaces;

namespace Totvs.Infra.Repository
{
    public class OrderRepository : IOrderRepository
    {
        ApplicationDBContext _context { get; }
        public OrderRepository(ApplicationDBContext ctx)
        {
            _context = ctx;
        }

        public void Save(Order order)
        {

            var NewOrder = new Order
            {
                IdCustomer = order.IdCustomer,
                DeliveryDate = order.DeliveryDate,
                TotalValue = order.TotalValue
            };
            _context.Orders.Add(NewOrder);
            _context.SaveChanges();
            
            for (int i = 1; i < order.Products.Count(); i++)
            {
                _context.OrderItens.Add(new OrderItens
                {
                    IdOrd = NewOrder.Number,
                    IdProduct = order.Products[i].IdProduct,
                    Value = order.Products[i].Value,
                    Amount = order.Products[i].Amount
                });
            }
            _context.SaveChanges();

        }

        public List<OrderModel> GetOrder(int id)
        {
            var lista = new List<OrderModel>();

            var order = (from ord in _context.Orders
                         join customer in _context.Customers on ord.IdCustomer equals customer.Id
                         where customer.Id == id  
                         select new
                         {
                             IdOrder = ord.Number,
                             Customer = customer.Name,
                             totalValue = ord.TotalValue
                         }).ToList();

            for (int i = 0; i < order.Count(); i++)
            {
                lista.Add(new OrderModel
                {
                    IdPedido = order[i].IdOrder,
                    NameCustomer = order[i].Customer,
                    TotalValue = Convert.ToInt32(order[i].totalValue)
                });
            }


            return lista;
        }
        public List<OrderModel> GetAllOrder()
        {
            var lista = new List<OrderModel>();

            var order = (from ord in _context.Orders
                         join customer in _context.Customers on ord.IdCustomer equals customer.Id
                         select new
                         {
                             IdOrder = ord.Number,
                             Customer = customer.Name,
                             totalValue = ord.TotalValue
                         }).ToList();

            for (int i = 0; i < order.Count(); i++)
            {
                lista.Add(new OrderModel
                {
                    IdPedido = order[i].IdOrder,
                    NameCustomer = order[i].Customer,
                    TotalValue = Convert.ToInt32(order[i].totalValue)
                });
            }


            return lista;
        }


        public List<OrderModel> GetOrderEntryDate(int id, string dataIni, string dataFim)
        {
            var dataIn = DateTime.ParseExact(dataIni, "yyyy-MM-dd", null);
            var dataFi = DateTime.ParseExact(dataFim, "yyyy-MM-dd", null);

            var lista = new List<OrderModel>();

            var order = (from ord in _context.Orders
                         join customer in _context.Customers on ord.IdCustomer equals customer.Id
                         where (customer.Id == id || id == 0) && ord.DeliveryDate >= dataIn
                         && ord.DeliveryDate <= dataFi
                         select new
                         {
                             IdOrder = ord.Number,
                             Customer = customer.Name,
                             totalValue = ord.TotalValue
                         }).ToList();

            for (int i = 0; i < order.Count(); i++)
            {
                lista.Add(new OrderModel
                {
                    IdPedido = order[i].IdOrder,
                    NameCustomer = order[i].Customer,
                    TotalValue = Convert.ToInt32(order[i].totalValue)
                });
            }

            return lista;
        }

    }
}
