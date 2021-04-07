    using System;
using System.Collections.Generic;
using System.Text;

namespace ATA.Domain.Calendar
{
    public class Calendar
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

        public Calendar(string year, string month, string day, long staffId, DateTime entranceDay, DateTime entranceTime, DateTime leaveTime)
        {
            Year = year;
            Month = month;
            Day = day;
            StaffId = staffId;
            EntranceDay = entranceDay;
            EntranceTime = entranceTime;
            LeaveTime = leaveTime;
            IsHoliday = false;
        }
    }
}
