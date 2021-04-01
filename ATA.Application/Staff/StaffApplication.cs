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
                    IsDeleted = staff.IsDeleted,
                    });
            }

            return result;
        }

        public void Create(CreateStaff command)
        {
            var staff = new Domain.StaffAgg.Staff(command.Name,command.RegisterDate);
            _staffRepository.Create(staff);

        }

        public EditStaff Get(long id)
        {
            var staff = _staffRepository.Get(id);
            return new EditStaff()
            {
                 Id= staff.Id,
                 Name = staff.Name,
                 RegisterDate = staff.RegisterDate
            };
            
        }

        public string GetStaffNameBy(long id)
        {
            var staff = _staffRepository.Get(id);
            return staff.Name;

        }

        public void Remove(long id)
        {
           var staff= _staffRepository.Get(id);
           staff.Remove();
           _staffRepository.Save();
        }

        public void Active(long id)
        {
            var staff = _staffRepository.Get(id);
            staff.Active();
            _staffRepository.Save();
        }

        public void Edit(EditStaff command)
        {
            var staff = _staffRepository.Get(command.Id);
            staff.Edit(command.Name,command.RegisterDate );
            _staffRepository.Save();
        }

  
    }
}
