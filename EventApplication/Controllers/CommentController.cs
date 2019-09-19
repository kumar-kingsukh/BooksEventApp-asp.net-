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
    public class CommentController : Controller
    {
        private string GetUserDetail()
        {
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            string user = ticket.Name;

            return user;
        }

        public ActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateComment(CommentViewModel model)
        {
            if (ModelState.IsValid && model.Id != 0)
            {
                CommentDataModel commentDataModel = new CommentDataModel();
                string user = GetUserDetail();
                model.UserName = user.Split('|')[0];
                model.UserId = Convert.ToInt32(user.Split('|')[1]);
                model.EventId = model.Id;
                model.Date = DateTime.Now;

                commentDataModel.UserName  =   model.UserName;
                commentDataModel.UserId    =   model.UserId;
                commentDataModel.Comment   =   model.Comment;
                commentDataModel.Date      =   model.Date;
                commentDataModel.EventId   =   model.EventId;

                CommentService commentService = new CommentService();
                var result = commentService.CreateComments(commentDataModel);

                if (result == null)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View();
                }

      
            }
            ModelState.Clear();
            return View();

        }


        [AllowAnonymous]
        public ActionResult GetComments(CommentViewModel model)
        {
            CommentDataModel commentDataModel = new CommentDataModel();
            commentDataModel.EventId = model.Id;

            CommentService commentService = new CommentService();
            var result = commentService.GetComments(commentDataModel);

            List<CommentViewModel> commentModel = null;

            if (result != null)
            {
                commentModel = new List<CommentViewModel>();
                foreach (CommentDataModel lcomment in result)
                {
                    CommentViewModel commentViewModel = new CommentViewModel();
                    commentViewModel.Date = lcomment.Date;
                    commentViewModel.UserId = lcomment.UserId;
                    commentViewModel.UserName = lcomment.UserName;
                    commentViewModel.Comment= lcomment.Comment;
  


                    commentModel.Add(commentViewModel);
                }
                return View(commentModel);

            }

            return View();

        }




    }
}