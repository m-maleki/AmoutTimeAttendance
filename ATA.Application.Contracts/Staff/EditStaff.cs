using System;
using System.Collections.Generic;
using System.Text;

namespace ATA.Application.Contracts.Staff
{
    public class EditStaff 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }

    }
}
