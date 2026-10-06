namespace part_02.src;



public class PaymentGateway
{
    public void Charge(string studentId, decimal amount) =>
        Console.WriteLine($"charge {studentId}: {amount}");
}

    public class SeatInventory
    {
        public void Reserve(string courseId, string studentId) =>
            Console.WriteLine($"reserve seat {courseId} for {studentId}");
    }

    public class InvoiceGenerator
    {
        public string Create(string studentId, decimal amount)
        {
            var invoiceId = $"INV-{studentId}-{amount}";
            Console.WriteLine($"invoice {invoiceId}");
            return invoiceId;
        }
    }

public class EmailService
{
    public void Send(string studentId, string subject, string body) =>
        Console.WriteLine($"email {studentId}: {subject} / {body}");
}

// I know here i violate Dependency Inversion Principle (DIP) because the EnrollmentFacade class depends on concrete implementations but here i focus on practice facade dp
public class EnrollmentFacade
{
    private readonly PaymentGateway _paymentGateway;
    private readonly SeatInventory _seatInventory;
    private readonly InvoiceGenerator _invoiceGenerator;
    private readonly EmailService _emailService;

    public EnrollmentFacade(
        PaymentGateway paymentGateway,
        SeatInventory seatInventory,
        InvoiceGenerator invoiceGenerator,
        EmailService emailService)
    {
        _paymentGateway = paymentGateway;
        _seatInventory = seatInventory;
        _invoiceGenerator = invoiceGenerator;
        _emailService = emailService;
    }

    public void EnrollStudent(string studentId, string courseId, decimal amount)
    {
        _paymentGateway.Charge(studentId, amount);
        _seatInventory.Reserve(courseId, studentId);
        var invoiceId = _invoiceGenerator.Create(studentId, amount);
        _emailService.Send(studentId, "Enrollment confirmed", $"Invoice {invoiceId} for {courseId}");
    }
}
