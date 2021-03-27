using System;
using System.Collections.Generic;
using System.Text;
using ATA.Application.Contracts.Staff;
using ATA.Domain.StaffAgg;

namespace ATA.Application.Staff
{
     public class StaffApplication : IStaffApplication
    {
        private readonly IStaffRepository _staffRepository;

        public StaffApplication(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public List<StaffViewModel> List()
        {
            var staffs = _staffRepository.GetAll();
            var result = new List<StaffViewModel>();
            foreach (var staff in staffs)
            {
                result.Add(new StaffViewModel
                    {
                    Id = staff.Id,
                    Name = staff.Name,
                    RegisterDate = staff.RegisterDate,
                    });
            }

            return result;
        }
         
  
    }
}
