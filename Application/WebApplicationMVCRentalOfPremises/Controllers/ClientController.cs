using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMVCRentalOfPremises.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
