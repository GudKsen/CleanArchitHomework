using CleanArchitHomework.Infrastructure.Data.Context;
using CleanArchitHomework.Presentation.MVC.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

//using CleanArchitHomework.Infrastructure.Data.Context;

namespace CleanArchitHomework.Presentation.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            var connectionStringDbTask = builder.Configuration.GetConnectionString("TaskConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<TaskDBContext>(options =>
                options.UseSqlServer(connectionStringDbTask));

            // Add services to the container.
            builder.Services.AddRazorPages();

            //builder.Services.AddDbContext<TaskDBContext>(options =>
            //    options.UseSqlServer(connectionStringDbTask));

            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddDbContext<TaskDBContext>( options =>
                options.UseSqlServer(connectionStringDbTask, b => b.MigrationsAssembly("CleanArchitHomework.Presentation.MVC")));
            

            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

           

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.MapControllerRoute(
            //   name: "default",
            //   pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();


        }
    }
}