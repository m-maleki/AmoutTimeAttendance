using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ATA.Application.Contracts.Attendance;
using ATA.Application.Contracts.Staff;
using ATA.Domain.AttendanceAgg;
using ATA.Infastructure.EFCore.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Update.Internal;
using PersianTools.Core;

namespace ATA.Presentation.Pages.Attendance
{
    
    public class CreateModel : PageModel
    {
        public List<SelectListItem> Stafss { get; set; }
        private readonly IStaffApplication _staffApplication;

        public string CovertDate(string date)
        {
            // date ="dd/mm/yyyy"
            string temp = "";
           
            int lenth = date.Length;

            return temp;
        }

        private readonly IAttendanceRepository _attendanceRepository;

        public CreateModel(IAttendanceRepository attendanceRepository, IStaffApplication staffApplication)
        {
            _attendanceRepository = attendanceRepository;
            _staffApplication = staffApplication;
        }

        public void OnGet()
        {
            Stafss = _staffApplication.List().Where(x => x.IsDeleted == false)
                .Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

          //  Attendance = _attendanceApplication.GetList();
            //_attendanceRepository.Create(new Domain.AttendanceAgg.Attendance(1,DateTime.Now, DateTime.Now,DateTime.Now));
        }

        public void OnPostFilter(AttendanceViewModel command)
        {
            var Edate = command.EntranceDate;

            PersianCalendar p = new PersianCalendar();
            DateTime x = p.ToDateTime(Edate.Year, Edate.Month, Edate.Day, Edate.Hour, Edate.Minute, Edate.Second, Edate.Millisecond);


            _attendanceRepository.Create(new Domain.AttendanceAgg.Attendance(int.Parse(command.StaffName),command.EntranceTime, command.LeaveTime,x));

        }

    }
}
