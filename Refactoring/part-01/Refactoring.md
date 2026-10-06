# Part 01 — answers

---

## ShippingCostCalculator

- What was the problem? the class violate the Open/Closed Principle (OCP) because it is not open for extension and closed for modification. Every time we want to add a new carrier, we have to modify the ShippingCostCalculator class, which is not ideal. We want to be able to add new carriers without modifying the existing code.
- What did you change? I introduced an interface IShippingCostStrategy that defines a method CalculateShippingCost. Each carrier (Aramex, FedEx, DHL, UPS) implements this interface with its own calculation logic. The ShippingCostCalculator class now depends on the IShippingCostStrategy interface rather than concrete implementations, allowing us to inject different strategies at runtime without modifying the ShippingCostCalculator class itself. This adheres to the Open/Closed Principle by making the system open for extension (adding new carriers) but closed for modification (no need to change existing code).

---

## OrderProcessor

- What was the problem? the OrderProcessor class was tightly coupled to specific implementations of order repository and email sender, violating the Dependency Inversion Principle (DIP). This made it difficult to change or extend the behavior of order processing without modifying the OrderProcessor class itself.
- What did you change? I introduced interfaces IOrderRepository and IEmailSender to abstract the dependencies of the OrderProcessor class. The OrderProcessor now depends on these abstractions rather than concrete implementations, allowing for greater flexibility and adherence to the Dependency Inversion Principle. This change enables the use of different implementations of order repositories and email senders without modifying the OrderProcessor class, promoting better maintainability and testability.

---

## Notifications

- What was the problem? causing inheritance explosion, where we would have to create a new class for every combination of notification types (e.g., UrgentEmailNotification, ScheduledSmsNotification, etc.). This approach violates the Open/Closed Principle (OCP) because adding new notification types would require modifying existing classes or creating numerous subclasses, leading to code duplication and maintenance challenges.
- What did you change? I refactored the notification system to use the Decorator pattern. I created a base interface INotification and concrete classes for EmailNotification and SmsNotification. Then, I introduced abstract decorator classes (NotificationDecorator) and concrete decorators (UrgentNotification and ScheduledNotification) that can wrap existing notifications to add new behaviors. This allows for flexible composition of notification types without creating an explosion of subclasses, adhering to the Open/Closed Principle by enabling extension without modification of existing code.

---

## Proof

- New carrier file(s): ShippingCostCalculatoor.cs
- New notification channel file(s): inside Notification.cse 
- Existing classes left unchanged? (yes/no): behaviour statys but classes changes
