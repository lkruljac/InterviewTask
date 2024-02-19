using InterviewTask.Services.Serialization.XMLSerializers;
using Newtonsoft.Json;

public class JSONSerializer : ISerializer
{
    public TData LoadFromFile<TData>(string filePath)
    {
        using (var file = File.OpenText(filePath))
        {
            var serializer = new JsonSerializer();
            return (TData) serializer.Deserialize(file, typeof(TData));
        }
    }

    public bool SaveToFile<TData>(TData model, string filePath)
    {
        using (var file = new StreamWriter(filePath))
        {
            var serializer = new JsonSerializer();
            serializer.Serialize(file, model);
            return true;
        }
    }

    public string GetString<TData>(TData data)
    {
        return JsonConvert.SerializeObject(data);
    }

    public TData? LoadFromString<TData>(string jsonString)
    {
        return JsonConvert.DeserializeObject<TData>(jsonString);
    }
}