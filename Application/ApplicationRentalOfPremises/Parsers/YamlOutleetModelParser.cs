using ApplicationRentalOfPremises.Infrastructure;
using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static ApplicationRentalOfPremises.Parsers.JsonOutleetModelParser;
using YamlDotNet;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Core;
namespace ApplicationRentalOfPremises.Parsers
{
    public class YamlOutleetModelParser : OutleetModelParserInterface
    {
        public OutleetModel Parse(string content)
        {
            //DataModelOutleet outlet = JsonSerializer.Deserialize<DataModelOutleet>(content);
            var deserializer = new DeserializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
    .Build();
            DataModelOutleet outleet = deserializer.Deserialize<DataModelOutleet>(content);
            OutleetModel outletModel = new OutleetModel(outleet);
            //error.RunExceptionIFNotSUCCESS();
            return outletModel;
            //OutletModel outletModel=new OutletModel()
        }
        public string ConvertTo(OutleetModel model)
        {
            DataModelOutleet dataModelOutlet = new DataModelOutleet(model);
            // return JsonSerializer.Serialize(dataModelOutlet);
            var serializer = new SerializerBuilder()
     .WithNamingConvention(CamelCaseNamingConvention.Instance)
     .Build();
            var yaml = serializer.Serialize(dataModelOutlet);
            return yaml;
        }
    }
}
