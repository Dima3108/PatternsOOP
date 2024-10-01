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
        private class YamlOutleetModelParserException : Exception
        {
            public YamlOutleetModelParserException():base("YamlOutleetModelParser exception")
            {

            }
        }
        public OutleetModel Parse(string content)
        {
            //DataModelOutleet outlet = JsonSerializer.Deserialize<DataModelOutleet>(content);
            var deserializer = new DeserializerBuilder()
    //.WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
    .Build();
           // DataModelOutleet outleet = deserializer.Deserialize<DataModelOutleet>(content);
            OutleetModel outletModel = deserializer.Deserialize<OutleetModel>(content);
            if(!OutleetModel.ValidOutleetModel(outletModel))
                throw new YamlOutleetModelParserException();
            //error.RunExceptionIFNotSUCCESS();
            return outletModel;
            //OutletModel outletModel=new OutletModel()
        }
        public OutleetModel[]ParseArray(string content)
        {
            var deserializer = new DeserializerBuilder()
    //.WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
    .Build();
            var outleet = deserializer.Deserialize<OutleetModel[]>(content);
            //OutleetModel[] outletModels = new OutleetModel[outleet.Length];
            bool[]s=new bool[outleet.Length];
            Parallel.For(0, outleet.Length, i =>
            {
                // outletModels[i]=new OutleetModel(outleet[i]);
                s[i] = OutleetModel.ValidOutleetModel(outleet[i]);
            });
            foreach(var e in s)if(!e)throw new YamlOutleetModelParserException();
            //error.RunExceptionIFNotSUCCESS();
            return outleet;
            //OutletModel outletModel=new OutletModel()
        }
        public string ConvertTo(OutleetModel model)
        {
            //DataModelOutleet dataModelOutlet = new DataModelOutleet(model);
            // return JsonSerializer.Serialize(dataModelOutlet);
            var serializer = new SerializerBuilder()
     //.WithNamingConvention(CamelCaseNamingConvention.Instance)
     .Build();
            var yaml = serializer.Serialize(model);
            return yaml;
        }
        public string ConvertTo(OutleetModel[] models)
        {
            // DataModelOutleet dataModelOutlet = new DataModelOutleet(model);
           // DataModelOutleet[]dOutleets=new DataModelOutleet[models.Length];
           // Parallel.For(0, dOutleets.Length, i => dOutleets[i] = new DataModelOutleet(models[i]));
            // return JsonSerializer.Serialize(dataModelOutlet);
            var serializer = new SerializerBuilder()
     //.WithNamingConvention(CamelCaseNamingConvention.Instance)
     .Build();
            var yaml = serializer.Serialize(models);
            return yaml;
        }
    }
}
