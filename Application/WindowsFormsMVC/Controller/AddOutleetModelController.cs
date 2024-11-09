using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMVC.Controller
{
    public class AddOutleetModelController
    {
        public AddOutleetModelController() { }
        public void CreateModel(NumericUpDown numericArea,CheckBox checkBoxPresenceOfAirConditioning,
            NumericUpDown numericAllocatedPowerKilowatts,NumericUpDown numericNumberOfWindows,
            NumericUpDown numericStorey,NumericUpDown numericRentalCostPerDay,NumericUpDown numericInventoryNumber, AddOutleetModelForm form)
        {
            OutleetModel outleetModel = new OutleetModel(); 
            outleetModel.Area=(int)numericArea.Value;
            outleetModel.Storey=(int)numericStorey.Value;
            outleetModel.InventoryNumber=(int)numericInventoryNumber.Value;
            outleetModel.PresenceOfAirConditioning = (short)(checkBoxPresenceOfAirConditioning.Checked ? 1 : 0);
            outleetModel.AllocatedPowerKilowatts=(double)numericAllocatedPowerKilowatts.Value;
            outleetModel.RentalCostPerDay=numericRentalCostPerDay.Value;
            outleetModel.NumberOfWindows=(int)numericNumberOfWindows.Value;
            OutletModelErrorStatus outletModelError=new OutletModelErrorStatus(outleetModel);
            if (!outletModelError.GetIsSUCCES())
            {
                Task.Run(async delegate
                {
                    foreach (string val in outletModelError.GenerateErros())
                    {
                        await Task.Run(delegate
                        {
                            MessageBox.Show(val, "ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        });
                    }
                }).Wait();
            }
            else
            {
                Data.SeedData.outleetStoregeIntrafce.AddModel(outleetModel);
                form.Close();
            }
        }
    }
}
