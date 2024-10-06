using ApplicationRentalOfPremises.Models;
using ApplicationRentalOfPremises.SeedData;
using ApplicationRentalOfPremises.Storeges;
using System;
using MySqlConnector;
namespace ApplicationRentalOfPremises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OutleetModel[] outleets = new OutleetModel[3];
            OutletModelErrorStatus errorStatus = new OutletModelErrorStatus();
            outleets[0]= new OutleetModel( 1, 12, 1, 6,3.5,2,5,1);
            //errorStatus.RunExceptionIFNotSUCCESS();
            outleets[1]=new OutleetModel(3, 12, 0,5,5,7,4,2);
            //errorStatus.RunExceptionIFNotSUCCESS();
            outleets[2]=new OutleetModel(4,5,1,11,0.3,0,11,3);
            //errorStatus.RunExceptionIFNotSUCCESS();
            //SeedData.SeedData.SetStoregeOutleetModel(new CeshOutleetModelsStorege());
            /*foreach (var model in outleets)
            {
                SeedData.SeedData.storegeOutleets.AddModel(model);
            }*/
            Storeges.Reps.outleetmodel_fasade_rep_json outleetmodel_Fasade_Rep_Json = new Storeges.Reps.outleetmodel_fasade_rep_json("content.json");
            if (outleetmodel_Fasade_Rep_Json.get_count() <= 0)
            {
                foreach (var model in outleets)
                    outleetmodel_Fasade_Rep_Json.AddModel(model);
            }
            else
            {
                var objects=outleetmodel_Fasade_Rep_Json.GetAllModels();
                foreach(var obj in objects)
                    Console.WriteLine(obj.ToString());
            }
            Storeges.Reps.outleetmodel_fasade_rep_yaml outleetmodel_Fasade_Rep_Yaml = new Storeges.Reps.outleetmodel_fasade_rep_yaml("content.yaml");
            if (outleetmodel_Fasade_Rep_Yaml.get_count() <= 0)
            {
                foreach (var model in outleets)
                    outleetmodel_Fasade_Rep_Yaml.AddModel(model);
            }
            else
            {
                var objects = outleetmodel_Fasade_Rep_Yaml.GetAllModels();
                foreach (var obj in objects)
                    Console.WriteLine(obj.ToString());
            }
#if true
using var connection = new MySqlConnection("Server=localhost;User ID=dbuser;Password=d23ttFF8k;Database=myapps");
connection.Open();
            SeedData.SeedData.SetSqlConnection(connection);
            var mydbs=new Storeges.DB.outleetmodel_mysql_db(connection);
            if (mydbs.get_count() <= 0)
            {
                foreach (var el in outleets)
                {

                    mydbs.AddModel(el);
                    Console.WriteLine("@");
                }
            }
            var mod = mydbs.get_k_n_short_list(0,mydbs.get_count());
            Console.WriteLine();
            Console.WriteLine(mydbs.get_count());
            Console.WriteLine();
            foreach(var m in mod)
            {
                Console.WriteLine(m.ToString());
            }

#endif
        }
    }
}
