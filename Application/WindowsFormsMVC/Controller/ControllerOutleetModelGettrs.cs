using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMVC.Controller
{
    public class ControllerOutleetModelGettrs
    {
        public ApplicationRentalOfPremises.Models.OutleetModel GetModelByInventoryNumber(object inventoryNumber)
        {
            if (inventoryNumber == null)
            {
                return null;
            }
            var id = inventoryNumber.ToString();
            try
            {
var model = Data.SeedData.outleetStoregeIntrafce.GetModelByInventoryNumber(int.Parse(id));
                return model;
            }
            catch
            {
                return null;
            }
        }
    }
}
