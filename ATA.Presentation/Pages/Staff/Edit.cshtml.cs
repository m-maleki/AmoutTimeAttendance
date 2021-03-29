using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATA.Application.Contracts.Staff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATA.Presentation.Pages.Staff
{
    public class EditModel : PageModel
    {
        private readonly IStaffApplication _staffApplication;
        [BindProperty] public EditStaff Staff { get; set; }
        public EditModel(IStaffApplication staffApplication)
        {
            _staffApplication = staffApplication;
        }

        public void OnGet(long id)
        {
            Staff = _staffApplication.Get(id);
        }

        public RedirectToPageResult OnPost()
        {
           _staffApplication.Edit(Staff);
           return RedirectToPage("./Index");
        }

     
    }
}
