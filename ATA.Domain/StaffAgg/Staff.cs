using System;
using System.Collections.Generic;
using System.Text;

namespace ATA.Domain.StaffAgg
{
    public class Staff
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public DateTime RegisterDate {  get; private set; }
        public bool IsDeleted { get; private set; }
        public Staff(string name , DateTime registerDate )
        {
            Name = name;
            RegisterDate = registerDate;
            IsDeleted = false;
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
