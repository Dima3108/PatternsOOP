using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Storeges
{
    public class outleet_storege_strategy:OutleetStoregeIntrafce
    {
        private OutleetStoregeIntrafce strategy;
        public outleet_storege_strategy(OutleetStoregeIntrafce strategy)=>this.strategy = strategy;
        public void AddModel(OutleetModel outleetModel)=>strategy.AddModel(outleetModel);
        public OutleetModel GetModelById(int id)=>strategy.GetModelById(id);
        public void RemoveById(int id)=>strategy.RemoveById(id);
        public void UpdateById(OutleetModel outleetModel)=>strategy.UpdateById(outleetModel);
        public List<OutleetSmallModel> get_k_n_short_list(int k, int n) => strategy.get_k_n_short_list(k, n);
        public int get_count()=>strategy.get_count();   
    }
}
