using System;
using System.Collections.Generic;
using System.Text;
using ATA.Application.Contracts.Attendance;
using ATA.Domain.AttendanceAgg;

namespace ATA.Application.Attendance
{
    public class AttendanceApplication: IAttendanceApplication
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceApplication(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public List<AttendanceViewModel> GetList()
        {
           return _attendanceRepository.GetList();

        }

        public List<AttendanceViewModel> GetListBy(int year, int month, long staffid)
        {
            return _attendanceRepository.GetListBy(year, month, staffid);
        }

        public void Create(CreateAttendance command)
        {
            throw new NotImplementedException();
        }
    }
}
