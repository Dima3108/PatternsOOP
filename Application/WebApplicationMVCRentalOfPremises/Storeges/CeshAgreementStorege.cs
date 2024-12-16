using WebApplicationMVCRentalOfPremises.Models;
using WebApplicationMVCRentalOfPremises.Infrastructure;
namespace WebApplicationMVCRentalOfPremises.Storeges
{
    public class CeshAgreementStorege:AgreementStoregeInterface
    {
        private List<AgreementModel> _agreements;   
        public void AddAgreement(Models.AgreementModel model)
        {
            _agreements.Add(model);
        }
        public Models.AgreementModel GetModelById(int id) => _agreements.Find(t => t.ID == id);
    }
}
