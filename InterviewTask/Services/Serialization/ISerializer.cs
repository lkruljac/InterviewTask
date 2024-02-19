namespace InterviewTask.Services.Serialization.XMLSerializers;

public interface ISerializer
{
    #region Public Methods

    public TData LoadFromFile<TData>(string filePath);
    public bool SaveToFile<TData>(TData model, string filePath);
    public string GetString<TData>(TData data);
    public TData? LoadFromString<TData>(string xmlString);

    #endregion
}