using System;
using System.Collections.Generic;
using System.Text;
using ATA.Domain.AttendanceAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATA.Infastructure.EFCore.Mappings
{
    public class AttendanceMapping :IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable("Attendance");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StaffId);
            builder.Property(x => x.EntranceTime);
            builder.Property(x => x.LeaveTime);
            builder.Property(x => x.IsDelete);
            builder.Property(x => x.EntranceDate);

            builder.HasOne(x => x.Staff).WithMany(x => x.Attendances).HasForeignKey(x => x.StaffId);
        }
    }
}
