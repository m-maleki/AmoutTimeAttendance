using System;
using System.Collections.Generic;
using System.Text;
using ATA.Domain.AttendanceAgg;

namespace ATA.Domain.StaffAgg
{
    public class Staff
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public DateTime RegisterDate {  get; private set; }
        public bool IsDeleted { get; private set; }

        public ICollection<Attendance> Attendances { get;  set; }

        public Staff(string name , DateTime registerDate )
        {
            Name = name;
            RegisterDate = registerDate;
            IsDeleted = false;
            Attendances = new List<Attendance>();
        }

        public void Remove()
        {
            IsDeleted = true;

        } public void Active()
        {
            IsDeleted = false;

        }

        public void Edit(string name , DateTime registereDate)
        {
            Name = name;
            RegisterDate = registereDate;
        }


    }
}
