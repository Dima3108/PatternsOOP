using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationRentalOfPremises.Models;
namespace WindowsFormsMVC.Realizations
{
    public class SmallOutleetEnumerator:IEnumerator<OutleetSmallModel>
    {
        private Patterns.StorageIteratorInterface iteratorInterface;
        public SmallOutleetEnumerator(Patterns.StorageIteratorInterface iteratorInterface)
        {
            this.iteratorInterface = iteratorInterface;
        }
        public void Dispose()
        {
        }
        public void Reset()=> iteratorInterface.Reset();    
        public bool MoveNext() => this.iteratorInterface.IsNext();
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public OutleetSmallModel Current
        {
            get
            {
                try
                {
                    
                    return this.iteratorInterface.Next();
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

    }
}
