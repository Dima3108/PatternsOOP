using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//using ApplicationRentalOfPremises.Parsers;

namespace ApplicationRentalOfPremises.Parsers
{
    public class TextOutleetModelParser:Infrastructure.OutleetModelParserInterface
    {
 const char r_v = '<';
        public OutleetModel Parse(string content)
        {
           
            var outlet = new OutleetModel();
            string[] cont = content.Split(r_v);
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
            outlet.PresenceOfAirConditioning=short.Parse(cont[3]);
            outlet.RentalCostPerDay = int.Parse(cont[4]);
            outlet.AllocatedPowerKilowatts=double.Parse(cont[5]);
            outlet.NumberOfWindows=int.Parse(cont[6]);
            outlet.InventoryNumber=int.Parse(cont[7]);
           // OutleetModel outletModel = new OutleetModel(outlet);
            //error.RunExceptionIFNotSUCCESS();
            return outlet;
            //OutletModel outletModel=new OutletModel()
        }
        public OutleetModel[] ParseArray(string content)
        {
            string[]cont_=content.Split(r_v);
            const int attribute_count = 8;
            OutleetModel[] o = new OutleetModel[cont_.Length / attribute_count] ;
            for(int i = 0; i < o.Length; i++)
            {
                string v=cont_[i*attribute_count];
                if (v.Contains(r_v) == false)
                    v = "<" + v;
                for(int j = 1; j < attribute_count; j++)
                {
                    if (cont_[(i*attribute_count) + j].Contains("<") == false)
                    {
                        v += $"{r_v}" + cont_[(i * attribute_count) + j];
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
            var dataModelOutlet = model;
            string data_ = "";
            data_ += $"{dataModelOutlet.ID}";
            data_ += $"{r_v}{dataModelOutlet.Storey}";
            data_ += $"{r_v}{dataModelOutlet.Area}";
            data_ += $"{r_v}{dataModelOutlet.PresenceOfAirConditioning}";
            data_ += $"{r_v}{dataModelOutlet.RentalCostPerDay}";
            data_ += $"{r_v}{dataModelOutlet.AllocatedPowerKilowatts}";
            data_ += $"{r_v}{dataModelOutlet.NumberOfWindows}";
            data_ += $"{r_v}{dataModelOutlet.InventoryNumber}";
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
