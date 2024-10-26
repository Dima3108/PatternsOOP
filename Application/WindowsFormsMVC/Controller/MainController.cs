using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ApplicationRentalOfPremises.Models;
using System.Collections;

namespace WindowsFormsMVC.Controller
{
    public class MainController:ICollection<OutleetSmallModel>
    {
        private Patterns.ObjectStorageObserverInterface observerInterface;
        //private Patterns.StorageIteratorInterface iteratorInterface;
        public bool Remove(OutleetSmallModel outleetSmallModel)
        {
            return observerInterface.RemoveModel(outleetSmallModel);
        }
        public bool IsReadOnly => false;
        public int Count=>observerInterface.get_count();
        public void Clear()
        {

        }
        public void CopyTo(OutleetSmallModel[]mod,int index)
        {

        }
        public MainController(Patterns.ObjectStorageObserverInterface objectStorageObserverInterface)
        {
            observerInterface = objectStorageObserverInterface;
        }
        public bool Contains(OutleetSmallModel outleetSmallModel) => observerInterface.Contains(outleetSmallModel);
        public void Add(OutleetSmallModel model)=>observerInterface.AddModel(model);
        /*
         * https://learn.microsoft.com/ru-ru/dotnet/api/system.collections.generic.icollection-1?view=net-8.0
         */
        public IEnumerator<OutleetSmallModel> GetEnumerator() => new Realizations.SmallOutleetEnumerator(observerInterface);
        IEnumerator IEnumerable.GetEnumerator()=>new Realizations.SmallOutleetEnumerator(observerInterface);
    }
}
