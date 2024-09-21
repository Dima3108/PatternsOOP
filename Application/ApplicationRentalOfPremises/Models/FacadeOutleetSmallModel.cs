using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Models
{
    public class FacadeOutleetSmallModel
    {
        private OutletModel _outletModel;
        public FacadeOutleetSmallModel(OutletModel outletModel)
        {
            _outletModel = outletModel;
        }
        public int GetStorey()=>_outletModel.Storey;
        public int GetArea() => _outletModel.Area;
        public int RentalCostPerDay()=>_outletModel.RentalCostPerDay;
        public int GetNumberOfWindows()=>_outletModel.NumberOfWindows;
    }
}
