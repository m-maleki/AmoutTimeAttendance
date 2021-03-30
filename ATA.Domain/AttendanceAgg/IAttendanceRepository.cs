using System;
using System.Collections.Generic;
using System.Text;
using ATA.Application.Contracts.Attendance;

namespace ATA.Domain.AttendanceAgg
{
    public interface IAttendanceRepository
    {
        List<AttendanceViewModel> GetList();
        List<AttendanceViewModel> GetListBy(int year,int month, long staffid);
    }
}
