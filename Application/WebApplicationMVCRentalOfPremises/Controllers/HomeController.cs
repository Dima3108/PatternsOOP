using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
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
            ViewData["preds"]=new List<int>();  
            var models = storegeIntrafce.get_k_n_short_list(0, 5);
#if DEBUG
            
#endif
            return View((object)models);
        }
        [HttpPost]
        public IActionResult Next(int pos
            //,List<int>preds
            )
        {
            // preds.Add(pos);
            List<int> preds = new List<int>();
            if (HttpContext.Session.Keys.Contains("preds"))
            {
 preds=( JsonSerializer.Deserialize<int[]>(HttpContext.Session.GetString("preds"))).ToList();
            
            }
           preds.Add(pos);
            HttpContext.Session.SetString("preds",JsonSerializer.Serialize(preds.ToArray()));
            ViewData["offset"] = pos + 5;
            Console.WriteLine((int)ViewData["offset"]);
           // ViewData["preds"]=preds;
            var models = storegeIntrafce.get_k_n_short_list((int)ViewData["offset"], 5);

            return View("Index",(object)models);
        }
        [HttpPost]
        public IActionResult Pred()
        {
			//List<int> preds = (JsonSerializer.Deserialize<int[]>(HttpContext.Session.GetString("preds"))).ToList();
			List<int> preds = new List<int>();
			if (HttpContext.Session.Keys.Contains("preds"))
			{
				preds = (JsonSerializer.Deserialize<int[]>(HttpContext.Session.GetString("preds"))).ToList();

			}
            //preds.Add(pos);

            int pos = 0;
            if (preds.Count > 0)
            {
pos=preds[preds.Count - 1];
            preds.RemoveAt(preds.Count - 1);
            }
            
	        HttpContext.Session.SetString("preds", JsonSerializer.Serialize(preds.ToArray()));
            ViewData["offset"] = pos;
          //  ViewData["preds"] = preds;
            var models = storegeIntrafce.get_k_n_short_list((int)ViewData["offset"], 5);

            return View("Index", (object)models);
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
