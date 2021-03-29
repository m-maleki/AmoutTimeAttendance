using System;
using System.Collections.Generic;
using System.Text;
using ATA.Domain.StaffAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATA.Infastructure.EFCore.Mappings
{
    public class StaffMapping:IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("Staff");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.RegisterDate);
            builder.Property(x => x.IsDeleted);
            }
    }
}
