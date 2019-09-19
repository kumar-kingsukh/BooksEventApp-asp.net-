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
    public class CommentService
    {
        public CommentDataModel CreateComments(CommentDataModel commentsData)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                Comment newComment = new Comment();

                newComment.Comment1 = commentsData.Comment;
                newComment.Date = commentsData.Date;
                newComment.EventId = commentsData.EventId;
                newComment.UserId = commentsData.UserId;
                newComment.UserName = commentsData.UserName;

                context.Comments.Add(newComment);
                context.SaveChanges();
                return commentsData;

            }
        }

        public List<CommentDataModel> GetComments(CommentDataModel commentData)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                context.Database.Log = Logger.Log;

                List<CommentDataModel> listOfComments = null;
                var commentsEntityList = context.Comments.Where(c => c.EventId == commentData.EventId).ToList();

                if (commentsEntityList != null)
                {
                    listOfComments = new List<CommentDataModel>();

                    foreach (var comment in commentsEntityList)
                    {
                        CommentDataModel commentDataModel = new CommentDataModel();
                        commentDataModel.Date     =   (DateTime)comment.Date;
                        commentDataModel.UserName =   comment.UserName;
                        commentDataModel.UserId   =   comment.UserId;
                        commentDataModel.EventId  =   comment.EventId;
                        commentDataModel.Comment  =   comment.Comment1;

                        listOfComments.Add(commentDataModel);
                    }

                }

                return listOfComments;
            }
        }
    }
}
