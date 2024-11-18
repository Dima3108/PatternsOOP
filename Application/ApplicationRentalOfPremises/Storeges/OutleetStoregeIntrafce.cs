using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Storeges
{
    public interface
        OutleetStoregeIntrafce
    {
        void AddModel(OutleetModel outleetModel);
        OutleetModel GetModelById(int id);
        OutleetModel GetModelByInventoryNumber(int inventoryNumber);
        void RemoveById(int id);
        void UpdateById(OutleetModel outleetModel);
        List<OutleetSmallModel> get_k_n_short_list(int k, int n);
        #region DataTableForMVC
        System.Data.DataTable get_k_n_short_table(int k,int n);
        #endregion
        int get_count();
    }
}
