using WebApplicationMVCRentalOfPremises.Models;

namespace WebApplicationMVCRentalOfPremises.Infrastructure
{
    public interface OutleetStoregeIntrafce
    {
        void AddModel(OutleetModel outleetModel);
        OutleetModel GetModelById(int id);
        OutleetModel GetModelByInventoryNumber(int inventoryNumber);
        void RemoveById(int id);
        void UpdateById(OutleetModel outleetModel);
        List<OutleetSmallModel> get_k_n_short_list(int k, int n);
        int get_count();
        List<OutleetSmallModel> get_short_models_by_ids(List<AgreementModel> ids);

    }
}
