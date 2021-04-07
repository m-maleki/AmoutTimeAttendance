using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net;
using System.Text;
using System.Xml;
using ATA.Domain.StaffAgg;

namespace ATA.Infastructure.EFCore.AccessControl
{
    public class Config
    {
        public string IpAddress { get; set; }
        public int RollOverCount { get; set; }
        public int  SeqNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int NoOfEvents { get; set; }
        public static string FullUrl { get; set; }
        public string Message { get; set; }

        private static WebResponse response;

        public IStaffRepository _StaffRepository;

        public Config()
        {
        }

        public  Config(string ipAddress, int rollOverCount, int noOfEvents,int seqNumber, IStaffRepository staffRepository,string username , string password )
        {
            _StaffRepository = staffRepository;
            IpAddress = ipAddress;
            RollOverCount = rollOverCount;
            SeqNumber = seqNumber;
            Username = username;
            Password = password;
            NoOfEvents = noOfEvents;
            FullUrl = IpAddress + "/device.cgi/events?action=getevent&roll-over-count=" + RollOverCount.ToString() +
                      "&seq-number=" + SeqNumber +
                      "&no-of-events=" + noOfEvents + "&format=xml";
            
            }

        public  string CovertDate(string date)
        {
          
            string temp = "";
            int lenth = date.Length;

            if (date[1].ToString() == "/")
            {
                temp = "0" + date;
            }
            if (date[4].ToString() == "/")
            {
                temp = date.Substring(0, 2) + "/0" + date.Substring(3, 1) + date.Substring(4, lenth - 4);
            }

            if (date[1].ToString() == "/" && date[3].ToString() == "/")
            {

                temp = "0" + date.Substring(0, 1) + "/0" + date.Substring(2, 1) + "/" + date.Substring(4, lenth - 4);

            }
            return temp;
        }

        public int GetEventsCount()
        {
            WebRequest request = WebRequest.Create(IpAddress + "/device.cgi/command?action=geteventcount&format=xml");
            XmlReader reader;
            request.Credentials = new NetworkCredential(Username, Password);
            try
            {
                 response = request.GetResponse();
            }
            catch (System.Net.WebException e)
            {
                Console.WriteLine(" ||| " + e.Message.ToString());
                Message = ".مشکلی در ارتباط با دستگاه پیش آمده است. لطفا مجدد تلاش کنید";
                return 0;
            }
            Message = "داده های دستگاه با موفقیت دریافت شد.";


            try
            {
                 reader = XmlReader.Create(response.GetResponseStream());
            }
            catch (Exception e)
            {
                Console.WriteLine(" ||| " + e.Message.ToString());
                Message = ".مشکلی در ارتباط با دستگاه پیش آمده است. لطفا مجدد تلاش کنید";
                return 0;
            }
           
            string temp = "";
            int count = 0;
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if (reader.IsEmptyElement) { }
                    else { if (reader.Name == "Seq-Number")
                        {
                            reader.Read();
                            if (reader.IsStartElement()) 
                                temp = reader.Name;
                            count = int.Parse(reader.ReadString());
                        }
                    }
                }
            }
            return count;
        }

        public List<Event> GetEvents(int SeqNumber, int noOfEvents)
        {
            List<Event> events = new List<Event>();
            List<string> dates = new List<string>();
            List<string> times = new List<string>();
            List<string> userId = new List<string>();
            List<long> seqNo = new List<long>();
            string temp = "";
            string tempDate ;
            string nameOfUser="";
            DateTime myDate;
            XmlReader reader;
            FullUrl = IpAddress + "/device.cgi/events?action=getevent&roll-over-count=" + RollOverCount.ToString() +
                      "&seq-number=" + SeqNumber +
                      "&no-of-events=" + noOfEvents.ToString() + "&format=xml";

            WebRequest request = WebRequest.Create(FullUrl);
            request.Credentials = new NetworkCredential(Username, Password);

            try
            {
                 response = request.GetResponse();
            }
            catch (System.Net.WebException e)
            {
                Console.WriteLine(" ||| " + e.Message.ToString());
                Message = ".مشکلی در ارتباط با دستگاه پیش آمده است. لطفا مجدد تلاش کنید";
                return events;
            }

            Message = "داده های دستگاه با موفقیت دریافت شد.";

            try
            {
                 reader = XmlReader.Create(response.GetResponseStream());
            }
            catch (Exception e)
            {
                Console.WriteLine(" ||| " + e.Message.ToString());
                Message = ".مشکلی در ارتباط با دستگاه پیش آمده است. لطفا مجدد تلاش کنید";
                return events;
            }
            
          
            while (reader.Read())
            {
            
                if (reader.IsStartElement())
                { if (reader.IsEmptyElement) { } else
                    {
                        if (reader.Name == "date")
                        {
                            reader.Read(); 
                            if (reader.IsStartElement())
                                temp = reader.Name;
                            dates.Add(reader.ReadString());
                        }

                        if (reader.Name == "time")
                        {
                            reader.Read();
                            if (reader.IsStartElement()) 
                                temp = reader.Name;
                            times.Add(reader.ReadString());
                        }

                        if (reader.Name == "detail-1")
                        {
                            reader.Read(); 
                            if (reader.IsStartElement()) 
                                temp = reader.Name;
                            userId.Add(reader.ReadString());
                        }

                        if (reader.Name == "seq-No")
                        {
                            reader.Read(); 
                            if (reader.IsStartElement()) 
                                temp = reader.Name;
                            seqNo.Add(long.Parse(reader.ReadString()));
                        }

                    }
                }
            }
            CultureInfo info = new CultureInfo("fa-Ir");
            for (int i = 0; i < dates.Count; i++)
            {
                if (int.Parse(userId[i]) == 1 || int.Parse(userId[i]) == 3 || int.Parse(userId[i]) == 4)
                {
                    nameOfUser = _StaffRepository.Get(int.Parse(userId[i])).Name;
                    tempDate = CovertDate(dates[i].ToString());
                    myDate = DateTime.ParseExact(tempDate, "dd/MM/yyyy", null);
                    events.Add(new Event(myDate, times[i], nameOfUser, seqNo[i]));
                }
                else
                {
               
                }

            }
            return events;

        }


        public string GetUsernameBy(long UserId)
        {   //http://93.118.109.62/device.cgi/users?action=get&user-id=4&format=xml

            WebRequest request = WebRequest.Create(IpAddress + "/device.cgi/users?action=get&user-id="+ UserId.ToString() + "&format=xml");
            XmlReader reader;

            request.Credentials = new NetworkCredential(Username, Password);
            try
            {
                response = request.GetResponse();
            }
            catch (System.Net.WebException e)
            {
                Console.WriteLine(" ||| " + e.Message.ToString());
                Message = ".مشکلی در ارتباط با دستگاه پیش آمده است. لطفا مجدد تلاش کنید";
                return "";

            }
            Message = "داده های دستگاه با موفقیت دریافت شد.";

            try
            {
                 reader = XmlReader.Create(response.GetResponseStream());
            }
            catch (Exception e)
            {
                Console.WriteLine(" ||| " + e.Message.ToString());
                Message = ".مشکلی در ارتباط با دستگاه پیش آمده است. لطفا مجدد تلاش کنید";
                return "";
            }
           
            string temp = "";
            string name = "";
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if (reader.IsEmptyElement) { }
                    else
                    {
                        if (reader.Name == "name")
                        {
                            reader.Read();
                            if (reader.IsStartElement())
                                temp = reader.Name;
                            name = reader.ReadString();
                        }
                    }
                }
            }
            return name;
        }

    }

}
