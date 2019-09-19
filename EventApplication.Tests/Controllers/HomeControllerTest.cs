using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventApplication;
using EventApplication.Controllers;
using EventApplication.Models;

namespace EventApplication.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        [TestMethod]
        public void UpcomingEventTest()
        {
            var Controller = new HomeController();
            var Result = Controller.UpcomingEvent() as ViewResult;
            Assert.AreEqual("", Result.ViewName);
        }

        [TestMethod]
        public void PastEventTest()
        {
            var Controller = new HomeController();
            var Result = Controller.PastEvent() as ViewResult;
            Assert.AreEqual("", Result.ViewName);
        }

        [TestMethod]
        public void DetailsTest()
        {
            var Controller = new HomeController();
            EventViewModel model = new EventViewModel();
            var Result = Controller.Details(model) as ViewResult;
            Assert.AreEqual("", Result.ViewName);
        }

        [TestMethod]
        public void IndexTest()
        {
            var Controller = new HomeController();
            var Result = Controller.PastEvent() as ViewResult;
            Assert.AreEqual(null, Result.View);
        }


    }


}
