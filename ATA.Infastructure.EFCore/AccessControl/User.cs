using System;
using System.Collections.Generic;
using System.Text;

namespace ATA.Infastructure.EFCore.AccessControl
{
    public class User
    {
        public long UserID { get; set; }
        public string UserName { get; set; }

        public User(long userId, string userName)
        {
            UserID = userId;
            UserName = userName;
        }
    }
}
