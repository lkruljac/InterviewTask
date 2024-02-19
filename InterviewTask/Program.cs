using InterviewTask.Models;
using InterviewTask.Models.Enumerations;
using InterviewTask.Services;
using InterviewTask.Services.Serialization.XMLSerializers;

internal class Program
{
    #region Public Methods

    public static void Main(string[] args)
    {
        var user = new UserService().ReadUserData();
        var machine = new MachineService().ReadMachineData();

        Console.WriteLine($"You are using machine \"{machine.Name}\" with \"{machine.OSVersion}\" installed on it.");
        Console.WriteLine($"Current user is: \"{user.Domain}\\{user.UserName}\"");

        List<LogEntry> logs = null; // How can I get all logs left by all services

        var logFileDirectory = ""; // How can I get desktop folder

        SaveLogs(logs, ELogFileType.JSON, logFileDirectory);
    }

    #endregion

    #region Private Methods

    private static void SaveLogs(List<LogEntry> logs, ELogFileType fileType, string logFileDirectory)
    {
        // How can I replace this with strategy pattern?

        var fullPath = $"{logFileDirectory}\\namelessLogFile.{fileType.GetDescription()}";

        switch (fileType)
        {
            case ELogFileType.XML:
                new XMLSerializer().SaveToFile(logs, fullPath);
                break;
            case ELogFileType.JSON:
                new JSONSerializer().SaveToFile(logs, fullPath);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null);
        }
    }

    #endregion
}