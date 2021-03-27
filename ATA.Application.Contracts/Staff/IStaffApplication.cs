using System;
using System.Collections.Generic;
using System.Text;

namespace ATA.Application.Contracts.Staff
{
    public interface IStaffApplication
    {
        List<StaffViewModel> List();

    }
}
