using Tactical.Orders.Application.Contract.Orders.AppliactionServices;

namespace Tactical.Orders.ACL.Notification
{
    public class NotificationService : INotificationService
    {
        public void Send(string text)
        {
            var client = new HttpClient();
            client.PostAsync("http:....", null);
        }
    }
}
