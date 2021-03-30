using System;
using System.Collections.Generic;
using System.Text;

namespace ATA.Application.Contracts.Attendance
{
    public class AttendanceViewModel
    {
        public long Id { get; set; }
        public long StaffId { get; set; }
        public string StaffName { get; set; }
        public DateTime EntranceDate { get; set; }
        public bool IsDelete { get; set; }
        public DateTime EntranceTime { get;  set; }
        public DateTime LeaveTime { get;  set; }
        public string Year { get; set; }
        public string Month { get; set; }
    }
}
