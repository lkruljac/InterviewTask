namespace InterviewTask.Models;

public class User
{
    #region Properties

    public string UserName { get; }
    public string Domain { get; }

    #endregion

    #region Constructors

    public User(string userName, string domain)
    {
        UserName = userName;
        Domain = domain;
    }

    #endregion
}