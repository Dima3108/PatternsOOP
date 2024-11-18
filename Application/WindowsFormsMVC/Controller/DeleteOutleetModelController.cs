using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsMVC.Data;

namespace WindowsFormsMVC.Controller
{
    public class DeleteOutleetModelController:Infrastructure.SmallOutleetControllerInterface
    {
        private OutleetSmallModel smallModel;
        public DeleteOutleetModelController(OutleetSmallModel smallModel)
        {
            this.smallModel = smallModel;
            
        }
        public void SetModel(Label labelID,Label labelInventoryNumber,Label labelStorey)
        {
            labelID.Text = ((int)(smallModel.ID.Value)).ToString();
            labelInventoryNumber.Text=smallModel.InventoryNumber.ToString();
            labelStorey.Text= smallModel.Storey.ToString();
        }
        public void DeleteModel(Form form)
        {
            SeedData.outleetStoregeIntrafce.RemoveById((int)smallModel.ID);
            form.Close();
        }
    }
}
