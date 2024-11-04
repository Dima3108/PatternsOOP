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

namespace WindowsFormsMVC.Controller
{
    public class MainController:Infrastructure.SmallOutleetControllerInterface
    {
        public void UpdateTableContent(DataGridView view)
        {
            var table = WindowsFormsMVC.Data.SeedData.outleetStoregeIntrafce.get_k_n_short_table(0, Data.SeedData.outleetStoregeIntrafce.get_count());
            view.DataSource = table;
        }
    }
}
