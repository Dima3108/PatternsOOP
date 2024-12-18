using Microsoft.AspNetCore.Mvc;
using WebApplicationMVCRentalOfPremises.Data;

namespace WebApplicationMVCRentalOfPremises.Controllers
{
    public class AgreementController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyStartDate(DateTime date,int outleet_id)
        {
            bool s = true;
            foreach (var item in SeedData.AgreementStoregeInterface.get_areement_by_outlet_id(outleet_id))
            {
                if (item.DateStart <= date && item.DateStop >= date)
                {
                    s = false;
                }
            }
            return Json(s);
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyStopDate(DateTime date, int outleet_id)
        {
            bool s = true;
            foreach (var item in SeedData.AgreementStoregeInterface.get_areement_by_outlet_id(outleet_id))
            {
                if (item.DateStart <= date && item.DateStop >= date)
                {
                    s = false;
                }
            }
            return Json(s);
        }

    }
}
