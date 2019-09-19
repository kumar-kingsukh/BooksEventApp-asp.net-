using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApplication.Business.Models
{
   public   class EventDataModel
    {

          public int Id { get; set; }
          public   string Title { get; set; }
          public   DateTime Date { get; set; }
          public  string Location { get; set; }
          public  DateTime StartTime { get; set; }
          public  int DurationInHours { get; set; }
          public  string Description { get; set; }
          public  string OtherDetails { get; set; }
          public   int UserId { get; set; }
          public   int TotalInvites { get; set; }
          public  string Type { get; set; }
          public  string InviteEmails { get; set; }
    
}
}
