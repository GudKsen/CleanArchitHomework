using CleanArchitHomework.Application.Interfaces;
using CleanArchitHomework.Application.Services;
using CleanArchitHomework.Domain.Interfaces;
using CleanArchitHomework.Infrastructure.Data.Context;
using CleanArchitHomework.Infrastructure.Data.Repository;
using CleanArchitHomework.Infrastructure.IoC;
using CleanArchitHomework.Presentation.MVC.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            //builder.Services.AddDbContext<TaskDBContext>( options =>
            //    options.UseSqlServer(connectionStringDbTask, b => b.MigrationsAssembly("CleanArchitHomework.Presentation.MVC")));

            //builder.Services.AddScoped<ITasksRepository, TaskRepository>();
            //builder.Services.AddScoped<ITasksService, TasksService>();

            builder.Services.AddControllersWithViews();
            RegisterServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //AppDomain currentDomain = AppDomain.CurrentDomain;
            //currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseRouting();

            app.UseAuthorization();

            //app.MapRazorPages();

            app.Run();


        }

        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }

        //static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        //{
        //    Exception e = (Exception)args.ExceptionObject;
        //    Console.WriteLine("MyHandler caught : " + e.Message);
        //    Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
        //}
    }
}