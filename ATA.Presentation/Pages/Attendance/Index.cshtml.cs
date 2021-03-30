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
        public List<SelectListItem> stafss { get; set; }
        private readonly IAttendanceApplication _attendanceApplication;

        public IndexModel(IAttendanceApplication attendanceApplication)
        {
            _attendanceApplication = attendanceApplication;
            
            Year = PersianDateTime.Now.Year;
            Month = PersianDateTime.Now.Month;
        }

        public void OnGet(AttendanceViewModel command)
        {
        
            stafss = _attendanceApplication.GetList()
                    .Select(x => new SelectListItem(x.StaffName, x.StaffId.ToString())).ToList();

                Attendance = _attendanceApplication.GetList();
              
        }

        public void OnPostFilter(AttendanceViewModel command)
        {
            Year = Int32.Parse(command.Year);
            Month = Int32.Parse(command.Month);

            Attendance = _attendanceApplication.GetListBy(Year, Month, long.Parse(command.StaffName));

            stafss = _attendanceApplication.GetList()
                .Select(x => new SelectListItem(x.StaffName, x.StaffId.ToString())).ToList();
        }


    }
}
