using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATA.Application.Contracts.Staff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATA.Presentation.Pages.Staff
{
    public class CreateModel : PageModel
    {
        private readonly IStaffApplication _staffApplication;

        public CreateModel(IStaffApplication staffApplication)
        {
            _staffApplication = staffApplication;
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost(CreateStaff command)
        {
            _staffApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
