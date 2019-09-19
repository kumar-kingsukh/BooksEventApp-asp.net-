using EventApplication.Business.Services;
using EventApplication.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventApplication.Models;

namespace EventApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpcomingEvent()
        {
            EventService eventService = new EventService();
            var result = eventService.GetFutureEvents();
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

        public ActionResult PastEvent()
        {
            EventService eventService = new EventService();
            var result = eventService.GetPastEvents();
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

        public ActionResult Details(EventViewModel eventView)
        {
            EventDataModel eventDataModel = new EventDataModel();
            eventDataModel.Id = eventView.Id;
            EventService eventService = new EventService();
            
            var result = eventService.GetEventDetails(eventDataModel);
            EventViewModel eventViewModel = new EventViewModel();
            if (result != null)
            {
                    eventViewModel.Date = result.Date;
                    eventViewModel.Description = result.Description;
                    eventViewModel.DurationInHours = (int)result.DurationInHours;
                    eventViewModel.Id = result.Id;
                    eventViewModel.InviteEmails = result.InviteEmails;
                    eventViewModel.Location = result.Location;
                    eventViewModel.OtherDetails = result.OtherDetails;
                    eventViewModel.StartTime = (DateTime)result.StartTime;
                    eventViewModel.Title = result.Title;
                    eventViewModel.TotalInvites = (int)result.TotalInvites;
                    eventViewModel.Type = result.Type;
                    eventViewModel.UserId = result.UserId;


                return View(eventViewModel);
            }
               
            return View();


        }

    }
}