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
            command.CommandText = $"CREATE TABLE IF NOT EXISTS{table_name}(" +
                $"ID INT GENERATED ALWAYS AS () VIRTUAL," +
                $"storey INT UNSIGNED NOT NULL COMMENT 'этаж'," +
                $"area INT NOT NULL COMMENT 'Площадь'," +
                $"PresenceOfAirConditioning TINYINT UNSIGNED NOT NULL COMMENT 'Наличие кондиционера'," +
                $"RentalCostPerDay DECIMAL UNSIGNED NOT NULL COMMENT 'Стоимость аренды в день'," +
                $"AllocatedPowerKilowatts DOUBLE UNSIGNED NOT NULL COMMENT 'Число выделенных киловат'," +
                $"NumberOfWindows INT UNSIGNED NOT NULL COMMENT 'Число окон'," +
                $"InventoryNumber INT UNSIGNED NOT NULL COMMENT 'Инвертарный номер'," +
                $"PRIMARY KEY (ID)," +
                $"UNIQUE INDEX InventoryNumber_UNIQUE(InventoryNumber ASC) VISIBLE)";
            command.ExecuteNonQuery();
        }
    }
}
