using System.Xml;
using System.Xml.Serialization;

namespace InterviewTask.Services.Serialization.XMLSerializers;

public class XMLSerializer : ISerializer
{
    #region Files

    public TData LoadFromFile<TData>(string filePath)
    {
        TData result;

        try
        {
            var xmlSerializer = new XmlSerializer(typeof(TData));
            var reader = new StreamReader(filePath);
            result = (TData) xmlSerializer.Deserialize(reader);
            reader.Close();
        }
        catch
        {
            result = default;
        }

        return result;
    }

    public bool SaveToFile<TData>(TData model, string filePath)
    {
        if (model == null)
        {
            throw new Exception("Input is null. Nothing to serialize");
        }

        var tempFile = $"{Guid.NewGuid()}.xml";
        StreamWriter writer = null;
        try
        {
            var xmlSerializer = new XmlSerializer(typeof(TData));
            writer = new StreamWriter(tempFile);
            xmlSerializer.Serialize(writer, model);
            writer.Close();
        }
        catch
        {
            writer.Close();
            // Delete tempFile
            File.Delete(tempFile);
            // Saving failed
            return false;
        }

        // File generated successfully
        // Replace original(if existed) with temp
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        var directoryPath = Path.GetDirectoryName(filePath);

        if (!string.IsNullOrWhiteSpace(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        File.Copy(tempFile, filePath);

        File.Delete(tempFile);

        return true;
    }

    #endregion Files

    #region String

    public string GetString<TData>(TData data)
    {
        var xmlSerializer = new XmlSerializer(typeof(TData));
        var xmlString = "";
        using (var stringWriter = new StringWriter())
        {
            using (var xmlWriter = XmlWriter.Create(stringWriter))
            {
                xmlSerializer.Serialize(xmlWriter, data);
                xmlString = stringWriter.ToString();
            }
        }

        return xmlString;
    }

    public TData? LoadFromString<TData>(string xmlString)
    {
        TData? result;

        try
        {
            using (TextReader reader = new StringReader(xmlString))
            {
                var xmlSerializer = new XmlSerializer(typeof(TData));
                result = (TData?) xmlSerializer.Deserialize(reader);
            }
        }
        catch
        {
            result = default;
        }

        return result;
    }

    #endregion String
}