using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Storeges.DB
{
    public class outleetmodel_mysql_db:outleetmodel_rep_DB
    {
        public outleetmodel_mysql_db(MySqlConnection mySqlConnection,string table_name= "outleet")
        {
            _connection = mySqlConnection;
            command = new MySqlCommand();
            this.table_name = table_name;
            command.Connection = _connection;
            command.CommandText = $"CREATE TABLE IF NOT EXISTS {table_name} (" +
                $"ID INT NOT NULL AUTO_INCREMENT," +
                $"storey INT UNSIGNED NOT NULL ," +
                $"area INT NOT NULL ," +
                $"PresenceOfAirConditioning TINYINT UNSIGNED NOT NULL ," +
                $"RentalCostPerDay DECIMAL UNSIGNED NOT NULL ," +
                $"AllocatedPowerKilowatts DOUBLE(9,5)  NOT NULL ," +
                $"NumberOfWindows INT UNSIGNED NOT NULL ," +
                $"InventoryNumber INT UNSIGNED NOT NULL ," +
                $"PRIMARY KEY (ID)," +
                $"UNIQUE INDEX InventoryNumber_UNIQUE(InventoryNumber ASC) VISIBLE)";
            command.ExecuteNonQuery();
        }
    }
}
