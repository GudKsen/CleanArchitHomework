using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitHomework.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitHomework.Infrastructure.Data.Context
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> dbContextOptions) : base(dbContextOptions) 
        {
        }
        public DbSet<TaskClass> Tasks { get; set; }
    }
}
