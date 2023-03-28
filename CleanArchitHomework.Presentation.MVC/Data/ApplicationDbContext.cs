using CleanArchitHomework.Domain.Models;
using CleanArchitHomework.Presentation.MVC.Models.UserModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitHomework.Presentation.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserModel>()
                .Property(x => x.Name)
                .HasMaxLength(128);

            builder.Entity<UserModel>()
                .Property(x => x.Birthdate);
                
        }
        public DbSet<UserModel> Users { get; set; }
    }
}
