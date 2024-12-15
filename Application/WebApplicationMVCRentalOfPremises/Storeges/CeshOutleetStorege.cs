using WebApplicationMVCRentalOfPremises.Models;

namespace WebApplicationMVCRentalOfPremises.Storeges
{
    public class CeshOutleetStorege:Infrastructure.OutleetStoregeIntrafce
    {
        private List<OutleetModel>models= new List<OutleetModel>(); 
        public CeshOutleetStorege()
        {

        }
        public OutleetModel GetModelById(int id) => models.Find(t => t.ID == id);
        public OutleetModel GetModelByInventoryNumber(int inventoryNumber) => models.Find(t => t.InventoryNumber == inventoryNumber);
        public void AddModel(OutleetModel outleetModel)
        {
            //if (GetModelByInventoryNumber(outleetModel.InventoryNumber) )
            {
                lock (models)
                {
                    // outleetModel.ID=models.Count;
                    var _mod = outleetModel;
                    _mod.ID = models.Count;
                    Console.WriteLine($"add model:#\n{_mod.ToString()}\n");
                    models.Add(_mod);
                    Console.WriteLine($"saving model#{models[models.Count-1].ToString()}#");
                }
            }
        }
        public void RemoveById(int id)
        {
            var model = GetModelById(id);
            if(model is null == false)
            {
                models.Remove(model);
            }
        }
        public List<OutleetSmallModel> get_k_n_short_list(int k, int n)
        {
            var modesl=new List<OutleetSmallModel>();
            for(int offset=k;offset<Math.Min(n,models.Count-k);offset++)
                modesl.Add(models[offset]);
            return modesl;
        }
        public void UpdateById(OutleetModel outleetModel)
        {
            lock (models)
            {
                RemoveById((int)outleetModel.ID);
                models.Add(outleetModel);
            }
        }
        public int get_count() => models.Count;
    }
}
