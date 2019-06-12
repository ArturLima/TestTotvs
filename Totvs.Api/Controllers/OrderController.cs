using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Totvs.Domain;
using Totvs.Infra.Repository.Interfaces;

namespace Totvs.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        private readonly IUnityOfWork _uow;

        public OrderController(IUnityOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public IHttpActionResult SaveOrder([FromBody] Order order)
        {
            _uow.Orders.Save(order);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAllOrder()
        {
            return Ok(_uow.Orders.GetAllOrder());
        }

        [HttpGet]
        public IHttpActionResult getOrder(int id)
        {
            return Ok(_uow.Orders.GetOrder(id));
        }


        [HttpGet]
        public IHttpActionResult getOrderEntryDate(int id, string startDate, string endDate)
        {
            return Ok(_uow.Orders.GetOrderEntryDate(id, startDate, endDate));
        }

    }
}
