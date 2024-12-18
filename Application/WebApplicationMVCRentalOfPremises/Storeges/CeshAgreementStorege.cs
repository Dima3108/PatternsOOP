using WebApplicationMVCRentalOfPremises.Models;
using WebApplicationMVCRentalOfPremises.Infrastructure;
namespace WebApplicationMVCRentalOfPremises.Storeges
{
    public class CeshAgreementStorege:AgreementStoregeInterface
    {
        private List<AgreementModel> _agreements;   
        public CeshAgreementStorege()
        {
            _agreements = new List<AgreementModel>();
        }
        public void AddAgreement(Models.AgreementModel model)
        {
            _agreements.Add(model);
        }
        public Models.AgreementModel GetModelById(int id) => _agreements.Find(t => t.ID == id);
        public List<Models.AgreementModel> get_agreement_by_client_id(int client_id)=>_agreements.FindAll(t=>t.CLIENT_ID == client_id);
        public List<Models.AgreementModel> get_areement_by_outlet_id(int outlet_id)=>_agreements.FindAll(t=>t.OUTLEET_ID == outlet_id); 


    }
}
