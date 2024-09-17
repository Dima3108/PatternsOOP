using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Storeges
{
    public interface StoregeOutleetModelInterface
    {
        void AddModel(OutletModel model);
        List<OutletModel> GetAllModels();
    }
}
