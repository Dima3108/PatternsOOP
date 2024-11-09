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
            var table = WindowsFormsMVC.Data.SeedData.outleetStoregeIntrafce.get_k_n_short_table(0, Data.SeedData.outleetStoregeIntrafce.get_count());
            view.DataSource = table;
        }
        //private AddOutleetModelForm modelForm;
       // private Thread backgroundThreadAddModel;
        public void AddModel(DataGridView view)
        {
          var  modelForm = new AddOutleetModelForm();
            
            //modelForm.Deactivate +=new EventHandler(()=>UpdateTableContent(view));
            Thread thread = new Thread(() => { modelForm.ShowDialog(); });
            thread.IsBackground = true;
            thread.Start();
            thread.Join();
            UpdateTableContent(view);
        }
    }
}
