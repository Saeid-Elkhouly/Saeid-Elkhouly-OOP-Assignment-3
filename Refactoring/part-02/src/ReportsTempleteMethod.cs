namespace part_02.src;

    public abstract class ReportExporter
    {
        public void Export(string path)
        {
            var rows = Load();
            if (!Validate(rows))
                throw new InvalidOperationException("Invalid data");
            var content = Format(rows);
            SaveToFile(path, content);
        }
        protected List<string[]> Load() =>
[
    ["Id", "Name"],
        ["1", "Keyboard"],
        ["2", "Mouse"]
];

        protected bool Validate(List<string[]> rows) =>
            rows.Count > 1 && rows[0].Length > 0;
        protected void SaveToFile(string path, string content) =>
            File.WriteAllText(path, content);

        protected abstract string Format(List<string[]> rows);


    }

public class CsvReportExporter : ReportExporter
{
    protected override string Format(List<string[]> rows) =>
        string.Join(Environment.NewLine, rows.Select(r => string.Join(",", r)));
}
public class JsonReportExporter : ReportExporter
{
    protected override string Format(List<string[]> rows)
    {
        var items = rows.Skip(1).Select(r => $"{{\"Id\":\"{r[0]}\",\"Name\":\"{r[1]}\"}}");
        return "[" + string.Join(",", items) + "]";
    }
}
public class TextReportExporter: ReportExporter
{
    protected override string Format(List<string[]> rows) =>
        string.Join(Environment.NewLine, rows.Select(r => string.Join(" | ", r)));
}
