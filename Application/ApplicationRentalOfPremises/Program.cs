using ApplicationRentalOfPremises.Models;
using ApplicationRentalOfPremises.SeedData;
using ApplicationRentalOfPremises.Storeges;
using System;

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
            SeedData.SeedData.SetStoregeOutleetModel(new CeshOutleetModelsStorege());
            foreach (var model in outleets)
            {
                SeedData.SeedData.storegeOutleets.AddModel(model);
            }
        }
    }
}
