using WebApplicationMVCRentalOfPremises.Infrastructure;

namespace WebApplicationMVCRentalOfPremises.Data
{
    public class SeedData
    {
        public static OutleetStoregeIntrafce OutleetStoregeIntrafce { get; private set; } = null;    
        public static void SetOutleetStoregeIntrafce(OutleetStoregeIntrafce outleetStoregeIntrafce)
        {
            if(OutleetStoregeIntrafce is null)
            {
                OutleetStoregeIntrafce = outleetStoregeIntrafce;
            }
        }
    }
}
