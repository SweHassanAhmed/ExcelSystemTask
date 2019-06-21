using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Data
{
    public class BaseEntity : DbContext
    {
        public BaseEntity(DbContextOptions<BaseEntity> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<User> Users { get; set; }

        public void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
