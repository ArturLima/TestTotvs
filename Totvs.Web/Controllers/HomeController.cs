using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Totvs.Domain;
using Totvs.Infra.Repository.Interfaces;

namespace Totvs.Web.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var path = ConfigurationManager.AppSettings["UrlDesenvolvimento"];
            var client = new RestClient(path);
            var request = new RestRequest("/Customer/GetAllCustomer", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = client.Execute<List<Customer>>(request);
            var CustomerList = new List<Customer>();

            content.Data.ForEach(c => CustomerList.Add(c));

            var MultiCustomers = new MultiSelectList(CustomerList, "Id", "Name");
            ViewBag.customers = MultiCustomers;


            var client2 = new RestClient(path);
            var requestProd = new RestRequest("/Product/getAllProduct", Method.GET);
            IRestResponse response2 = client2.Execute(requestProd);
            var content2 = client2.Execute<List<Product>>(requestProd);

            var ProductList = new List<Product>();

            content2.Data.ForEach(prod => ProductList.Add(prod));
            
            var MultiProducts = new MultiSelectList(ProductList, "ProductId", "ProductName");

            ViewBag.products = MultiProducts;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}