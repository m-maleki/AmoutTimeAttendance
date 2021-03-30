using System;
using System.Collections.Generic;
using System.Text;

namespace ATA.Application.Contracts.Attendance
{
    public interface  IAttendanceApplication
    {
        List<AttendanceViewModel> GetList();
        List<AttendanceViewModel> GetListBy(int year , int month, long staffid);

    }
}
