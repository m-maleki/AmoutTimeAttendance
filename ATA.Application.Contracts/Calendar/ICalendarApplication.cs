using System;
using System.Collections.Generic;
using System.Text;

namespace ATA.Application.Contracts.Calendar
{
    public interface ICalendarApplication
    {
        List<CalendarViewModel> GetList();


    }
}
