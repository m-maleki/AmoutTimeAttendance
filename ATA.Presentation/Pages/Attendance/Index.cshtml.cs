using System;
using System.Collections.Generic;
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
        public List<AttendanceViewModel> Attendance2 { get; set; }
       
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

            Stafss = _staffApplication.List()
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

            //Attendance2 = _attendanceApplication.GetList().Distinct().ToList();
            //Stafss = Attendance2.Select(x => new SelectListItem(x.StaffName, x.StaffId.ToString())).ToList();

            Attendance = _attendanceApplication.GetList();
              
        }

        public void OnPostFilter(AttendanceViewModel command)
        {
            Year = Int32.Parse(command.Year);
            Month = Int32.Parse(command.Month);

            Attendance = _attendanceApplication.GetListBy(Year, Month, long.Parse(command.StaffName));

            Stafss = _staffApplication.List()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }


    }
}
