using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Common.Notification
{
    public interface INotificationHandler
    {
        public INotificationHandler Title(string message);
        public INotificationHandler Detail(string message);
        public INotificationHandler Detail(ICollection<string> message);
        public INotificationHandler Status(int statuscode);
        public void Raise();
        public bool HasNotification();
        public NotificationResponse GetNotification();
    }
}
