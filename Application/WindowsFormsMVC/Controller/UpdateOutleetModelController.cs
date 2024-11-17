using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsMVC.Infrastructure;

namespace WindowsFormsMVC.Controller
{
    public class UpdateOutleetModelController:Infrastructure.SmallOutleetControllerInterface, Infrastructure.ModelCreaterInterface
    {

        /*public UpdateOutleetModelController(AddOutleetModelForm addOutleetModelController)
        {
            form = addOutleetModelController;
        }*/
        public UpdateOutleetModelController(OutleetModel model) { this.model = model; }
        public void SetForm(Form form)
        {
            this.form = form;
        }
        private Form form { get; set; }
        private OutleetModel model { get;  }
        private int ModelID { get =>(int) model.ID; }  
        //private AddOutleetModelForm form {  get; set; }
        public void SetModel(NumericUpDown numericArea, CheckBox checkBoxPresenceOfAirConditioning,
            NumericUpDown numericAllocatedPowerKilowatts, NumericUpDown numericNumberOfWindows,
            NumericUpDown numericStorey, NumericUpDown numericRentalCostPerDay, NumericUpDown numericInventoryNumber)
        {
           // ModelID = (int)model.ID;
            numericArea.Value = model.Area;
            numericAllocatedPowerKilowatts.Value =(decimal) model.AllocatedPowerKilowatts;
            numericInventoryNumber.Value =(decimal) model.InventoryNumber;
            numericNumberOfWindows.Value =(decimal) model.NumberOfWindows;
            numericRentalCostPerDay.Value=model.RentalCostPerDay;
            numericStorey.Value=model.Storey;
            checkBoxPresenceOfAirConditioning.Checked = model.PresenceOfAirConditioning == 1;
        }
        public void UpdateModel(NumericUpDown numericArea, CheckBox checkBoxPresenceOfAirConditioning,
            NumericUpDown numericAllocatedPowerKilowatts, NumericUpDown numericNumberOfWindows,
            NumericUpDown numericStorey, NumericUpDown numericRentalCostPerDay, NumericUpDown numericInventoryNumber)
        {
            var outleetModel = Parsers.OutleetFormParsers.Parse(numericArea, checkBoxPresenceOfAirConditioning, numericAllocatedPowerKilowatts,
                numericNumberOfWindows, numericStorey, numericRentalCostPerDay, numericInventoryNumber);
            if (!(outleetModel is null))
            {
                //Data.SeedData.outleetStoregeIntrafce.AddModel(outleetModel);
                outleetModel.SetID(ModelID);
                Data.SeedData.outleetStoregeIntrafce.UpdateById(outleetModel);
                form.Close();
            }
        }
        public void CreateModel(NumericUpDown numericArea, CheckBox checkBoxPresenceOfAirConditioning,
            NumericUpDown numericAllocatedPowerKilowatts, NumericUpDown numericNumberOfWindows,
            NumericUpDown numericStorey, NumericUpDown numericRentalCostPerDay, NumericUpDown numericInventoryNumber) => UpdateModel(numericArea, checkBoxPresenceOfAirConditioning,
                numericAllocatedPowerKilowatts, numericNumberOfWindows, numericStorey, numericRentalCostPerDay, numericInventoryNumber);
    }
}
