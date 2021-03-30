using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATA.Application.Contracts.Staff;
using ATA.Domain.StaffAgg;


namespace ATA.Infastructure.EFCore.Repositories.Staff
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ATAContext _context;

        public StaffRepository(ATAContext context)
        {
            _context = context;
        }

        public List<Domain.StaffAgg.Staff> GetAll()
        {
            return _context.Staff.ToList();
        }

        public void Create(Domain.StaffAgg.Staff entity)
        {
            _context.Staff.Add(entity);
            _context.SaveChanges();
        }

       

        public Domain.StaffAgg.Staff Get(long id)
        {
             return _context.Staff.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

      
    }
}
