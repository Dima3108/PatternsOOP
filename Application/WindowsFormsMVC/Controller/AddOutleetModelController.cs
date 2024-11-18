using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsMVC.Data;
using WindowsFormsMVC.Infrastructure;

namespace WindowsFormsMVC.Controller
{
    public class AddOutleetModelController:Infrastructure.SmallOutleetControllerInterface,Infrastructure.ModelCreaterInterface
    {
        //public AddOutleetModelController(AddOutleetModelForm form_) { form = form_; }
        public void SetForm(Form form)
        {
            this.form = form;
        }
        private Form form { get; set; }
        public void CreateModel(NumericUpDown numericArea,CheckBox checkBoxPresenceOfAirConditioning,
            NumericUpDown numericAllocatedPowerKilowatts,NumericUpDown numericNumberOfWindows,
            NumericUpDown numericStorey,NumericUpDown numericRentalCostPerDay,NumericUpDown numericInventoryNumber )
        {
            /*OutleetModel outleetModel = new OutleetModel(); 
            outleetModel.Area=(int)numericArea.Value;
            outleetModel.Storey=(int)numericStorey.Value;
            outleetModel.InventoryNumber=(int)numericInventoryNumber.Value;
            outleetModel.PresenceOfAirConditioning = (short)(checkBoxPresenceOfAirConditioning.Checked ? 1 : 0);
            outleetModel.AllocatedPowerKilowatts=(double)numericAllocatedPowerKilowatts.Value;
            outleetModel.RentalCostPerDay=numericRentalCostPerDay.Value;
            outleetModel.NumberOfWindows=(int)numericNumberOfWindows.Value;*/
            var outleetModel = Parsers.OutleetFormParsers.Parse(numericArea, checkBoxPresenceOfAirConditioning, numericAllocatedPowerKilowatts,
                numericNumberOfWindows, numericStorey, numericRentalCostPerDay, numericInventoryNumber);
            //OutletModelErrorStatus outletModelError=new OutletModelErrorStatus(outleetModel);
            /*if (!outletModelError.GetIsSUCCES())
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
            }*/
            //else
           
            if(!(outleetModel is null))
            {
                if(SeedData.outleetStoregeIntrafce.GetModelByInventoryNumber(outleetModel.InventoryNumber)is null)
                {
 Data.SeedData.outleetStoregeIntrafce.AddModel(outleetModel);
                form.Close();
                }
                else
                {
                    MessageBox.Show("Нарушена уникальность инвертарного номера");
                }
            }
        }
    }
}
