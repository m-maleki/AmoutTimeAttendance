using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATA.Domain.AttendanceAgg;
using ATA.Infastructure.EFCore.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATA.Presentation.Pages.Attendance
{
    
    public class CreateModel : PageModel
    {
        public string CovertDate(string date)
        {
            // date ="dd/mm/yyyy"
            string temp = "";
           
            int lenth = date.Length;

            return temp;
        }

        private readonly IAttendanceRepository _attendanceRepository;

        public CreateModel(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public void OnGet()
        {
            _attendanceRepository.Create(new Domain.AttendanceAgg.Attendance(1,DateTime.Now, DateTime.Now,DateTime.Now));
        }
    }
}
