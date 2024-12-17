using Microsoft.AspNetCore.Mvc;
using WebApplicationMVCRentalOfPremises.Data;
using WebApplicationMVCRentalOfPremises.Infrastructure;
using WebApplicationMVCRentalOfPremises.Models;

namespace WebApplicationMVCRentalOfPremises.Controllers
{
    public class ClientController : Controller
    {
        private ClientStoregeInterface _storege = SeedData.ClientStoregeInterface;
        [HttpGet]
        public IActionResult Index()
        {
            var clients=_storege.get_k_n_list_client(0,_storege.get_clients_count());
            return View(clients.ToArray());
        }
        [HttpGet]
        public IActionResult ClientPage(int client_id)
        {
            (List<Models.CustomerDetailsModel>?,List<OutleetModel>?) details_=(_storege.get_details_by_client_id(client_id),null);

            return View((object)(details_));
        }
    }
}
