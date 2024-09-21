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
            OutletModel[] outleets = new OutletModel[3];
            OutletModelErrorStatus errorStatus = new OutletModelErrorStatus();
            outleets[0]= new OutletModel(0, 1, 12, 1, 6,3.5,2, out errorStatus);
            errorStatus.RunExceptionIFNotSUCCESS();
            outleets[1]=new OutletModel(2,3, 12, 0,5,5,7, out errorStatus);
            errorStatus.RunExceptionIFNotSUCCESS();
            outleets[2]=new OutletModel(3,4,5,1,11,0.3,0,out  errorStatus);
            errorStatus.RunExceptionIFNotSUCCESS();
            SeedData.SeedData.SetStoregeOutleetModel(new CeshOutleetModelsStorege());
            foreach (var model in outleets)
            {
                SeedData.SeedData.storegeOutleets.AddModel(model);
            }
        }
    }
}
