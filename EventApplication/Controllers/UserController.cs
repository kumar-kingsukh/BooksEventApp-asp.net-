using EventApplication.Business.Models;
using EventApplication.Business.Services;
using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EventApplication.Controllers
{
   
    [Authorize]
    public class UserController : Controller
    {
        private string GetUserDetail()
        {
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            string user = ticket.Name;

            return user;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyEvents()
        {
            EventDataModel eventDataModel = new EventDataModel();
            string user = GetUserDetail();
            eventDataModel.UserId = Convert.ToInt32(user.Split('|')[1]);
            EventService eventService = new EventService();
            var result = eventService.GetEvents(eventDataModel);

            List<EventViewModel> eventsModel = null;

            if (result != null)
            {
                eventsModel = new List<EventViewModel>();
                foreach (EventDataModel levent in result)
                {
                    EventViewModel eventViewModel = new EventViewModel();
                    eventViewModel.Date = levent.Date;
                    eventViewModel.Description = levent.Description;
                    eventViewModel.DurationInHours = (int)levent.DurationInHours;
                    eventViewModel.Id = levent.Id;
                    eventViewModel.InviteEmails = levent.InviteEmails;
                    eventViewModel.Location = levent.Location;
                    eventViewModel.OtherDetails = levent.OtherDetails;
                    eventViewModel.StartTime = (DateTime)levent.StartTime;
                    eventViewModel.Title = levent.Title;
                    eventViewModel.TotalInvites = (int)levent.TotalInvites;
                    eventViewModel.Type = levent.Type;
                    eventViewModel.UserId = levent.UserId;


                    eventsModel.Add(eventViewModel);
                }
                return View(eventsModel);

            }

            return View();

        }

        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(EventViewModel eventData)
        {
            if (ModelState.IsValid)
            {
                EventDataModel eventDataModel = new EventDataModel();
                string user = GetUserDetail();
                    eventDataModel.UserId = Convert.ToInt32(user.Split('|')[1]);
                    eventDataModel.Date = eventData.Date;
                    eventDataModel.Description = eventData.Description;
                    eventDataModel.DurationInHours = (int)eventData.DurationInHours;
                    eventDataModel.Id = eventData.Id;
                    eventDataModel.InviteEmails = eventData.InviteEmails;
                    eventDataModel.Location = eventData.Location;
                    eventDataModel.OtherDetails = eventData.OtherDetails;
                    eventDataModel.StartTime = (DateTime)eventData.StartTime;
                    eventDataModel.Title = eventData.Title;
                    eventDataModel.TotalInvites = (int)eventData.TotalInvites;
                    eventDataModel.Type = eventData.Type;

                    EventService eventService = new EventService();
                    var result = eventService.CreateEvent(eventDataModel);

                    if (result == null)
                    {
                        ModelState.AddModelError("", "Something went wrong...");
                        return View();
                    }
                    ModelState.Clear();
                    return RedirectToAction("MyEvents");

            }

             return View();

        }

        [HttpPost]
        public ActionResult EditEventPost(EventViewModel model)
        {
        
            if (ModelState.IsValid)
            {
                EventDataModel eventDataModel = new EventDataModel();
                string user = GetUserDetail();
                eventDataModel.UserId = Convert.ToInt32(user.Split('|')[1]);
                eventDataModel.Date = model.Date;
                eventDataModel.Description = model.Description;
                eventDataModel.DurationInHours = (int)model.DurationInHours;
                eventDataModel.InviteEmails = model.InviteEmails;
                eventDataModel.Location = model.Location;
                eventDataModel.OtherDetails = model.OtherDetails;
                eventDataModel.StartTime = (DateTime)model.StartTime;
                eventDataModel.Title = model.Title;
                eventDataModel.Type = model.Type;
                eventDataModel.Id = model.Id;

                EventService eventService = new EventService();
                var result = eventService.EditEvent(eventDataModel);

                if (result == null)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View();
                }
                if (user.Split('|')[2] == "normal")
                {
                    return RedirectToAction("MyEvents");
                }
                else
                {
                    return RedirectToAction("Events");
                }

            }

            return View();

        }


        public ActionResult EditEvent(EventViewModel model)
        {
            if (model.Id != 0)
            {
                EventDataModel eventDataModel = new EventDataModel();
                eventDataModel.Id = model.Id;

                EventService eventService = new EventService();
                var result = eventService.GetEventDetails(eventDataModel);

                if (result != null)
                {
                    model.Date = result.Date;
                    model.Description = result.Description;
                    model.DurationInHours = (int)result.DurationInHours;
                    model.InviteEmails = result.InviteEmails;
                    model.Location = result.Location;
                    model.OtherDetails = result.OtherDetails;
                    model.StartTime = (DateTime)result.StartTime;
                    model.Title = result.Title;
                    model.Type = result.Type;
                }

                ModelState.Clear();
                return View(model);
            }
            return View();
        }


        public ActionResult EventDetail(EventViewModel model)
        {

            if (model.Id != 0)
            {
                EventDataModel eventDataModel = new EventDataModel();
                eventDataModel.Id = model.Id;

                EventService eventService = new EventService();
                var result = eventService.GetEventDetails(eventDataModel);

                if (result != null)
                {
                    model.Date = result.Date;
                    model.Description = result.Description;
                    model.DurationInHours = (int)result.DurationInHours;
                    model.InviteEmails = result.InviteEmails;
                    model.Location = result.Location;
                    model.OtherDetails = result.OtherDetails;
                    model.StartTime = (DateTime)result.StartTime;
                    model.Title = result.Title;
                    model.Type = result.Type;
                }

                return View(model);
            }
            return View();
        }


        public ActionResult DeleteEvent(EventViewModel model)
        {
            EventDataModel eventDetail = new EventDataModel();
            eventDetail.Id = model.Id;

            EventService eventService = new EventService();
            var  result = eventService.DeleteEvent(eventDetail);

            ModelState.Clear();
            if (User.Identity.Name.Split('|')[2] == "admin")
                return RedirectToAction("Events");
            else
                return RedirectToAction("MyEvents");

        }



        public ActionResult Events()
        {
            EventDataModel eventDataModel = new EventDataModel();
            string user = GetUserDetail();
            eventDataModel.UserId = Convert.ToInt32(user.Split('|')[1]);
            EventService eventService = new EventService();
            var result = eventService.Events(eventDataModel);

            List<EventViewModel> eventsModel = null;

            if (result != null)
            {
                eventsModel = new List<EventViewModel>();
                foreach (EventDataModel levent in result)
                {
                    EventViewModel eventViewModel = new EventViewModel();
                    eventViewModel.Date = levent.Date;
                    eventViewModel.Description = levent.Description;
                    eventViewModel.DurationInHours = (int)levent.DurationInHours;
                    eventViewModel.Id = levent.Id;
                    eventViewModel.InviteEmails = levent.InviteEmails;
                    eventViewModel.Location = levent.Location;
                    eventViewModel.OtherDetails = levent.OtherDetails;
                    eventViewModel.StartTime = (DateTime)levent.StartTime;
                    eventViewModel.Title = levent.Title;
                    eventViewModel.TotalInvites = (int)levent.TotalInvites;
                    eventViewModel.Type = levent.Type;
                    eventViewModel.UserId = levent.UserId;


                    eventsModel.Add(eventViewModel);
                }
                return View(eventsModel);

            }

            return View();

        }

        public ActionResult EventsInviteTo()
        {

            InviteDataModel inviteDataModel = new InviteDataModel();
            string user = GetUserDetail();
            inviteDataModel.UserId = Convert.ToInt32(user.Split('|')[1]);
            InvitesService invitesService = new InvitesService();
            var result = invitesService.GetInvites(inviteDataModel);

            List<EventViewModel> eventsModel = null;

            if (result != null && result.Count != 0)
            {
                eventsModel = new List<EventViewModel>();
                foreach (EventDataModel levent in result)
                {
                    EventViewModel eventViewModel = new EventViewModel();
                    eventViewModel.Date = levent.Date;
                    eventViewModel.Description = levent.Description;
                    eventViewModel.DurationInHours = (int)levent.DurationInHours;
                    eventViewModel.Id = levent.Id;
                    eventViewModel.InviteEmails = levent.InviteEmails;
                    eventViewModel.Location = levent.Location;
                    eventViewModel.OtherDetails = levent.OtherDetails;
                    eventViewModel.StartTime = (DateTime)levent.StartTime;
                    eventViewModel.Title = levent.Title;
                    eventViewModel.TotalInvites = (int)levent.TotalInvites;
                    eventViewModel.Type = levent.Type;
                    eventViewModel.UserId = levent.UserId;


                    eventsModel.Add(eventViewModel);
                }
                return View(eventsModel);

            }

            return View();
        }


        public ActionResult UserUpcomingEvent()
        {
            EventDataModel eventDataModel = new EventDataModel();
            string user = GetUserDetail();
            eventDataModel.UserId = Convert.ToInt32(user.Split('|')[1]);
            EventService eventService = new EventService();
            var result = eventService.GetUserFutureEvents(eventDataModel);
            List<EventViewModel> eventsModel = null;

            if (result != null)
            {
                eventsModel = new List<EventViewModel>();
                foreach (EventDataModel levent in result)
                {
                    EventViewModel eventViewModel = new EventViewModel();
                    eventViewModel.Date = levent.Date;
                    eventViewModel.Description = levent.Description;
                    eventViewModel.DurationInHours = (int)levent.DurationInHours;
                    eventViewModel.Id = levent.Id;
                    eventViewModel.InviteEmails = levent.InviteEmails;
                    eventViewModel.Location = levent.Location;
                    eventViewModel.OtherDetails = levent.OtherDetails;
                    eventViewModel.StartTime = (DateTime)levent.StartTime;
                    eventViewModel.Title = levent.Title;
                    eventViewModel.TotalInvites = (int)levent.TotalInvites;
                    eventViewModel.Type = levent.Type;
                    eventViewModel.UserId = levent.UserId;


                    eventsModel.Add(eventViewModel);
                }
                return View(eventsModel);

            }
            return View();


        }

        public ActionResult UserPastEvent()
        {
            EventDataModel eventDataModel = new EventDataModel();
            string user = GetUserDetail();
            eventDataModel.UserId = Convert.ToInt32(user.Split('|')[1]);
            EventService eventService = new EventService();
            var result = eventService.GetUserPastEvents(eventDataModel);
            List<EventViewModel> eventsModel = null;

            if (result != null)
            {
                eventsModel = new List<EventViewModel>();
                foreach (EventDataModel levent in result)
                {
                    EventViewModel eventViewModel = new EventViewModel();
                    eventViewModel.Date = levent.Date;
                    eventViewModel.Description = levent.Description;
                    eventViewModel.DurationInHours = (int)levent.DurationInHours;
                    eventViewModel.Id = levent.Id;
                    eventViewModel.InviteEmails = levent.InviteEmails;
                    eventViewModel.Location = levent.Location;
                    eventViewModel.OtherDetails = levent.OtherDetails;
                    eventViewModel.StartTime = (DateTime)levent.StartTime;
                    eventViewModel.Title = levent.Title;
                    eventViewModel.TotalInvites = (int)levent.TotalInvites;
                    eventViewModel.Type = levent.Type;
                    eventViewModel.UserId = levent.UserId;


                    eventsModel.Add(eventViewModel);
                }
                return View(eventsModel);

            }
            return View();


        }

        public ActionResult Details()
        {
            return View();
        }

    }
}