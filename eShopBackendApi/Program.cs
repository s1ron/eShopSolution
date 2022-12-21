using eShopApplication.Catalog.Products;
using eShopData.EF;
using eShopUtilities.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace eShopBackendApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var Configuration = builder.Configuration;


            //--------------------------------------------------
    //ConfigureServices(builder.Services) => service
            services.AddDbContext<EShopDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(SystemConstants.MainConnectionString)));

            //Declare DI
            services.AddTransient<IPublicProductService, PublicProductService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger eShop Solution", Version = "v1" });
            });


            services.AddControllersWithViews();
    //End ConfigureServices
            //-----------------------------------------------------


            //Configure(app, builder.Environment) => app
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger eShopSolution V1");
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}