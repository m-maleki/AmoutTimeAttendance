using System;
using System.Collections.Generic;
using System.Text;
using ATA.Domain.AttendanceAgg;
using ATA.Domain.StaffAgg;
using ATA.Infastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ATA.Infastructure.EFCore
{
    public class ATAContext : DbContext
    {
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public ATAContext(DbContextOptions<ATAContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StaffMapping());
            modelBuilder.ApplyConfiguration(new AttendanceMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
