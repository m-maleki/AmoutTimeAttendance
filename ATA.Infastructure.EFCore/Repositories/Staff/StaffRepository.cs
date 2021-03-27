using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATA.Domain.StaffAgg;

namespace ATA.Infastructure.EFCore.Repositories.Staff
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ATAContext _context;

        public List<Domain.StaffAgg.Staff> GetAll()
        {
            return _context.Staff.ToList();
        }

        public void Create(Domain.StaffAgg.Staff entity)
        {
            _context.Staff.Add(entity);
            _context.SaveChanges();
        }
    }
}
