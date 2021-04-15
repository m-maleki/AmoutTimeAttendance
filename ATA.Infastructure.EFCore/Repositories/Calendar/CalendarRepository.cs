using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATA.Application.Contracts.Calendar;
using ATA.Domain.AttendanceAgg;
using Microsoft.EntityFrameworkCore;

namespace ATA.Infastructure.EFCore.Repositories.Calendar
{
    public class CalendarRepository:ICalendarRepository
    {
        private readonly ATAContext _context;

        public CalendarRepository(ATAContext context)
        {
            _context = context;
        }


        public List<CalendarViewModel> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
