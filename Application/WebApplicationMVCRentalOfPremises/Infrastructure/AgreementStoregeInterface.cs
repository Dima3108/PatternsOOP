namespace WebApplicationMVCRentalOfPremises.Infrastructure
{
    public interface AgreementStoregeInterface
    {
        void AddAgreement(Models.AgreementModel model);
        Models.AgreementModel GetModelById(int id);
        List<Models.AgreementModel> get_agreement_by_client_id(int client_id);  
        List<Models.AgreementModel> get_areement_by_outlet_id(int outlet_id);

    }
}
