using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Storeges.DB
{
    public class outleetmodel_cesh_rep_db_adapter:outleetmodel_rep_DB
    {
        private FileStoregeAdapter _storegeAdapter;
        public outleetmodel_cesh_rep_db_adapter(FileStoregeAdapter storegeAdapter)
        {
            _storegeAdapter = storegeAdapter;
        }
        public new void AddModel(OutleetModel outleetModel)=>_storegeAdapter.AddModel(outleetModel);
        public new OutleetModel GetModelById(int id)=>_storegeAdapter.GetModelById(id);
        public new void RemoveById(int id)=>_storegeAdapter.RemoveModelById(id);
        public new int get_count()=>_storegeAdapter.get_count();
        public new void UpdateById(OutleetModel outleetModel) => _storegeAdapter.UpdateModelById((int)outleetModel.ID, outleetModel);
        public new List<OutleetSmallModel> get_k_n_short_list(int k, int n)=>_storegeAdapter.get_k_n_short_list((int)k, (int)n);

    }
}
