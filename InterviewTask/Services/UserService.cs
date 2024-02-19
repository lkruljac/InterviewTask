using InterviewTask.Models;
using InterviewTask.Services.Logger;

namespace InterviewTask.Services;

public class UserService
{
    #region Fields

    private readonly CommandLineLogger _logger = new();

    #endregion

    #region Public Methods

    public User ReadUserData()
    {
        _logger.LogInfo("Reading user data from environment...");
        var userName = Environment.UserName;
        var domain = Environment.UserDomainName;
        _logger.LogInfo("Done!");
        return new User(userName, domain);
    }

    #endregion
}