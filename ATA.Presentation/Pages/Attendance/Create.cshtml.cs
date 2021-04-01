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
            string temp2 = "";
            int lenth = date.Length;

            if (date[1].ToString() == "/")
            {
                temp = "0" + date;
            }
            if (date[4].ToString() == "/")
            {
                temp = date.Substring(0, 2) + "/0" + date.Substring(3, 1) + date.Substring(4, lenth - 4);
            }

            if (date[1].ToString() == "/" && date[3].ToString() == "/")
            {

                temp = "0" + date.Substring(0, 1) + "/0" + date.Substring(2, 1) + "/" + date.Substring(4, lenth - 4);

            }
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
