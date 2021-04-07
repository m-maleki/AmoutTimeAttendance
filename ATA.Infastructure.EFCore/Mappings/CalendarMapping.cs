using System;
using System.Collections.Generic;
using System.Text;
using ATA.Domain.Calendar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATA.Infastructure.EFCore.Mappings
{
    public class CalendarMapping : IEntityTypeConfiguration<Calendar>
    {
        public void Configure(EntityTypeBuilder<Calendar> builder)
        {
            builder.ToTable("Calendar");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Year);
            builder.Property(x => x.Month);
            builder.Property(x => x.Day);
            builder.Property(x => x.IsHoliday);
            builder.Property(x => x.StaffId);
            builder.Property(x => x.EntranceDay);
            builder.Property(x => x.EntranceTime);
            builder.Property(x => x.LeaveTime);


        }
    }
}
