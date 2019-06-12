using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Totvs.Infra.Repository.Interfaces;

namespace Totvs.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        private readonly IUnityOfWork _uow;

        public ProductController(IUnityOfWork uow)
        {
            _uow = uow;

        }

        [HttpGet]
        public IHttpActionResult getProduct(int id)
        {
            var Product = _uow.Products.GetProduct(id);

            return Ok(Product);
        }

        [HttpGet]
        public IHttpActionResult getAllProduct()
        {
            var Products = _uow.Products.GetAllProduct();

            return Ok(Products);
        }
    }
}
