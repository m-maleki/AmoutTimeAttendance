using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATA.Application.Contracts.Staff;
using ATA.Domain.StaffAgg;
using ATA.Infastructure.EFCore.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATA.Presentation.Pages.Attendance
{
    public class DeviceModel : PageModel
    {
        public List<StaffViewModel> StaffList { get; set; }

        public Domain.StaffAgg.Staff Staff;
        private IStaffRepository _staffRepository;

        private string username = "admin";
        string password = "0000";

        public DeviceModel(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }


        public List<Event> Events { get; set; }
        public List<Event> TempEvents { get; set; }
        private Config cng;
        public void OnGet()
        {
            int seqNumber = 0;
            Config config = new Config("http://93.118.109.62", 0, 100,
                1372, _staffRepository,username,password);

              seqNumber = config.SeqNumber;
              

            Events = config.GetEvents(0, 0);
            for (int i = 1; i <= seqNumber; i += 100)
            {
                Events.AddRange(config.GetEvents(i, 100));
            }

            Events= Events.OrderByDescending(x=>x.SeqNo).ToList();

            ViewData["ConnectionStatus"] = config.Message;
            seqNumber = 0;



        }
    }
}
