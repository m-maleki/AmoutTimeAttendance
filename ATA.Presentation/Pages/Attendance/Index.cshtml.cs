using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ATA.Application.Contracts.Attendance;
using ATA.Application.Contracts.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersianTools.Core;

namespace ATA.Presentation.Pages.Attendance
{
    public class IndexModel : PageModel
    {
        

        public int Year { get; set; }
        public int Month { get; set; }
        public List<AttendanceViewModel> Attendance { get; set; }
       
        public List<SelectListItem> Stafss { get; set; }

        private readonly IAttendanceApplication _attendanceApplication;
        private readonly IStaffApplication _staffApplication;

     
        public IndexModel(IAttendanceApplication attendanceApplication, IStaffApplication staffApplication)
        {
            _attendanceApplication = attendanceApplication;
            _staffApplication = staffApplication;

            Year = PersianDateTime.Now.Year;
            Month = PersianDateTime.Now.Month;
        }

        public void OnGet()
        {

            Stafss = _staffApplication.List().Where(x => x.IsDeleted == false)
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            Attendance = _attendanceApplication.GetList();
              
        }

        public void OnPostFilter(AttendanceViewModel command)
        {
            Year = Int32.Parse(command.Year);
            Month = Int32.Parse(command.Month);

            PersianCalendar p = new PersianCalendar();
            DateTime x = new DateTime(Year, Month, 15);
            int y, m, d;
            y = p.GetYear(x);
            m = p.GetMonth(x);
            d = p.GetDayOfMonth(x);

            //  Attendance = _attendanceApplication.GetListBy(Year, Month, long.Parse(command.StaffName));
            Attendance = _attendanceApplication.GetListBy(y, m, 1);

            Stafss = _staffApplication.List().Where(x => x.IsDeleted == false)
                .Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }


    }
}
