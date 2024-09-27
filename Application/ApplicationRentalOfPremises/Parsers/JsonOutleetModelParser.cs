using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace ApplicationRentalOfPremises.Parsers
{
    public class JsonOutleetModelParser : Infrastructure.OutleetModelParserInterface
    {
        internal class DataModelOutleet
        {
            public int ID { get; set; }
            public int Storey { get; set; }
            public int Area { get; set; }
            public short PresenceOfAirConditining { get; set; }
            public decimal RentalCostPerDay { get; set; }
            public double AllocatedPowerKilowatts { get; set; }
            public int NumberOfWindows { get; set; }
            public int InventoryNumber {  get; set; }
            internal DataModelOutleet(OutleetModel outlet)
            {
                this.ID =(int) outlet.ID;
                this.AllocatedPowerKilowatts = outlet.AllocatedPowerKilowatts;
                this.RentalCostPerDay = outlet.GetRentalCostPerDay();
                this.NumberOfWindows = outlet.NumberOfWindows;
                this.Area = outlet.Area;
                this.PresenceOfAirConditining = outlet.PresenceOfAirConditioning;
                this.Storey = outlet.GetStorey();
                this.InventoryNumber = outlet.GetInventoryNumber();

            }
            public DataModelOutleet()
            {

            }
        }
        public OutleetModel Parse(string content)
        {
            DataModelOutleet outlet = JsonSerializer.Deserialize<DataModelOutleet>(content);
            OutleetModel outletModel = new OutleetModel(outlet);
            //error.RunExceptionIFNotSUCCESS();
            return outletModel;
            //OutletModel outletModel=new OutletModel()
        }
        public string ConvertTo(OutleetModel model)
        {
            DataModelOutleet dataModelOutlet = new DataModelOutleet(model);
            return JsonSerializer.Serialize(dataModelOutlet);
        }
    }
}
