using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Totvs.Domain;

namespace Totvs.Web.Controllers
{
    public class OrderController : Controller
    {
        
        // GET: Order
        public ActionResult Index()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var path = ConfigurationManager.AppSettings["UrlDesenvolvimento"];
            var client = new RestClient(path);
            var request = new RestRequest("/Customer/GetAllCustomer", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = client.Execute<List<Customer>>(request);
            var CustomerList = new List<Customer>();
            CustomerList.Add(new Customer
            {
                Id = 0,
                Name = "Todos"
            });

            content.Data.ForEach(c => CustomerList.Add(c));
           

            var MultiCustomers = new MultiSelectList(CustomerList, "Id", "Name");
            ViewBag.customers = MultiCustomers;

            return View();
        }

        [HttpPost]
        public ActionResult SaveOrder(Order order)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var path = ConfigurationManager.AppSettings["UrlDesenvolvimento"];
            var client = new RestClient(path);
            var request = new RestRequest("/Order/SaveOrder", Method.POST);
            request.AddJsonBody(order);
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            return View();
        }


        [HttpGet]
        public JsonResult GetAllOrder()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var path = ConfigurationManager.AppSettings["UrlDesenvolvimento"];
            var client = new RestClient(path);
            var request = new RestRequest("/Order/getAllOrder", Method.GET);
            var response = client.Execute<List<OrderModel>>(request);


            return Json(response.Data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetOrder(int id)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var path = ConfigurationManager.AppSettings["UrlDesenvolvimento"];
            var client = new RestClient(path);
            var request = new RestRequest("/Order/getOrder/{id}", Method.GET);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = client.Execute<List<OrderModel>>(request);


            return Json(response.Data, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult GetOrderEntryDate(int id, string startDate, string endDate)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var path = ConfigurationManager.AppSettings["UrlDesenvolvimento"];
            var client = new RestClient(path);
            var request = new RestRequest("/Order/getOrderEntryDate/{id}", Method.GET);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            request.AddParameter("startDate", startDate, ParameterType.QueryString);
            request.AddParameter("endDate", endDate, ParameterType.QueryString);
            

            var response = client.Execute<List<OrderModel>>(request);


            return Json(response.Data, JsonRequestBehavior.AllowGet);
        }


    }
}