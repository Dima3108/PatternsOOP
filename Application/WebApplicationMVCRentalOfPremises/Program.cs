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
            if (SeedData.OutleetStoregeIntrafce.get_count() <= 0)
            {
                OutleetModel[] modesl = new OutleetModel[]
                {
                    new OutleetModel(1,1,1,23.3m,3,2,5),
                    new OutleetModel(2,2,0,1.2m,2,1,6),
                    new OutleetModel(5,1,0,4.5m,4,3,3),
                    new OutleetModel(4,3,1,12m,4,0,11)
                };
                foreach (var mode in modesl)
                {
                    SeedData.OutleetStoregeIntrafce.AddModel(mode);
                }
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
