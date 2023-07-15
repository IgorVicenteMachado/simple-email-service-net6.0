
namespace etmai.aspnet6.email.Services
{
    public interface INotification
    {
        bool HasAnyNotification();
        List<string> GetNotifications();
        void Handle(string notificacao);
    }

    public class Notification : INotification
    {
        private List<string> _notifications;

        public Notification()
        {
            _notifications = new List<string>();
        }

        public void Handle(string notificacao)
        {
            _notifications.Add(notificacao);
        }

        public List<string> GetNotifications()
        {
            return _notifications;
        }

        public bool HasAnyNotification()
        {
            return _notifications.Any();
        }
    }
}
