using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsMVC.Controller;

namespace WindowsFormsMVC
{
    public partial class AddOutleetModelForm :Form
        //Infrastructure.FabricForm
    {
        internal AddOutleetModelForm(Infrastructure.ModelCreaterInterface modelCreaterInterface)//:base(modelCreaterInterface) 
        {
            InitializeComponent();
            modelController = modelCreaterInterface;
            modelController.SetForm(this);
            if (modelCreaterInterface is UpdateOutleetModelController)
            {
               var e=(UpdateOutleetModelController)(modelCreaterInterface);
                //e.SetForm(this);
                e.SetModel(numericArea, checkBoxPresenceOfAirConditioning, numericAllocatedPowerKilowatts, numericNumberOfWindows,
                    numericStorey, numericRentalCostPerDay, numericInventoryNumber);
            }
        }
        private Infrastructure.ModelCreaterInterface modelController;
        //=new AddOutleetModelController();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            modelController.CreateModel(numericArea, checkBoxPresenceOfAirConditioning, numericAllocatedPowerKilowatts, numericNumberOfWindows,
                numericStorey, numericRentalCostPerDay, numericInventoryNumber);
        }
    }
}
