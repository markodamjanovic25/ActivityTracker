using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary.DataAccess
{
    public class ActivityTrackerDbContext : DbContext
    {
        public ActivityTrackerDbContext(DbContextOptions<ActivityTrackerDbContext> options) 
            : base(options)
        {
        }

        public DbSet<ActivityOption> ActivityOptions { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ActivityOption>().HasData(
                new ActivityOption { Id = 1, Description = "just excercised!", Flag = "/img/ExcerciseFlag.svg" },
                new ActivityOption { Id = 2, Description = "just meditated!", Flag = "/img/MeditationFlag.svg" },
                new ActivityOption { Id = 3, Description = "just drank a glass of water!", Flag = "/img/WaterFlag.svg" },
                new ActivityOption { Id = 4, Description = "just read a chapter of a book!", Flag = "/img/BookFlag.svg" }
                );

            builder.Entity<Activity>()
                .Property(a => a.Time)
                .HasDefaultValueSql("getdate()");
        }
    }
}
