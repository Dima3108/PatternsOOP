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
    //.WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
    .Build();
            DataModelOutleet outleet = deserializer.Deserialize<DataModelOutleet>(content);
            OutleetModel outletModel = new OutleetModel(outleet);
            //error.RunExceptionIFNotSUCCESS();
            return outletModel;
            //OutletModel outletModel=new OutletModel()
        }
        public OutleetModel[]ParseArray(string content)
        {
            var deserializer = new DeserializerBuilder()
    //.WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
    .Build();
            DataModelOutleet[] outleet = deserializer.Deserialize<DataModelOutleet[]>(content);
            OutleetModel[] outletModels = new OutleetModel[outleet.Length];
            Parallel.For(0, outletModels.Length, i =>
            {
                outletModels[i]=new OutleetModel(outleet[i]);
            });
            //error.RunExceptionIFNotSUCCESS();
            return outletModels;
            //OutletModel outletModel=new OutletModel()
        }
        public string ConvertTo(OutleetModel model)
        {
            DataModelOutleet dataModelOutlet = new DataModelOutleet(model);
            // return JsonSerializer.Serialize(dataModelOutlet);
            var serializer = new SerializerBuilder()
     //.WithNamingConvention(CamelCaseNamingConvention.Instance)
     .Build();
            var yaml = serializer.Serialize(dataModelOutlet);
            return yaml;
        }
        public string ConvertTo(OutleetModel[] models)
        {
            // DataModelOutleet dataModelOutlet = new DataModelOutleet(model);
            DataModelOutleet[]dOutleets=new DataModelOutleet[models.Length];
            Parallel.For(0, dOutleets.Length, i => dOutleets[i] = new DataModelOutleet(models[i]));
            // return JsonSerializer.Serialize(dataModelOutlet);
            var serializer = new SerializerBuilder()
     //.WithNamingConvention(CamelCaseNamingConvention.Instance)
     .Build();
            var yaml = serializer.Serialize(dOutleets);
            return yaml;
        }
    }
}
