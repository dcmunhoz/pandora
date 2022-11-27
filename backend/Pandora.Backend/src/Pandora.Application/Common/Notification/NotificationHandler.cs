using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Common.Notification
{
    public class NotificationHandler: INotificationHandler
    {
        private ICollection<NotificationResponse> _notifications;
        private HttpStatusCode _statusCode = HttpStatusCode.BadRequest;
        private string _notificationMessage = "";
        private string _detailMessage = "";

        public NotificationHandler()
        {
            _notifications = new List<NotificationResponse>();
        }

        public INotificationHandler Title(string message)
        {
            _notificationMessage = message;
            return this;
        }

        public INotificationHandler Detail(string message)
        {
            _detailMessage = message;
            return this;
        }

        public INotificationHandler Status(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
            return this;
        }

        public void Raise()
        {
            var response = new NotificationResponse()
            {
                Status = _statusCode,
                Title = _notificationMessage ?? "",
                Detail = _detailMessage ?? ""
            };

            _notifications.Add(response);
        }   

        public bool HasNotification()
        {
            return _notifications.Count() > 0;
        }

        public NotificationResponse GetNotification()
        {
            if (HasNotification()) return _notifications.FirstOrDefault();

            return default;
        }
    }

    public class NotificationResponse
    {
        public HttpStatusCode Status { get; set; }

        public string Title { get; set; }
        public string Detail { get; set; }
    }
}
