using ApplicationRentalOfPremises.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationRentalOfPremises.Parsers.JsonOutleetModelParser;

namespace ApplicationRentalOfPremises.Parsers
{
    public class MySQLOutleetModelParserAdapter:Infrastructure.OutleetModelParserInterface
    {
        private MySqlConnection _connection;
        private string _table_name;
        public MySQLOutleetModelParserAdapter(MySqlConnection mySqlConnection,string table_name)
        {
            _connection = mySqlConnection;
            _table_name = table_name;
        }
        public OutleetModel[] ParseArray(string s)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = _connection;
            command.CommandText = $"SELECT ID,Storey," +
                $"Area,PresenceOfAirConditining," +
                $"RentalCostPerDay,NumberOfWindows," +
                $"AllocatedPowerKilowatts,InventoryNumber FROM {_table_name}";
            var d = new List<OutleetModel>();
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataModelOutleet dataModelOutleet=new DataModelOutleet();
                        dataModelOutleet.ID= reader.GetInt32(0);
                        dataModelOutleet.Storey = reader.GetInt32(1);
                        dataModelOutleet.Area = reader.GetInt32(2);
                        dataModelOutleet.PresenceOfAirConditining = reader.GetInt16(3);
                        dataModelOutleet.RentalCostPerDay=reader.GetDecimal(4); 
                        dataModelOutleet.NumberOfWindows=reader.GetInt32(5);
                        dataModelOutleet.AllocatedPowerKilowatts=reader.GetDouble(6);
                        dataModelOutleet.InventoryNumber=reader.GetInt32(7);
                    }
                }
            }
            return d.ToArray();
        }
        public string ConvertTo(OutleetModel[] models)
        {
            throw new NotImplementedException();    
        }
    }
}
