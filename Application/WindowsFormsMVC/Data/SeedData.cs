using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationRentalOfPremises;
using ApplicationRentalOfPremises.Storeges;
namespace WindowsFormsMVC.Data
{
    public static class SeedData
    {
        public static OutleetStoregeIntrafce outleetStoregeIntrafce { get; private set; } = null;
        public static void SetOutleetStoregeIntrafce(OutleetStoregeIntrafce outleetStoregeIntrafce_)
        {
            if (outleetStoregeIntrafce != null)
            {
                outleetStoregeIntrafce = outleetStoregeIntrafce_;
            }
        }
    }
}
