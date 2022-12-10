using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Pandora.Application.Common.Notification;
using Pandora.Infra.Repository.Context;

namespace Pandora.Api.Filters
{
    public class NotificationFilter: ActionFilterAttribute
    {

        private INotificationHandler _notification;
        private IDatabaseContext _context;

        public NotificationFilter(INotificationHandler notification, IDatabaseContext context)
        {
            _notification = notification;
            _context = context;
        }

        public async override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            if (context.Exception != null)
            {
                return;
            }
            
            var transaction = _context.Database.CurrentTransaction;

            if (_notification.HasNotification())
            {
                var mediaTypes = new MediaTypeCollection();
                mediaTypes.Add("application/problem+json");

                ObjectResult problem = null;

                if (_notification.GetNotification().Detail.Count == 1)
                {
                    var notification = new { 
                        Title = _notification.GetNotification().Title,
                        StatusCode = _notification.GetNotification().StatusCode,
                        Detail = _notification.GetNotification().Detail.FirstOrDefault()
                    };

                    problem = new ObjectResult(notification)
                    {
                        StatusCode = _notification.GetNotification().StatusCode,
                        ContentTypes = mediaTypes
                    };

                } 
                else
                {
                    problem = new ObjectResult(_notification.GetNotification())
                    {
                        StatusCode = _notification.GetNotification().StatusCode,
                        ContentTypes = mediaTypes
                    };
                }

                context.Result = problem;

                if (transaction != null)
                {
                    await transaction.RollbackAsync();
                }

            }else
            {
                if (transaction != null)
                {
                    await transaction.CommitAsync();
                }
            }


        }
    }
}
