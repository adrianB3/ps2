using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Contexts
{
    public class AppDbContext: DbContext
    {
        public DbSet<Data> Data { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Data>().ToTable("Data");
            builder.Entity<Data>().HasKey(p => p.Id);
            builder.Entity<Data>().Property(p => p.Id).IsRequired().HasDefaultValue(Guid.NewGuid());
            builder.Entity<Data>().Property(p => p.TimeStamp).IsRequired().HasDefaultValueSql("datetime('now')");

            builder.Entity<Data>().HasData(
                
                new Data {
                    Id = Guid.NewGuid(),
                    WaterLevelSensor1State = true,
                    WaterLevelSensor2State = true,
                    WaterLevelSensor3State = true,
                    WaterLevelSensor4State = true,
                    
                    Pump1State = true,
                    Pump2State = true,
                    Pump3State = false,
                    Pump4State = false
                }
            );
        }
    }
}