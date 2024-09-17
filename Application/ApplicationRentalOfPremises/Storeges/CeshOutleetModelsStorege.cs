using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Storeges
{
    public class CeshOutleetModelsStorege:StoregeOutleetModelInterface
    {
        private List<OutletModel>models=new List<OutletModel>();
        public CeshOutleetModelsStorege()
        {

        }
        public void AddModel(OutletModel model)=>models.Add(model);
        public List<OutletModel> GetAllModels() => models;
    }
}
