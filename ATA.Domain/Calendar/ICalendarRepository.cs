using System;
using System.Collections.Generic;
using System.Text;
using ATA.Application.Contracts.Calendar;

namespace ATA.Domain.AttendanceAgg
{
    public interface ICalendarRepository
    {
        List<CalendarViewModel> GetList();
    }
}
