using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMVC.Shared
{
    public class SharedFormErrorWriter
    {
        public static void PrintErrors(OutletModelErrorStatus outletModelError)
        {
            if (!outletModelError.GetIsSUCCES())
            {
                Task.Run(async delegate
                {
                    foreach (string val in outletModelError.GenerateErros())
                    {
                        await Task.Run(delegate
                        {
                            MessageBox.Show(val, "ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }).Wait();
            }
        }
    }
}
