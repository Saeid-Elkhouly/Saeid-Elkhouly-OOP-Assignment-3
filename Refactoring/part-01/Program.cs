
using part_01.src;


INotification notification =
    new ScheduledNotification(
        new UrgentNotification(
            new SmsNotification()),
        DateTime.Now.AddHours(2));

notification.Send("123-456-7890", "This is a scheduled urgent SMS notification.");


ShippingCostCalculator calculator = new ShippingCostCalculator(new AramexShippingCostStrategy());
calculator.Calculate(50); 

