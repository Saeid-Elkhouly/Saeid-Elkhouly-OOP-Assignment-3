
using part_02.src;

Console.WriteLine("=== Reports ===");
var outDir = Path.Combine(Path.GetTempPath(), "refactoring-lab-part02");
Directory.CreateDirectory(outDir);

new CsvReportExporter().Export(Path.Combine(outDir, "report.csv"));
new JsonReportExporter().Export(Path.Combine(outDir, "report.json"));
new TextReportExporter().Export(Path.Combine(outDir, "report.txt"));
Console.WriteLine($"Wrote reports to {outDir}");
Console.WriteLine();

Console.WriteLine("=== Enrollment ===");
var studentId = "S100";
var courseId = "CS201";
var amount = 1500m;

EnrollmentFacade enrollment = new EnrollmentFacade(
    new PaymentGateway(),
    new SeatInventory(),
    new InvoiceGenerator(),
    new EmailService()
);
enrollment.EnrollStudent(studentId, courseId, amount);
