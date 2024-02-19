namespace InterviewTask.Models;

public class Machine
{
    #region Fields

    public string Name;
    public string OSVersion;

    #endregion

    #region Constructors

    public Machine(string name, string osVersion)
    {
        Name = name;
        OSVersion = osVersion;
    }

    #endregion
}