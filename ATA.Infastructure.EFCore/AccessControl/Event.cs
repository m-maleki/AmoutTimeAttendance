using System;
using System.Collections.Generic;
using System.Text;

namespace ATA.Infastructure.EFCore.AccessControl
{
   public class Event
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string UserId { get; set; }
        public long SeqNo { get; set; }
        public Event(DateTime date, string time, string userId, long seqNo)
        {
            Date = date;
            Time = time;
            UserId = userId;
            SeqNo = seqNo;
        }
    }
}
