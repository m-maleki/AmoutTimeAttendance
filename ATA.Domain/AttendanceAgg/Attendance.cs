using System;
using System.Collections.Generic;
using System.Text;
using ATA.Domain.StaffAgg;

namespace ATA.Domain.AttendanceAgg
{
    public class Attendance
    {
        public long Id { get;  set; }
        public long StaffId { get;  set; } 
        public bool IsDelete { get;  set; }
        public DateTime EntranceDate { get; set; }
        public DateTime EntranceTime { get;  set; }
        public DateTime LeaveTime { get;  set; }
        public Staff Staff { get;  set; }

        public Attendance(long staffId, DateTime entranceTime, DateTime leaveTime)
        {
            StaffId = staffId;
            EntranceTime = entranceTime;
            LeaveTime = leaveTime;
            IsDelete = false;
            EntranceDate=DateTime.Now;
        }
    }
}
