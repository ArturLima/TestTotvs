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
    public class ProductController : Controller
    {
       public JsonResult getProduct(int id)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var path = ConfigurationManager.AppSettings["UrlDesenvolvimento"];
            var client = new RestClient(path);
            var request = new RestRequest("/Product/getProduct/{id}", Method.GET);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = client.Execute<Product>(request);
            return Json(response.Data, JsonRequestBehavior.AllowGet);
        }
    }
}