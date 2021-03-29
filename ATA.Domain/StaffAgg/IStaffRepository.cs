using System;
using System.Collections.Generic;
using System.Text;
using ATA.Application.Contracts.Staff;

namespace ATA.Domain.StaffAgg
{
    public interface IStaffRepository
    {
        List<Staff> GetAll();
        void Create(Staff entity);

        public Staff Get(long id);
        public void Save();
      

    }
}
