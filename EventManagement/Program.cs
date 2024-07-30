using Microsoft.EntityFrameworkCore;
using EventManagement.BLL;
using EventManagement.DAL;
using EventManagement.Models;

namespace EventManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Register DbContext with the connection string from appsettings.json
            builder.Services.AddDbContext<EventManagementDatabaseContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register DAL and BLL services
            builder.Services.AddTransient<EventTableDAL>();
            builder.Services.AddTransient<RegistrationTableDAL>();
            builder.Services.AddTransient<EventTableService>();
            builder.Services.AddTransient<RegistrationTableService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
