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
        public OutleetModel Parse(string content)
        {
            DataModelOutleet outlet = new DataModelOutleet();
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
            outlet.InventoryNumber=int.Parse(cont[7]);
            OutleetModel outletModel = new OutleetModel(outlet);
            //error.RunExceptionIFNotSUCCESS();
            return outletModel;
            //OutletModel outletModel=new OutletModel()
        }
        public OutleetModel[] ParseArray(string content)
        {
            string[]cont_=content.Split("<");
            const int attribute_count = 8;
            OutleetModel[] o = new OutleetModel[cont_.Length / attribute_count] ;
            for(int i = 0; i < o.Length; i++)
            {
                string v=cont_[i*attribute_count];
                if (v.Contains("<") == false)
                    v = "<" + v;
                for(int j = 1; j < attribute_count; j++)
                {
                    if (cont_[(i*attribute_count) + j].Contains("<") == false)
                    {
                        v += "<" + cont_[(i * attribute_count) + j];
                    }
                    else
                    {
                        v += cont_[(i * attribute_count) + j];
                    }
                }
                o[i] = Parse(v);
            }
            return o;
        }
        public string ConvertTo(OutleetModel model)
        {
            DataModelOutleet dataModelOutlet = new DataModelOutleet(model);
            string data_ = "";
            data_ += $"{dataModelOutlet.ID}";
            data_ += $"<{dataModelOutlet.Storey}";
            data_ += $"<{dataModelOutlet.Area}";
            data_ += $"<{dataModelOutlet.PresenceOfAirConditining}";
            data_ += $"<{dataModelOutlet.RentalCostPerDay}";
            data_ += $"<{dataModelOutlet.AllocatedPowerKilowatts}";
            data_ += $"<{dataModelOutlet.NumberOfWindows}";
            data_ += $"<{dataModelOutlet.InventoryNumber}";
            return data_ ;
           // return JsonSerializer.Serialize(dataModelOutlet);
        }
        public string ConvertTo(OutleetModel[] models)
        {
            string s = "";
            foreach (var mod in models)
            {
                s += ConvertTo(mod);
            }
            return s;
        }
    }
}
