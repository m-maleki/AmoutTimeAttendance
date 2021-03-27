using System;
using System.Collections.Generic;
using System.Text;

namespace ATA.Domain.StaffAgg
{
    public interface IStaffRepository
    {
        List<Staff> GetAll();
        void Create(Staff entity);
    }
}
