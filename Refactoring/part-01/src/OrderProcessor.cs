namespace part_01.src;

// The OrderProcessor class is responsible for processing orders. It uses the SqlOrderRepository to save the order details and the SmtpEmailSender to send a confirmation email to the customer which is Concrete classes that violate the Dependency Inversion Principle (DIP) because they depend on concrete implementations rather than abstractions. To adhere to DIP, we can introduce interfaces for the repository and email sender, allowing for more flexible and testable code.

// Abstraction (use interface way)
public interface IOrderRepository
{
    void Save(int orderId, DateTime processedAt);
}

public interface IEmailSender
{
    void Send(string to, string body);
}

//Orchaestrator class that uses the abstractions to process orders without depending on concrete implementations
//coordinates, manages, and connects multiple independent tasks, services, or tools into a single coherent workflow
public class OrderProcessor
{
    IOrderRepository _orderRepository;
    IEmailSender _emailSender;
    public OrderProcessor(IOrderRepository orderRepository, IEmailSender emailSender)
    {
        _orderRepository = orderRepository;
        _emailSender = emailSender;
    }
    public void Process(int orderId, string customerEmail)
    {
        _orderRepository.Save(orderId, DateTime.Now);
        _emailSender.Send(customerEmail, $"Your order {orderId} has been processed.");

    }
}

    public class SqlOrderRepository: IOrderRepository
    {
        public void Save(int orderId, DateTime processedAt) =>
            Console.WriteLine($"[SQL] save order {orderId} @ {processedAt:O}");
    }

    public class SmtpEmailSender: IEmailSender
    {
        public void Send(string to, string body) =>
            Console.WriteLine($"[SMTP] to={to} body={body}");
    }
