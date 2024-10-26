using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationRentalOfPremises.Models;
namespace WindowsFormsMVC.Patterns
{
    public interface ObjectStorageObserverInterface:StorageIteratorInterface
    {
        void AddModel(OutleetSmallModel model);
        bool RemoveModel(OutleetSmallModel model);
        int get_count();
        bool Contains(OutleetSmallModel model);
        //IEnumerator<OutleetSmallModel> GetEnumerator();
        //IEnumerator<OutleetSmallModel> GetEnumerator();
    }
}
