using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Model.Custom;

namespace FrontEnd.Controllers
{
    public class ConsumableController : Controller
    {
        // GET: Consumable PRUEBA
        //public ActionResult Index()
        //{
        //    IEnumerable<ProductViewModel> product = null;

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://192.168.100.72:81/");
        //        var responseTask = client.GetAsync("WeatherForecast");
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readJob = result.Content.ReadAsAsync<IList<ProductViewModel>>();
        //            readJob.Wait();
        //            product = readJob.Result;
        //        }
        //        else
        //        {
        //            // Return the error code here
        //            product = Enumerable.Empty<ProductViewModel>();
        //            ModelState.AddModelError(string.Empty, "Server error occurred. Please contact admin for help");
        //        }
        //    }
        //    return View(product);
        //}
    }
}