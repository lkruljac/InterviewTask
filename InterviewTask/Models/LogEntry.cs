using InterviewTask.Models.Enumerations;

namespace InterviewTask.Models;

public class LogEntry
{
    #region Properties

    public ELogEntryType ELogEntryType { get; set; }
    public string Content { get; set; }
    public DateTime Time { get; set; }

    #endregion

    #region Constructors

    public LogEntry()
    {
    }

    public LogEntry(ELogEntryType type, string content, DateTime time)
    {
        ELogEntryType = type;
        Content = content;
        Time = time;
    }

    #endregion
}