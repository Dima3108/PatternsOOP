using ApplicationRentalOfPremises.Models;
using ApplicationRentalOfPremises.Storeges.Reps;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationRentalOfPremises.Parsers.JsonOutleetModelParser;

namespace ApplicationRentalOfPremises.Storeges.DB
{
    public class outleetmodel_adapter_rep_DB:FileStoregeAdapter
    {
        private MySqlConnection _connection;
        private string table_name;
        public outleetmodel_adapter_rep_DB(MySqlConnection connection,string table_name="DataModelOutleet"):base("",new Parsers.MySQLOutleetModelParserAdapter(connection,table_name))
        {

        }
        public new void AddModel(OutleetModel outleetModel)
        {
            DataModelOutleet dataModelOutleet = new DataModelOutleet(outleetModel);
            MySqlCommand command = new MySqlCommand();
            command.Connection = _connection;
            command.CommandText = $"INSERT INTO {table_name}(Storey,Area,PresenceOfAirConditining,) " +
                $"VALUES({dataModelOutleet.Storey},{dataModelOutleet.Area},{dataModelOutleet.PresenceOfAirConditining}" +
                $")";
        }
    }
}
