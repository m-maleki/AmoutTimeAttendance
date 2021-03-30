using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATA.Application.Contracts.Attendance;
using ATA.Domain.AttendanceAgg;
using Microsoft.EntityFrameworkCore;

namespace ATA.Infastructure.EFCore.Repositories.Attendance
{
    
    public class AttendanceRepository:IAttendanceRepository
    {
        private readonly ATAContext _context;

        public AttendanceRepository(ATAContext context)
        {
            _context = context;
        }

        public List<AttendanceViewModel> GetList()
        {
            return _context.Attendances.Include(x => x.Staff).Select(x => new AttendanceViewModel
            {
                Id=x.Id,
                StaffName = x.Staff.Name,
                StaffId = x.StaffId,
                EntranceTime = x.EntranceTime,
                LeaveTime = x.LeaveTime,
                IsDelete = x.IsDelete,
                EntranceDate = x.EntranceDate,
            }).ToList();
        }

        public List<AttendanceViewModel> GetListBy(int year, int month, long staffid)
        {
            return _context.Attendances.Where(x=>x.EntranceDate.Year==year && x.EntranceDate.Month==month && x.Staff.Id  == staffid)
                .Select(x => new AttendanceViewModel
            {
                Id = x.Id,
                StaffName = x.Staff.Name,
                EntranceTime = x.EntranceTime,
                LeaveTime = x.LeaveTime,
                IsDelete = x.IsDelete,
                StaffId = x.StaffId,
                EntranceDate = x.EntranceDate,
            }).ToList();
        }
    }
    
}
