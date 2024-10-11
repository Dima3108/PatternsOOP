using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Storeges.DB
{
    public class outleetmodel_cesh_adapter:OutleetStoregeIntrafce
        //:outleetmodel_rep_DB
    {
        private FileStorege _storegeAdapter;
        public outleetmodel_cesh_adapter(FileStorege storegeAdapter)
        {
            _storegeAdapter = storegeAdapter;
        }
        public  void AddModel(OutleetModel outleetModel)=>_storegeAdapter.AddModel(outleetModel);
        public  OutleetModel GetModelById(int id)=>_storegeAdapter.GetModelById(id);
        public void RemoveById(int id)=>_storegeAdapter.RemoveModelById(id);
        public int get_count()=>_storegeAdapter.get_count();
        public void UpdateById(OutleetModel outleetModel) => _storegeAdapter.UpdateModelById((int)outleetModel.ID, outleetModel);
        public  List<OutleetSmallModel> get_k_n_short_list(int k, int n)=>_storegeAdapter.get_k_n_short_list((int)k, (int)n);

    }
}
