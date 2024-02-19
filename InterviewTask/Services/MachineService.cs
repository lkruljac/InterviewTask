using InterviewTask.Models;
using InterviewTask.Services.Logger;

namespace InterviewTask.Services;

public class MachineService
{
    #region Fields

    private readonly CommandLineLogger _logger = new();

    #endregion

    #region Public Methods

    public Machine ReadMachineData()
    {
        _logger.LogInfo("Reading machine data from environment...");
        var machineName = Environment.MachineName;
        var osVersion = Environment.OSVersion.VersionString;
        _logger.LogWarning($"You are using {(Environment.Is64BitOperatingSystem ? "64" : "32")}-bit operating system.");

        _logger.LogInfo("Done!");

        return new Machine(machineName, osVersion);
    }

    #endregion
}