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
        internal class DataModelOutlet
        {
            public int ID { get; set; }
            public int Storey { get; set; }
            public int Area { get; set; }
            public short PresenceOfAirConditining { get; set; }
            public decimal RentalCostPerDay { get; set; }
            public double AllocatedPowerKilowatts { get; set; }
            public int NumberOfWindows { get; set; }
            internal DataModelOutlet(OutletModel outlet)
            {
                this.ID = outlet.ID;
                this.AllocatedPowerKilowatts = outlet.AllocatedPowerKilowatts;
                this.RentalCostPerDay = outlet.RentalCostPerDay;
                this.NumberOfWindows = outlet.NumberOfWindows;
                this.Area = outlet.Area;
                this.PresenceOfAirConditining = outlet.PresenceOfAirConditioning;
                this.Storey = outlet.Storey;

            }
            public DataModelOutlet()
            {

            }
        }
        public OutletModel Parse(string content)
        {
            DataModelOutlet outlet = JsonSerializer.Deserialize<DataModelOutlet>(content);
            OutletModel outletModel = new OutletModel(outlet, out OutletModelErrorStatus error);
            error.RunExceptionIFNotSUCCESS();
            return outletModel;
            //OutletModel outletModel=new OutletModel()
        }
        public string ConvertTo(OutletModel model)
        {
            DataModelOutlet dataModelOutlet = new DataModelOutlet(model);
            return JsonSerializer.Serialize(dataModelOutlet);
        }
    }
}
