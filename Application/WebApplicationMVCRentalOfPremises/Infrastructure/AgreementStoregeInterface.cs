namespace WebApplicationMVCRentalOfPremises.Infrastructure
{
    public interface AgreementStoregeInterface
    {
        void AddAgreement(Models.AgreementModel model);
        Models.AgreementModel GetModelById(int id);

    }
}
