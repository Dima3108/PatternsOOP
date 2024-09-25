using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static ApplicationRentalOfPremises.Parsers.JsonOutleetModelParser;

namespace ApplicationRentalOfPremises.Parsers
{
    public class TextOutleetModelParser:Infrastructure.OutleetModelParserInterface
    {
        public OutletModel Parse(string content)
        {
            DataModelOutlet outlet = new DataModelOutlet();
            string[] cont = content.Split("<");
            /*
             * data_ += $"{dataModelOutlet.ID}";
            data_ += $"<{dataModelOutlet.Storey}";
            data_ += $"<{dataModelOutlet.Area}";
            data_ += $"<{dataModelOutlet.PresenceOfAirConditining}";
            data_ += $"<{dataModelOutlet.RentalCostPerDay}";
            data_ += $"<{dataModelOutlet.AllocatedPowerKilowatts}";
            data_ += $"<{dataModelOutlet.NumberOfWindows}";
             */
            outlet.ID=int.Parse(cont[0]);
            outlet.Storey=int.Parse(cont[1]);
            outlet.Area=int.Parse(cont[2]);
            outlet.PresenceOfAirConditining=short.Parse(cont[3]);
            outlet.RentalCostPerDay = int.Parse(cont[4]);
            outlet.AllocatedPowerKilowatts=double.Parse(cont[5]);
            outlet.NumberOfWindows=int.Parse(cont[6]);
            OutletModel outletModel = new OutletModel(outlet);
            //error.RunExceptionIFNotSUCCESS();
            return outletModel;
            //OutletModel outletModel=new OutletModel()
        }
        public string ConvertTo(OutletModel model)
        {
            DataModelOutlet dataModelOutlet = new DataModelOutlet(model);
            string data_ = "";
            data_ += $"{dataModelOutlet.ID}";
            data_ += $"<{dataModelOutlet.Storey}";
            data_ += $"<{dataModelOutlet.Area}";
            data_ += $"<{dataModelOutlet.PresenceOfAirConditining}";
            data_ += $"<{dataModelOutlet.RentalCostPerDay}";
            data_ += $"<{dataModelOutlet.AllocatedPowerKilowatts}";
            data_ += $"<{dataModelOutlet.NumberOfWindows}";
            return data_ ;
           // return JsonSerializer.Serialize(dataModelOutlet);
        }
    }
}
