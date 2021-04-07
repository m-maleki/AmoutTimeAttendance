using System;
using System.Collections.Generic;
using System.Text;

namespace ATA.Application.Contracts.Calendar
{
    public class CalendarViewModel
    {
        public long Id { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public bool IsHoliday { get; set; }
        public long StaffId { get; set; }
        public DateTime EntranceDay { get; set; }
        public DateTime EntranceTime { get; set; }
        public DateTime LeaveTime { get; set; }
    }
}
