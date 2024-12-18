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
                    _mod.ID =(int) models.Count;
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
            if (k >= models.Count)
                return modesl;
            int end = Math.Min(k+n, models.Count);  
            /*if(end>models.Count)
                end=modesl.Count;*/
            for(int offset = k; offset < end; offset++)
            {
                var sm=new OutleetSmallModel { ID = models[offset].ID, InventoryNumber = models[offset].InventoryNumber,
                    RentalCostPerDay = models[offset].RentalCostPerDay,Storey=models[offset].Storey,
                };
                modesl.Add(sm);
            }
                //modesl.Add(new OutleetSmallModel(models[offset].Storey, models[offset].InventoryNumber, models[offset].RentalCostPerDay, models[offset].ID));
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
        public List<OutleetSmallModel> get_short_models_by_ids(List<AgreementModel> ids)
        {
            List<OutleetSmallModel>modelss=new List<OutleetSmallModel>();
            foreach (var model in models)
            {
                bool s = false;
                foreach (var id in ids)
                {
                    if (id.OUTLEET_ID == model.ID)
                    {
                        s = true;
                        break;
                    }
                }
                if (s)
                {
                    modelss.Add(new OutleetSmallModel { ID=model.ID,Storey=model.Storey,InventoryNumber=model.InventoryNumber,RentalCostPerDay=model.RentalCostPerDay});
                }
            }
            return modelss;
        }
    }
}
