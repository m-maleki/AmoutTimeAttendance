using System;
using System.Collections.Generic;
using System.Text;

namespace ATA.Domain.StaffAgg
{
    public class Staff
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime RegisterDate {  get; private set; }

        public Staff(string name)
        {
            Name = name;
            RegisterDate=DateTime.Now;
        }
    }
}
