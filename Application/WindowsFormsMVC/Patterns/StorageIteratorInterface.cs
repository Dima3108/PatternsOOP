using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationRentalOfPremises.Models;
namespace WindowsFormsMVC.Patterns
{
    public interface StorageIteratorInterface //: IEnumerator<OutleetSmallModel>
    {
        OutleetSmallModel Next();
        bool IsNext();
        void Reset();
    } 
}
