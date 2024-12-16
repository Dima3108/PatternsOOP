using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationMVCRentalOfPremises.Data;
using WebApplicationMVCRentalOfPremises.Infrastructure;
namespace WebApplicationMVCRentalOfPremises.Controllers
{
    public class OutleetController:Controller
    {
        private OutleetStoregeIntrafce storegeIntrafce = SeedData.OutleetStoregeIntrafce;
        [HttpGet]
        public IActionResult CreateProduct(int id)
        {
            var model=storegeIntrafce.GetModelById(id);
            if(model is null)
            {
                model=new Models.OutleetModel();
                model.ID = (int)-1;
            }
            Console.WriteLine($"model id:{model.ID}");
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateProduct([Bind("ID,Storey,Area,InventoryNumber,RentalCostPerDay,PresenceOfAirConditioning,AllocatedPowerKilowatts,NumberOfWindows")]Models.OutleetModel model)
        {
            if (model.ID == -1)
            {
                if (storegeIntrafce.GetModelByInventoryNumber(model.InventoryNumber) is null == false)
                    ModelState.AddModelError(nameof(model.InventoryNumber),"Нарушена уникальность инвертарного номера");
            }
            if (ModelState.IsValid)
            {
 Console.WriteLine("succes!");
                if (model.ID == -1)
                    storegeIntrafce.AddModel(model);
                else storegeIntrafce.UpdateById(model);
                return Redirect("/Home/Index");
            }
            
               
                return 
                    View( model);
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int id)
        {
            storegeIntrafce.RemoveById(id);
            return Redirect("/Home/Index");
        }
        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var mod=storegeIntrafce.GetModelById(id);
            return View(mod);
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyInventoryNumber(int InventoryNumber,int ?id)
        {
            Console.WriteLine("start validators!");
            if (( id == -1|| id is null)&&(storegeIntrafce.GetModelByInventoryNumber(InventoryNumber) is null==false))
            {
                Console.WriteLine("not valid!");
                return Json(false);
            }
            else return Json(true);
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyRentalCostPerDay(decimal RentalCostPerDay)
        {
            return Json(RentalCostPerDay > 0);
        }
    }
}
