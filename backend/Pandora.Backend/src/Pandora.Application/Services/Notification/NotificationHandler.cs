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
        private int _statusCode = 400;
        private string _notificationMessage = "";
        private ICollection<string> _detailMessage = new List<string>();

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
            _detailMessage.Add(message);
            return this;
        }

        public INotificationHandler Detail(ICollection<string> messages)
        {
            _detailMessage = messages;
            return this;
        }

        public INotificationHandler Status(int statusCode)
        {
            _statusCode = statusCode;
            return this;
        }

        public void Raise()
        {
            var response = new NotificationResponse()
            {
                StatusCode = _statusCode,
                Title = _notificationMessage ?? "",
                Detail = _detailMessage.ToList<string>()
            };

            _statusCode = 400;
            _notificationMessage = "";
            _detailMessage.Clear();

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
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public ICollection<string> Detail { get; set; }
    }
}
