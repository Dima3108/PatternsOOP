using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ApplicationRentalOfPremises.Models;
using System.Collections;
using System.Windows.Forms;
using ApplicationRentalOfPremises.SeedData;
using System.Threading;

namespace WindowsFormsMVC.Controller
{
    public class MainController:Infrastructure.SmallOutleetControllerInterface
    {
        public void UpdateTableContent(DataGridView view)
        {
            var table = WindowsFormsMVC.Data.SeedData.outleetStoregeIntrafce.get_k_n_short_table(offset, count);
            view.DataSource = table;
        }
        private int count = 5;
        private int offset = 0;
        private List<int> pred_oosets=new List<int>();
        /// <summary>
        /// Увеличить смещение
        /// </summary>
        /// <param name="view"></param>
        public void IncreaseOffset(DataGridView view)
        {
            if (count == 5)
            {
 //pred_offset = offset;
 pred_oosets.Add(offset);
            offset = Math.Min(Data.SeedData.outleetStoregeIntrafce.get_count() - 1, offset + count);
            count = Math.Min(Data.SeedData.outleetStoregeIntrafce.get_count() - offset, 5);
            UpdateTableContent(view);
            }
           
        }
        public void ReduceOffset(DataGridView view)
        {
            //offset = Math.Max(0, offset - count);
            if (pred_oosets.Count>0)
            {
   offset = pred_oosets[pred_oosets.Count-1];
            pred_oosets.RemoveAt(pred_oosets.Count-1);
            count = 5;
            UpdateTableContent(view);
            }
         
        }
        //private AddOutleetModelForm modelForm;
        // private Thread backgroundThreadAddModel;
        public void AddModel(DataGridView view)
        {
          var  modelForm =Fabric.FabricCreaterForm.CreateForm(Fabric.FabricType.CreateOutleetModel)
                //new AddOutleetModelForm(null)
                ;
            
            //modelForm.Deactivate +=new EventHandler(()=>UpdateTableContent(view));
            Thread thread = new Thread(() => { modelForm.ShowDialog(); });
            thread.IsBackground = true;
            thread.Start();
            thread.Join();
            UpdateTableContent(view);
        }
        public void UpdateModel(DataGridView view)
        {
            var id = view.SelectedRows[0].Cells[0].Value;
            var model = WindowsFormsMVC.Data.SeedData.outleetStoregeIntrafce.GetModelByInventoryNumber(Convert.ToInt32(id));
            var modelForm = Fabric.FabricCreaterForm.CreateForm(Fabric.FabricType.UpdateOutleetModel,model)
                //new AddOutleetModelForm(null)
                ;

            //modelForm.Deactivate +=new EventHandler(()=>UpdateTableContent(view));
            Thread thread = new Thread(() => { modelForm.ShowDialog(); });
            thread.IsBackground = true;
            thread.Start();
            thread.Join();
            UpdateTableContent(view);
        }
        public void DeleteModel(DataGridView view)
        {
            var id = view.SelectedRows[0].Cells[0].Value;
            var model = WindowsFormsMVC.Data.SeedData.outleetStoregeIntrafce.GetModelByInventoryNumber(Convert.ToInt32(id));
            var modelForm = Fabric.FabricCreaterForm.CreateForm(Fabric.FabricType.DeleteOutleetModel, model);
            Thread thread = new Thread(() => { modelForm.ShowDialog(); });
            thread.IsBackground = true;
            thread.Start();
            thread.Join();
            UpdateTableContent(view);
        }
    }
}
