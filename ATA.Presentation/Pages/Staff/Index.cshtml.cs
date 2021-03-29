using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATA.Application.Contracts.Staff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ATA.Presentation.Pages.Staff
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
           
            staff = _staffApplication.List();
            
        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            _staffApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public RedirectToPageResult OnPostActive(long id)
        {
            _staffApplication.Active(id);
            return RedirectToPage("./Index");
        }
    }
}
