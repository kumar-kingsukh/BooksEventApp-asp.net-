using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventApplication.Controllers;


namespace EventApplication.Tests.Controllers
{

    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            var Controller = new AccountController();
            var Result = Controller.Index() as ViewResult;
            Assert.AreEqual("LoginUser", Result.ViewName);
        }

        [TestMethod]
        public void CreateUserTest()
        {
            var Controller = new AccountController();
            var Result = Controller.CreateUser() as ViewResult;
            Assert.AreEqual(null, Result.View);

        }

        [TestMethod]
        public void LoginUserTest()
        {
            var Controller = new AccountController();
            var Result = Controller.LoginUser() as ViewResult;
            Assert.AreEqual(null, Result.View);

        }
    }
}
