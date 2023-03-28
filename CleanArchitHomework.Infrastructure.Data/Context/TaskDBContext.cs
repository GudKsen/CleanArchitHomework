using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitHomework.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CleanArchitHomework.Infrastructure.Data.Context
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> dbContextOptions) : base(dbContextOptions) 
        {
        }
        public DbSet<TaskClass> Tasks { get; set; }
        public DbSet<PractiseTask> TasksPractice { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Resource> Resources { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PractiseTask>()
                .ToTable("TasksPractice");
        }
    }
}
