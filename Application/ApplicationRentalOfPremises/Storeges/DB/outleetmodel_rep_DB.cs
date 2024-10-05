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
    public class outleetmodel_rep_DB
        //:FileStoregeAdapter
    {
        private MySqlConnection _connection;
        private string table_name;
        public outleetmodel_rep_DB(MySqlConnection connection,string table_name="outleet")//:base("",new Parsers.MySQLOutleetModelParserAdapter(connection,table_name))
        {
            _connection = connection;
            this.table_name = table_name;
            MySqlCommand command = new MySqlCommand();
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
        public  void AddModel(OutleetModel outleetModel)
        {
            var dataModelOutleet = outleetModel;
            MySqlCommand command = new MySqlCommand();
            command.Connection = _connection;
            command.CommandText = $"INSERT INTO {table_name}(Storey,Area,PresenceOfAirConditioning,RentalCostPerDay,AllocatedPowerKilowatts,InventoryNumber,NumberOfWindows) " +
                $"VALUES({dataModelOutleet.Storey},{dataModelOutleet.Area}," +
                $"{dataModelOutleet.PresenceOfAirConditioning},{dataModelOutleet.RentalCostPerDay}," +
                $"{dataModelOutleet.AllocatedPowerKilowatts},{dataModelOutleet.InventoryNumber},{dataModelOutleet.NumberOfWindows}" +
                $")";
            command.ExecuteNonQuery();
        }
        public OutleetModel GetModelById(int id)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = _connection;
            command.CommandText = $"SELECT * FROM {table_name} WHERE ID={id}";
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id_=reader.GetInt32(0);
                        int storey_ = (int)reader.GetUInt32(1);
                        int area_=(int)reader.GetInt32(2);
                        short PresenceOfAirConditioning_=(short)reader.GetUInt16(3);
                        decimal RentalCostPerDay_=reader.GetDecimal(4);
                        double AllocatedPowerKilowatts_=reader.GetDouble(5);
                        int NumberOfWindows_ = (int)reader.GetUInt32(6);
                        int InventoryNumber_=(int)reader.GetUInt32(7);
                        var model = new OutleetModel(storey_,area_,PresenceOfAirConditioning_,
                            RentalCostPerDay_,AllocatedPowerKilowatts_,NumberOfWindows_,InventoryNumber_
                            ,id_);
                        return model;

                    }
                }
            }
            return null;
        }
        public void RemoveById(int id)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = _connection;
            command.CommandText = $"DELETE FROM {table_name} WHERE id={id}"; 
            command.ExecuteNonQuery();
        }
        public int get_count()
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = _connection;
            command.CommandText = $"count(SELECT * FROM {table_name})";
            return (int)command.ExecuteScalar();
        }
        public void UpdateById(OutleetModel outleetModel)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = _connection;
            command.CommandText = $"UPDATE  {table_name} SET NumberOfWindows=,{outleetModel.NumberOfWindows}" +
                $",PresenceOfAirConditioning={outleetModel.PresenceOfAirConditioning},InventoryNumber={outleetModel.InventoryNumber}" +
                $",Area={outleetModel.Area},Storey={outleetModel.Storey}" +
                $",AllocatedPowerKilowatts={outleetModel.AllocatedPowerKilowatts}," +
                $"RentalCostPerDay={outleetModel.RentalCostPerDay}" +
                $" WHERE ID={outleetModel.ID}";
        }
        public List<OutleetSmallModel> get_k_n_short_list(int k,int n)
        {
            List<OutleetSmallModel> models = new List<OutleetSmallModel>();
            MySqlCommand command = new MySqlCommand();
            command.Connection = _connection;
            command.CommandText = $"SELECT ID,Storey,InventoryNumber,RentalCostPerDay FROM {table_name} LIMIT {n} OFFSET {k}";
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        OutleetSmallModel outleetSmallModel = new OutleetSmallModel();
                        outleetSmallModel.SetID((int)reader.GetInt32(0));
                        outleetSmallModel.SetStorey(reader.GetInt32(1));
                        outleetSmallModel.SetInventoryNumber(reader.GetInt32(2));
                        outleetSmallModel.SetRentalCostPerDay(reader.GetDecimal(3));
                        models.Add(outleetSmallModel);
                    }
                }
            }
            return models;
        }
    }
}
