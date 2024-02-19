using InterviewTask.Models;
using InterviewTask.Models.Enumerations;

namespace InterviewTask.Services.Logger;

public class CommandLineLogger
{
    #region Fields

    private readonly SemaphoreSlim _semaphore = new(1);

    #endregion

    #region Properties

    public List<LogEntry> LogEntries { get; } = new();

    #endregion

    #region Public Methods

    public void LogCritical(string message)
    {
        LogMessage(ELogEntryType.CRITICAL, message);
    }

    public void LogDebug(string message)
    {
        LogMessage(ELogEntryType.DEBUG, message);
    }

    public void LogError(string message)
    {
        LogMessage(ELogEntryType.ERROR, message);
    }

    public void LogInfo(string message)
    {
        LogMessage(ELogEntryType.INFO, message);
    }

    public void LogWarning(string message)
    {
        LogMessage(ELogEntryType.WARNING, message);
    }

    #endregion

    #region Private Methods

    private ConsoleColor GetColor(ELogEntryType messageLevel)
    {
        switch (messageLevel)
        {
            case ELogEntryType.INFO:
                return ConsoleColor.Green;
            case ELogEntryType.WARNING:
                return ConsoleColor.DarkYellow;
            case ELogEntryType.ERROR:
                return ConsoleColor.Red;
            case ELogEntryType.CRITICAL:
                return ConsoleColor.DarkRed;
            case ELogEntryType.DEBUG:
                return ConsoleColor.DarkGreen;
            default:
                return ConsoleColor.White;
        }
    }

    private string GetPrefix(LogEntry message)
    {
        return
            $"[{message.ELogEntryType}]{GetSeparator(message.ELogEntryType)}[{message.Time:HH:mm:ss:ff}] T[{Thread.CurrentThread.ManagedThreadId}]\t";
    }

    private string GetSeparator(ELogEntryType messageLevel)
    {
        return new string(' ', 10 - (messageLevel.ToString().Length + 2));
    }

    private void LogMessage(ELogEntryType targetLevel, string message)
    {
        var logEntry = new LogEntry(targetLevel, message, DateTime.Now);

        var prefix = GetPrefix(logEntry);

        // Tab size is 4 spaces
        var paddingSize = prefix.Length - 1;
        var newLineString = $"{Environment.NewLine}{new string('*', paddingSize)}\t";

        message = message.Replace("\n", Environment.NewLine);

        var fullMessage = $"{prefix}{message.Replace(Environment.NewLine, newLineString)}";

        LogEntries.Add(logEntry);

        _semaphore.Wait();
        try
        {
            Thread.BeginCriticalRegion();
            PrettyPrinter.WriteLine(fullMessage, GetColor(targetLevel));
            Thread.EndCriticalRegion();
        }
        finally
        {
            _semaphore.Release();
        }
    }

    #endregion
}