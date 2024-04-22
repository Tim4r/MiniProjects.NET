namespace Worker.Contracts.Entities;

public class Log
{
    public int Id { get; set; }
    public string Message { get; set; }
    public string StackTrace { get; set; }
    public LogLevel LogLevel { get; set; }
    public DateTime DateTime { get; set; }
}
