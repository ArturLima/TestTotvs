using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Totvs.Infra.Repository.Interfaces;

namespace Totvs.Api.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly IUnityOfWork _uow;

        public CustomerController(IUnityOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet]
        public IHttpActionResult GetAllCustomer()
        {
            return Ok(_uow.Customers.GetAllCustomer());
        }
    }
}
