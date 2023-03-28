using CleanArchitHomework.Application.Interfaces;
using CleanArchitHomework.Application.Services;
using CleanArchitHomework.Domain.Interfaces;
using CleanArchitHomework.Domain.Models;
using CleanArchitHomework.Infrastructure.Data.Context;
using CleanArchitHomework.Infrastructure.Data.Repository;
using CleanArchitHomework.Infrastructure.IoC;
using CleanArchitHomework.Presentation.MVC.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Server.IISIntegration;

using Microsoft.AspNetCore.Authentication;
using CleanArchitHomework.Presentation.MVC.Models.UserModel;


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

                //        builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                //.AddEntityFrameworkStores<ApplicationDbContext>();

            var connectionStringDbTask = builder.Configuration.GetConnectionString("TaskConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<TaskDBContext>(options =>
                options.UseSqlServer(connectionStringDbTask));

            builder.Services.AddAuthentication();
            builder.Services.AddRazorPages();
            builder.Services.AddAutoMapper(typeof(Program));
            //builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddIdentityCore<UserModel>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddSignInManager<SignInManager<UserModel>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            //builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme).AddCookie("Identity.Application");
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
        .AddIdentityCookies(o => { });
            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options => //CookieAuthenticationOptions
            //    {
            //        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Identity/Account/Login");
            //    });


            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Areas/Identity/Account/Login";
            });

            builder.Services.AddAuthorization();

            builder.Services.AddControllersWithViews();
            RegisterServices(builder.Services);

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.Run();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }
    }
}