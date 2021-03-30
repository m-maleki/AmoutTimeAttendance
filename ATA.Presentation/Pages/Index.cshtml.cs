using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATA.Application.Contracts.Staff;
using PersianTools.Core;

namespace ATA.Presentation.Pages
{
    public class IndexModel : PageModel
    {
        public List<StaffViewModel> staff { get; set; }
        private readonly IStaffApplication _staffApplication;

        public IndexModel(IStaffApplication staffApplication)
        {
            _staffApplication = staffApplication;
        }

        public void OnGet()
        {
            var datePersian = PersianDateTime.Now;

            staff = _staffApplication.List();
           ViewData["StaffCount"] = staff.Count;

          
        }


        
     
    }
}
