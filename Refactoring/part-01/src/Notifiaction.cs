namespace part_01.src;

//I Search a lot for best solution for this problem, but I found that the best solution is to use the decorator pattern. The decorator pattern allows us to add new functionality to an existing object without modifying its structure. In this case, we can create a base notification class and then create decorators for urgent and scheduled notifications. 


public interface INotification
{
    void Send(string to, string message);
}

    public class EmailNotification : INotification
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"[email] {to}: {message}");
        }
    }

    public class SmsNotification : INotification
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"[sms] {to}: {message}");
        }
    }

    public abstract class NotificationDecorator : INotification
    {
        protected INotification _notification;

        protected NotificationDecorator(INotification notification)
        {
            _notification = notification;
        }

        public virtual void Send(string to, string message)
        {
            _notification.Send(to, message);
        }
    }

    public class UrgentNotification : NotificationDecorator
    {
        public UrgentNotification(INotification notification)
            : base(notification)
        {
        }

        public override void Send(string to, string message)
        {
            base.Send(to, $"[URGENT] {message}");
        }
    }

    public class ScheduledNotification : NotificationDecorator
    {
        public DateTime SendAt { get; set; }

        public ScheduledNotification(
            INotification notification,
            DateTime sendAt)
            : base(notification)
        {
            SendAt = sendAt;
        }

        public override void Send(string to, string message)
        {
            Console.WriteLine($"[scheduled {SendAt:g}]");
            base.Send(to, message);
        }
    }
