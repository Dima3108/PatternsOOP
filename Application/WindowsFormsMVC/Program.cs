using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ApplicationRentalOfPremises;
namespace WindowsFormsMVC
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
//#if DEBUG
            Data.SeedData.SetOutleetStoregeIntrafce(ApplicationRentalOfPremises.Program.CreateStorege());
#if DEBUG
            Console.WriteLine(Data.SeedData.outleetStoregeIntrafce.get_count());
#endif
            //#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
