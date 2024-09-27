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
        private List<OutleetModel>models=new List<OutleetModel>();
        public CeshOutleetModelsStorege()
        {

        }
        public void AddModel(OutleetModel model)=>models.Add(model);
        public List<OutleetModel> GetAllModels() => models;
    }
}
