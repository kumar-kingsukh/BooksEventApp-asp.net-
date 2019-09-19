using EventApplication.Business.Models;
using EventApplication.Shared.Interceptor;
using EventsApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApplication.Business.Services
{
    public class InvitesService
    {

        public List<EventDataModel> GetInvites(InviteDataModel invitesData)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;

                List<EventDataModel> listOfInvites = null;
                Event eventModel = new Event();
                Invite inviteModel = new Invite();
                var invitesEntityList = context.Invites.Where(i => i.UserId == invitesData.UserId).
                    GroupJoin(context.Events,
                    i => i.EventId, e => e.Id, (i, eve) => new
                    {
                        eventDetail = eve
                    });

                if (invitesEntityList != null)
                {
                    listOfInvites = new List<EventDataModel>();

                    foreach (var invite in invitesEntityList)
                    {
                      
                    
                            EventDataModel eventDataModel = new EventDataModel();
                            eventDataModel.Date = invite.eventDetail.ElementAt(0).Date;
                            eventDataModel.Description = invite.eventDetail.ElementAt(0).Description;
                            eventDataModel.DurationInHours = (int)invite.eventDetail.ElementAt(0).DurationInHours;
                            eventDataModel.Id = invite.eventDetail.ElementAt(0).Id;
                            eventDataModel.InviteEmails = invite.eventDetail.ElementAt(0).InviteEmails;
                            eventDataModel.Location = invite.eventDetail.ElementAt(0).Location;
                            eventDataModel.OtherDetails = invite.eventDetail.ElementAt(0).OtherDetails;
                            eventDataModel.StartTime = (DateTime)invite.eventDetail.ElementAt(0).StartTime;
                            eventDataModel.Title = invite.eventDetail.ElementAt(0).Title;
                            eventDataModel.TotalInvites = (int)invite.eventDetail.ElementAt(0).TotalInvites;
                            eventDataModel.Type = invite.eventDetail.ElementAt(0).Type;
                            eventDataModel.UserId = invite.eventDetail.ElementAt(0).UserId;
                           
                         
                            listOfInvites.Add(eventDataModel);
                     
                    }

                }

                return listOfInvites;
            }
        }
    }
}
