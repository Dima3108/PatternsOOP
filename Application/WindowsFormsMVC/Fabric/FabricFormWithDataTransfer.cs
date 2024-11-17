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
    ///Фабрика Формы с передачей данных
    /// </summary>
    public class FabricFormWithDataTransfer:AbstarctFabricCreater
    {
        public FabricFormWithDataTransfer(FabricType fabricType,object Object) : base(fabricType, Object)
        {

        }
        public override System.Windows.Forms.Form CreateForm()
        {
            if (_type == FabricType.UpdateOutleetModel)
            {
                //return new Form1(new Controller.MainController());
                Controller.UpdateOutleetModelController updateOutleetModelController = new Controller.UpdateOutleetModelController((OutleetModel)_object);
                
                return new AddOutleetModelForm(updateOutleetModelController);
            }
            else
            {
                return null;
            }
        }
    }
}
