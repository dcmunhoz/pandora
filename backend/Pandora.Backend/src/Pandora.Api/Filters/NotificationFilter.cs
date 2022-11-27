using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Pandora.Application.Common.Notification;

namespace Pandora.Api.Filters
{
    public class NotificationFilter: ActionFilterAttribute
    {

        public INotificationHandler _notification;

        public NotificationFilter(INotificationHandler notification)
        {
            _notification = notification;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            if (_notification.HasNotification())
            {
                var mediaTypes = new MediaTypeCollection();
                mediaTypes.Add("application/problem+json");

                var problem = new ObjectResult(_notification.GetNotification())
                {
                    StatusCode = (int)_notification.GetNotification().Status,
                    ContentTypes = mediaTypes
                };

                context.Result = problem;

            }


        }
    }
}
