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
        public static AgreementStoregeInterface AgreementStoregeInterface { get; private set; } = null;
        public static void SetAgreementStoregeInterface(AgreementStoregeInterface agreementStoregeInterface)
        {
            if(AgreementStoregeInterface is null)
            {
                AgreementStoregeInterface=agreementStoregeInterface;
            }
        }
        public static ClientStoregeInterface ClientStoregeInterface { get; private set; } = null;
        public static void SetClientStoregeInterface(ClientStoregeInterface clientStoregeInterface)
        {
            if(ClientStoregeInterface is null)
            {
                ClientStoregeInterface=clientStoregeInterface;
            }
        }
    }
}
