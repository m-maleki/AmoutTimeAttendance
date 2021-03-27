using System;
using System.Collections.Generic;
using System.Text;
using ATA.Application.Contracts.Staff;
using ATA.Application.Staff;
using ATA.Domain.StaffAgg;
using ATA.Infastructure.EFCore;
using ATA.Infastructure.EFCore.Repositories.Staff;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ATA.Infrastructure.Config
{
    public class BootStrapper
    {
        public static void Config(IServiceCollection services  , string connectionString)
        {
            services.AddTransient<IStaffApplication, StaffApplication>();
            services.AddTransient<IStaffRepository, StaffRepository>();

            services.AddDbContext<ATAContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
