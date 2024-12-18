using Microsoft.AspNetCore.Mvc;
using WebApplicationMVCRentalOfPremises.Data;
using WebApplicationMVCRentalOfPremises.Infrastructure;
using WebApplicationMVCRentalOfPremises.Models;
using WebApplicationMVCRentalOfPremises.Storeges;

namespace WebApplicationMVCRentalOfPremises.Controllers
{
    public class ClientController : Controller
    {
        private ClientStoregeInterface _storege = SeedData.ClientStoregeInterface;
        private OutleetStoregeIntrafce _outleetStoreg=SeedData.OutleetStoregeIntrafce;
        private AgreementStoregeInterface _agreement=SeedData.AgreementStoregeInterface;
        [HttpGet]
        public IActionResult Index()
        {
            var clients=_storege.get_k_n_list_client(0,_storege.get_clients_count());
            return View(clients.ToArray());
        }
        [HttpGet]
        public IActionResult ClientPage(int client_id)
        {
            
            (List<Models.CustomerDetailsModel>,List<AgreementModel>,int) details_=(_storege.get_details_by_client_id(client_id),
                _agreement.get_agreement_by_client_id(client_id),client_id);

            return View((object)(details_));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectOutleet(int client_id)
        {
            (List<OutleetSmallModel>, int) res =
                (
                _outleetStoreg.get_k_n_short_list(0,_outleetStoreg.get_count()),
                client_id
                );
            return View((object)res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GoToArend(int client_id, int outleet_id)
        {
            var Agr=new Models.AgreementModel();
            Agr.CLIENT_ID=client_id;
            Agr.OUTLEET_ID=outleet_id;
            Agr.ID = -1;
            return View(Agr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FillInTheDetails([Bind("ID,OUTLEET_ID,CLIENT_ID,DateStart,DateStop")]AgreementModel model)
        {
            if (ModelState.IsValid)
            {
                _agreement.AddAgreement(model);
                Console.WriteLine("succes")
                    ;
                int client_id = model.CLIENT_ID;
				(List<Models.CustomerDetailsModel>, List<AgreementModel>, int) details_ = (_storege.get_details_by_client_id(client_id),
				_agreement.get_agreement_by_client_id(client_id), client_id);
				return View("ClientPage",(object)(details_));
               //return RedirectToAction($"/Client/ClientPage?client_id={model.CLIENT_ID}");
                //return ClientPage(model.CLIENT_ID);
            }
            else
            {
				return
				   View("GoToArend", model);
			}
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetDocumentPage(int client_id)
        {
            CustomerDetailsModel customerDetailsModel = new CustomerDetailsModel()
            {
                client_id = client_id,
            };
            return View(customerDetailsModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDocument(CustomerDetailsModel model)
        {
            _storege.AddClientDetails(model);
            int client_id=model.client_id;
            (List<Models.CustomerDetailsModel>, List<AgreementModel>, int) details_ = (_storege.get_details_by_client_id(client_id),
               _agreement.get_agreement_by_client_id(client_id), client_id);

            return View("ClientPage", (object)(details_));
        }
        [HttpGet]
        public IActionResult AddClientPage()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult AddClientModel(ClientsModel model)
        {
            _storege.AddClient(model);
            return Redirect("/Client/Index");
        }
	}
}
