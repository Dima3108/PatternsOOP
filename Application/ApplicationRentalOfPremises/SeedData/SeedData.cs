using ApplicationRentalOfPremises.Storeges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace ApplicationRentalOfPremises.SeedData
{
    public class SeedData
    {
        public static StoregeOutleetModelInterface storegeOutleets { get;private set; } = null;  
        public static void SetStoregeOutleetModel(StoregeOutleetModelInterface storegeOutleetModelInterface)
        {
            if (storegeOutleets == null)
            {
                storegeOutleets = storegeOutleetModelInterface;
            }
        }
        public static MySqlConnection sqlConnection { get; private set; } = null;
        public static void SetMySqlConnection(MySqlConnection sqlConnection_)
        {
            //Паттерн одиночка
            if (sqlConnection == null)
            {
                sqlConnection = sqlConnection_;
            }
        }
    }
}
