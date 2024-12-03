using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationRentalOfPremises.Converters
{
    public abstract class ConverterListSmallOutlettModelToTable
    {
       /*protected System.Data.DataTable ConvertListSmallOutleetToTable(List<OutleetSmallModel> obj)
        {
            System.Data.DataTable table = new System.Data.DataTable();
           // var obj = get_k_n_short_list(n, k);
            table.Columns.Add(nameof(OutleetSmallModel.ID));
            table.Columns.Add(nameof(OutleetSmallModel.InventoryNumber));
            table.Columns.Add(nameof(OutleetSmallModel.RentalCostPerDay));
            table.Columns.Add(nameof(OutleetSmallModel.Storey));
            foreach (var item in obj)
            {
                table.Rows.Add(new object[] { item.ID, item.InventoryNumber, item.RentalCostPerDay, item.Storey });
            }
            return table;
        }*/
        public abstract List<OutleetSmallModel> get_k_n_short_list(int k, int n);
        /// <summary>
        /// Шаблонный метод преобразования коллекции в таблицу
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public System.Data.DataTable get_k_n_short_table(int k, int n) {
            System.Data.DataTable table = new System.Data.DataTable();
            var obj = get_k_n_short_list(k,n);
            table.BeginInit();
            //table.Columns.Add(nameof(OutleetSmallModel.ID));
            table.Columns.Add("Порядковый номер");
            table.Columns.Add(nameof(OutleetSmallModel.InventoryNumber));
            table.Columns.Add(nameof(OutleetSmallModel.RentalCostPerDay));
            table.Columns.Add(nameof(OutleetSmallModel.Storey));
            int off = 0;
            foreach (var item in obj)
            {
#if DEBUG
                Console.WriteLine(item.ToString());
#endif
                table.Rows.Add(new object[] { /*item.ID,*/k+off++, item.InventoryNumber, item.RentalCostPerDay, item.Storey });
            }
#if DEBUG
            Console.WriteLine(obj.Count);
            Console.WriteLine(table.Rows.Count);
#endif
            table.EndInit();
            return table;
        }
    }
}
