Because the pattern needs a base class that contains the common algorithm implementation (the template method), shared concrete operations, and abstract or virtual operations that subclasses can implement or optionally override.
interface make contract forces the classes that implement it to implement all methods and we don't need that

# Part 02 — answers

---

## Reports

- What was the problem? we face the violation of DRY principle because we have similar code for different report formats (CSV, JSON, Text) in the Export method. Each format has its own implementation of loading, validating, formatting, and saving data, which leads to code duplication and makes it harder to maintain and extend the code. If we want to add a new report format, we would have to modify the existing code, which violates the Open/Closed Principle (OCP).
- What did you change? i make an abstreact class with Templete method to add the common logic for loading, validating, formatting, and saving data. The Export method in the ReportExporter class defines the template for exporting reports, while the Format method is left abstract for subclasses to implement their specific formatting logic. This way, we can add new report formats by creating new subclasses without modifying the existing code, adhering to the Open/Closed Principle (OCP) and reducing code duplication.
- Why did you choose that approach? mmmmm,because you tell me (i'm sorry)


---

## Enrollment

- What was the problem? the client code was tightly coupled with the subsystems, making it hard to use and maintain.
- What did you change? I introduced a facade class called EnrollmentFacade that provides a simplified interface for enrolling a student in a course. The facade encapsulates the interactions with the PaymentGateway, SeatInventory, InvoiceGenerator, and EmailService subsystems, allowing the client code to interact with a single class instead of multiple subsystems.
- Why did you choose that approach? I chose this approach because it simplifies the client code and reduces its dependency on the subsystems. By using a facade, we can hide the complexity of the underlying subsystems and provide a clear and concise interface for enrolling students. This makes the code easier to read, maintain, and extend in the future.