using WebApplicationMVCRentalOfPremises.Data;
using WebApplicationMVCRentalOfPremises.Models;
using WebApplicationMVCRentalOfPremises.Storeges;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
namespace WebApplicationMVCRentalOfPremises
{
    public class Program
    {
        private static void InitData()
        {
            SeedData.SetOutleetStoregeIntrafce(new CeshOutleetStorege());
            SeedData.SetClientStoregeInterface(new CeshClientStorege());
            SeedData.SetAgreementStoregeInterface(new CeshAgreementStorege());
            if (SeedData.OutleetStoregeIntrafce.get_count() <= 0)
            {
                OutleetModel[] modesl = new OutleetModel[]
                {
                    new OutleetModel(1,1,1,23.3m,3,2,5),
                    new OutleetModel(2,2,0,1.2m,2,1,6),
                    new OutleetModel(5,1,0,4.5m,4,3,3),
                    new OutleetModel(4,3,1,12m,4,0,11),
                    new OutleetModel(5,5,0,10m,3,0,32),
                    new OutleetModel(7,2,0,2m,5,4,21)
                };
                foreach (var mode in modesl)
                {
                    SeedData.OutleetStoregeIntrafce.AddModel(mode);
                }
                ClientsModel[] clients = new ClientsModel[]
                {
                    new ClientsModel("name1","11111","person1"),
                    new ClientsModel("name2","23333","person2"),
                    new ClientsModel("name3","43222","person3")
                };
                foreach (var client in clients)
                {
                    SeedData.ClientStoregeInterface.AddClient(client);
                }
                CustomerDetailsModel[] details = new CustomerDetailsModel[]
                {
                    new CustomerDetailsModel(0,"passport","0991234"),
                    new CustomerDetailsModel(1,"passport","5566666"),
                    new CustomerDetailsModel(2,"ÈÍÍ","11111111")
                };
                foreach(var detail  in details)
                    SeedData.ClientStoregeInterface.AddClientDetails(detail);
                AgreementModel[] arModels = new AgreementModel[]
                {
                   new AgreementModel
                   {
                       CLIENT_ID=0,
                       OUTLEET_ID=0,
                       DateStart=new DateTime(new DateOnly(2011,3,22),new TimeOnly(12,34)),
                       DateStop=new DateTime(new DateOnly(2011,4,1),new TimeOnly(12,34))
                   }
                };
                foreach(var AR in  arModels)
                    SeedData.AgreementStoregeInterface.AddAgreement(AR);
            }
        }
        public static void Main(string[] args)
        {
            InitData();
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            builder.Services.AddControllers(options =>
            {
                options.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider());
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
