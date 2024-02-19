using System.ComponentModel;
using System.Reflection;

public static class EnumerationExtensions
{
    #region Public Methods

    public static string GetDescription(this Enum value)
    {
        var enumType = value.GetType();
        var name = Enum.GetName(enumType, value);

        if (name == null)
        {
            return null;
        }

        var field = enumType.GetField(name);

        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();

        return attribute?.Description;
    }

    public static TEnum FromDescription<TEnum>(string description) where TEnum : Enum
    {
        foreach (TEnum enumValue in Enum.GetValues(typeof(TEnum)))
        {
            if (enumValue.GetDescription() == description)
            {
                return enumValue;
            }
        }

        throw new Exception("Enumeration not found");
    }

    #endregion
}