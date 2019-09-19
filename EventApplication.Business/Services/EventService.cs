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
    public class EventService
    {

        public EventDataModel GetEventDetails(EventDataModel eventData)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;

                var eventDetail = context.Events.Where(e => e.Id == eventData.Id).SingleOrDefault();
                EventDataModel eventDataModel = new EventDataModel();

                if (eventDetail != null)
                {
                    eventDataModel.Date = eventDetail.Date;
                    eventDataModel.Description = eventDetail.Description;
                    eventDataModel.DurationInHours = (int)eventDetail.DurationInHours;
                    eventDataModel.Id = eventDetail.Id;
                    eventDataModel.InviteEmails = eventDetail.InviteEmails;
                    eventDataModel.Location = eventDetail.Location;
                    eventDataModel.OtherDetails = eventDetail.OtherDetails;
                    eventDataModel.StartTime = (DateTime)eventDetail.StartTime;
                    eventDataModel.Title = eventDetail.Title;
                    eventDataModel.TotalInvites = (int)eventDetail.TotalInvites;
                    eventDataModel.Type = eventDetail.Type;
                    eventDataModel.UserId = eventDetail.UserId;

                }

                return eventDataModel;
            }
        }

        public List<EventDataModel> GetFutureEvents()
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;

                List<EventDataModel> listOfEvents = null;
                var eventsEntityList = context.Events.OrderByDescending(e => e.Date)
                            .Where(e => e.Date > DateTime.Now && e.Type == "Public").ToList();

                if (eventsEntityList != null)
                {
                    listOfEvents = new List<EventDataModel>();
                    foreach (Event levent in eventsEntityList)
                    {
                        EventDataModel eventDataModel = new EventDataModel();
                        eventDataModel.Date = levent.Date;
                        eventDataModel.Description = levent.Description;
                        eventDataModel.DurationInHours = (int)levent.DurationInHours;
                        eventDataModel.Id = levent.Id;
                        eventDataModel.InviteEmails = levent.InviteEmails;
                        eventDataModel.Location = levent.Location;
                        eventDataModel.OtherDetails = levent.OtherDetails;
                        eventDataModel.StartTime = (DateTime)levent.StartTime;
                        eventDataModel.Title = levent.Title;
                        eventDataModel.TotalInvites = (int)levent.TotalInvites;
                        eventDataModel.Type = levent.Type;
                        eventDataModel.UserId = levent.UserId;


                        listOfEvents.Add(eventDataModel);
                    }

                }

                return listOfEvents;
            }
        }


        public List<EventDataModel> GetPastEvents()
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;

                List<EventDataModel> listOfEvents = null;
                var eventsEntityList = context.Events.OrderByDescending(e => e.Date)
                    .Where(e => e.Date < DateTime.Now && e.Type == "Public").ToList();

                if (eventsEntityList != null)
                {
                    listOfEvents = new List<EventDataModel>();
                    foreach (Event levent in eventsEntityList)
                    {
                        EventDataModel eventDataModel = new EventDataModel();
                        eventDataModel.Date = levent.Date;
                        eventDataModel.Description = levent.Description;
                        eventDataModel.DurationInHours = (int)levent.DurationInHours;
                        eventDataModel.Id = levent.Id;
                        eventDataModel.InviteEmails = levent.InviteEmails;
                        eventDataModel.Location = levent.Location;
                        eventDataModel.OtherDetails = levent.OtherDetails;
                        eventDataModel.StartTime = (DateTime)levent.StartTime;
                        eventDataModel.Title = levent.Title;
                        eventDataModel.TotalInvites = (int)levent.TotalInvites;
                        eventDataModel.Type = levent.Type;
                        eventDataModel.UserId = levent.UserId;


                        listOfEvents.Add(eventDataModel);
                    }

                }

                return listOfEvents;
            }
        }

        public List<EventDataModel> GetEvents(EventDataModel eventData)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;

                List<EventDataModel> listOfEvents = null;
                var eventsEntityList = context.Events.OrderByDescending(e => e.Date).Where(e => e.UserId == eventData.UserId).ToList();

                if (eventsEntityList != null)
                {
                    listOfEvents = new List<EventDataModel>();
                    foreach (Event levent in eventsEntityList)
                    {
                        EventDataModel eventDataModel = new EventDataModel();
                        eventDataModel.Date = levent.Date;
                        eventDataModel.Description = levent.Description;
                        eventDataModel.DurationInHours = (int)levent.DurationInHours;
                        eventDataModel.Id = levent.Id;
                        eventDataModel.InviteEmails = levent.InviteEmails;
                        eventDataModel.Location = levent.Location;
                        eventDataModel.OtherDetails = levent.OtherDetails;
                        eventDataModel.StartTime = (DateTime)levent.StartTime;
                        eventDataModel.Title = levent.Title;
                        eventDataModel.TotalInvites = (int)levent.TotalInvites;
                        eventDataModel.Type = levent.Type;
                        eventDataModel.UserId = levent.UserId;


                        listOfEvents.Add(eventDataModel);
                    }

                }

                return listOfEvents;
            }
        }

        public List<String> ConvertInviteEmails(string s)
        {
            List<string> emails = null;
            if (s != null)
            {
                string[] result = s.Split(',');
                emails = new List<string>();
                foreach (string res in result)
                {
                    emails.Add(res.Trim());
                }
            }

            return emails;
        }


        public EventDataModel CreateEvent(EventDataModel eventData)
        {
            List<string> inviteEmails = ConvertInviteEmails(eventData.InviteEmails);

            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;

                Event newEvent = new Event();

                if (eventData != null)
                {
                    newEvent.Date = eventData.Date;
                    newEvent.Description = eventData.Description;
                    newEvent.DurationInHours = (int)eventData.DurationInHours;
                    newEvent.InviteEmails = eventData.InviteEmails;
                    newEvent.Location = eventData.Location;
                    newEvent.OtherDetails = eventData.OtherDetails;
                    newEvent.StartTime = (DateTime)eventData.StartTime;
                    newEvent.Title = eventData.Title;
                    newEvent.Type = eventData.Type;
                    newEvent.UserId = eventData.UserId;
                }

                var eventModel = context.Events.Add(newEvent);
                context.SaveChanges();


                int countOfInvites = 0;
                if (inviteEmails != null && newEvent.Type != "Private")
                {
                    foreach (string email in inviteEmails)
                    {
                        var user = context.Users.Where(u => u.Email == email).SingleOrDefault();
                        if (user != null)
                        {
                            Invite inviteDetail = new Invite();
                            inviteDetail.EventId = eventModel.Id;
                            inviteDetail.UserId = user.Id;
                            context.Invites.Add(inviteDetail);
                            context.SaveChanges();
                            countOfInvites++;
                        }
                    }
                }
                eventModel.TotalInvites = countOfInvites;
                context.SaveChanges();
                eventData.TotalInvites = countOfInvites;

                return eventData;
            }
        }


        public EventDataModel EditEvent(EventDataModel eventData)
        {
            List<string> inviteEmails = ConvertInviteEmails(eventData.InviteEmails);

            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;

                Event editEvent = context.Events.SingleOrDefault(e => e.Id == eventData.Id);

                if (eventData != null)
                {
                    editEvent.Description = eventData.Description;
                    editEvent.DurationInHours = (int)eventData.DurationInHours;
                    editEvent.InviteEmails = eventData.InviteEmails;
                    editEvent.Location = eventData.Location;
                    editEvent.OtherDetails = eventData.OtherDetails;
                    editEvent.StartTime = (DateTime)eventData.StartTime;
                    editEvent.Title = eventData.Title;
                    editEvent.Type = eventData.Type;
                    editEvent.Date = eventData.Date;

                }
                context.SaveChanges();

                int countOfInvites = 0;
                if (inviteEmails != null && editEvent.Type != "Private")
                {
                    foreach (string email in inviteEmails)
                    {
                        var user = context.Users.Where(u => u.Email == email).SingleOrDefault();

                        if (user != null)
                        {
                            var invite = context.Invites
                            .SingleOrDefault(i => i.EventId == editEvent.Id && i.UserId == user.Id);

                            if (invite == null)
                            {
                                Invite inviteDetail = new Invite();
                                inviteDetail.EventId = editEvent.Id;
                                inviteDetail.UserId = user.Id;
                                context.Invites.Add(inviteDetail);
                                context.SaveChanges();
                            }

                            countOfInvites++;
                        }
                    }
                }

                editEvent.TotalInvites = countOfInvites;
                context.SaveChanges();
                eventData.TotalInvites = countOfInvites;
                return eventData;

            }
        }


        public bool DeleteEvent(EventDataModel eventData)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;

                var deleteEvent = context.Events
                    .SingleOrDefault(e => e.Id == eventData.Id);
                bool result = false;
                if (deleteEvent != null)
                {
                    // Deleting Invites
                    var deleteInvites = context.Invites.Where(i => i.EventId == eventData.Id).ToList();
                    foreach (var invite in deleteInvites)
                    {
                        context.Invites.Remove(invite);
                        context.SaveChanges();
                    }

                    // Deleting Comments
                    var deleteComments = context.Comments.Where(c => c.EventId == eventData.Id).ToList();
                    foreach (var comment in deleteComments)
                    {
                        context.Comments.Remove(comment);
                        context.SaveChanges();
                    }

                    // Deleting Event
                    context.Events.Remove(deleteEvent);
                    context.SaveChanges();
                    result = true;
                }
                return result;

            }


        }


        public List<EventDataModel> Events(EventDataModel eventData)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;

                List<EventDataModel> listOfEvents = null;
                var eventsEntityList = context.Events.OrderByDescending(e => e.Date).ToList();

                if (eventsEntityList != null)
                {
                    listOfEvents = new List<EventDataModel>();
                    foreach (Event levent in eventsEntityList)
                    {
                        EventDataModel eventDataModel = new EventDataModel();
                        eventDataModel.Date = levent.Date;
                        eventDataModel.Description = levent.Description;
                        eventDataModel.DurationInHours = (int)levent.DurationInHours;
                        eventDataModel.Id = levent.Id;
                        eventDataModel.InviteEmails = levent.InviteEmails;
                        eventDataModel.Location = levent.Location;
                        eventDataModel.OtherDetails = levent.OtherDetails;
                        eventDataModel.StartTime = (DateTime)levent.StartTime;
                        eventDataModel.Title = levent.Title;
                        eventDataModel.TotalInvites = (int)levent.TotalInvites;
                        eventDataModel.Type = levent.Type;
                        eventDataModel.UserId = levent.UserId;


                        listOfEvents.Add(eventDataModel);
                    }

                }

                return listOfEvents;
            }
        }

        public List<EventDataModel> GetUserFutureEvents(EventDataModel eventData)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;

                List<EventDataModel> listOfEvents = null;
                var eventsEntityList = context.Events.OrderByDescending(e => e.Date)
                            .Where(e => e.Date > DateTime.Now && e.Type == "Public" ||
                            (e.Type == "Private" && e.UserId==eventData.UserId && e.Date > DateTime.Now))
                            .ToList();

                if (eventsEntityList != null)
                {
                    listOfEvents = new List<EventDataModel>();
                    foreach (Event levent in eventsEntityList)
                    {
                        EventDataModel eventDataModel = new EventDataModel();
                        eventDataModel.Date = levent.Date;
                        eventDataModel.Description = levent.Description;
                        eventDataModel.DurationInHours = (int)levent.DurationInHours;
                        eventDataModel.Id = levent.Id;
                        eventDataModel.InviteEmails = levent.InviteEmails;
                        eventDataModel.Location = levent.Location;
                        eventDataModel.OtherDetails = levent.OtherDetails;
                        eventDataModel.StartTime = (DateTime)levent.StartTime;
                        eventDataModel.Title = levent.Title;
                        eventDataModel.TotalInvites = (int)levent.TotalInvites;
                        eventDataModel.Type = levent.Type;
                        eventDataModel.UserId = levent.UserId;


                        listOfEvents.Add(eventDataModel);
                    }

                }

                return listOfEvents;
            }
        }


        public List<EventDataModel> GetUserPastEvents(EventDataModel eventData)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;

                List<EventDataModel> listOfEvents = null;
                var eventsEntityList = context.Events.OrderByDescending(e => e.Date)
                    .Where(e => e.Date < DateTime.Now && e.Type == "Public" ||
                    ( e.Type == "Private" && e.UserId==eventData.UserId && e.Date < DateTime.Now))
                    .ToList();

                if (eventsEntityList != null)
                {
                    listOfEvents = new List<EventDataModel>();
                    foreach (Event levent in eventsEntityList)
                    {
                        EventDataModel eventDataModel = new EventDataModel();
                        eventDataModel.Date = levent.Date;
                        eventDataModel.Description = levent.Description;
                        eventDataModel.DurationInHours = (int)levent.DurationInHours;
                        eventDataModel.Id = levent.Id;
                        eventDataModel.InviteEmails = levent.InviteEmails;
                        eventDataModel.Location = levent.Location;
                        eventDataModel.OtherDetails = levent.OtherDetails;
                        eventDataModel.StartTime = (DateTime)levent.StartTime;
                        eventDataModel.Title = levent.Title;
                        eventDataModel.TotalInvites = (int)levent.TotalInvites;
                        eventDataModel.Type = levent.Type;
                        eventDataModel.UserId = levent.UserId;


                        listOfEvents.Add(eventDataModel);
                    }

                }

                return listOfEvents;
            }
        }



    }
}
