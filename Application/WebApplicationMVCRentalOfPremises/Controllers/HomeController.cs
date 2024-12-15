using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationMVCRentalOfPremises.Data;
using WebApplicationMVCRentalOfPremises.Infrastructure;
using WebApplicationMVCRentalOfPremises.Models;

namespace WebApplicationMVCRentalOfPremises.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private OutleetStoregeIntrafce storegeIntrafce = SeedData.OutleetStoregeIntrafce;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //HttpContext.Session.SetInt32("offset",0);
            ViewData["offset"] = 0;
            var models = storegeIntrafce.get_k_n_short_list(0, 5);
#if DEBUG
            
#endif
            return View((object)models);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        

    }
}
