using ApplicationRentalOfPremises.Storeges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.SeedData
{
    public class SeedData
    {
        public static StoregeOutleetModelInterface storegeOutleets { get;private set; } = null;  
        public static void SetStoregeOutleetModel(StoregeOutleetModelInterface storegeOutleetModelInterface)
        {
            if (storegeOutleets == null)
            {
                storegeOutleets = storegeOutleetModelInterface;
            }
        }
    }
}
