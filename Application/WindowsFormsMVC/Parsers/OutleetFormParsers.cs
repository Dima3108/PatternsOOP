using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMVC.Parsers
{
    public class OutleetFormParsers
    {
        public static OutleetModel Parse(NumericUpDown numericArea, CheckBox checkBoxPresenceOfAirConditioning,
            NumericUpDown numericAllocatedPowerKilowatts, NumericUpDown numericNumberOfWindows,
            NumericUpDown numericStorey, NumericUpDown numericRentalCostPerDay, NumericUpDown numericInventoryNumber)
        {
            OutleetModel outleetModel = new OutleetModel();
            outleetModel.Area = (int)numericArea.Value;
            outleetModel.Storey = (int)numericStorey.Value;
            outleetModel.InventoryNumber = (int)numericInventoryNumber.Value;
            outleetModel.PresenceOfAirConditioning = (short)(checkBoxPresenceOfAirConditioning.Checked ? 1 : 0);
            outleetModel.AllocatedPowerKilowatts = (double)numericAllocatedPowerKilowatts.Value;
            outleetModel.RentalCostPerDay = numericRentalCostPerDay.Value;
            outleetModel.NumberOfWindows = (int)numericNumberOfWindows.Value;
            OutletModelErrorStatus error = new OutletModelErrorStatus(outleetModel);
            if (!error.GetIsSUCCES())
            {
                Shared.SharedFormErrorWriter.PrintErrors(error);
                return null;
            }
            return outleetModel;
        }
    }
}
