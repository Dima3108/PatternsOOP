using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsMVC.Infrastructure;

namespace WindowsFormsMVC.Fabric
{
    /// <summary>
    /// Без передачи данных
    /// </summary>
    public class FabricFormWithoutDataTransfer:AbstarctFabricCreater
    {
        public FabricFormWithoutDataTransfer(FabricType fabricType) : base(fabricType, null)
        {

        }
        public override System.Windows.Forms.Form CreateForm()
        {
            if (_type == FabricType.Main)
            {
                return new Form1();
            }
            else if(_type==FabricType.CreateOutleetModel)
            {
                return new AddOutleetModelForm(new Controller.AddOutleetModelController());
            }
            else
            {
                return null;
            }
        }
    }
}
