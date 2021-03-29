using System;
using System.Collections.Generic;
using System.Text;

namespace ATA.Application.Contracts.Staff
{
    public interface IStaffApplication
    {
        List<StaffViewModel> List();

        void Create(CreateStaff command);

        EditStaff Get(long id);
       
        void Remove(long id);
        void Active(long id);
        void Edit(EditStaff command);

    }
}
