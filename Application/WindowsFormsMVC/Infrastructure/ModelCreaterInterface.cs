using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMVC.Infrastructure
{
    public interface ModelCreaterInterface:SmallOutleetControllerInterface
    {
        void SetForm(Form fabricForm);
        void CreateModel(NumericUpDown numericArea, CheckBox checkBoxPresenceOfAirConditioning,
           NumericUpDown numericAllocatedPowerKilowatts, NumericUpDown numericNumberOfWindows,
           NumericUpDown numericStorey, NumericUpDown numericRentalCostPerDay, NumericUpDown numericInventoryNumber);
    }
}
