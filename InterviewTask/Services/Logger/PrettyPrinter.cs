namespace InterviewTask.Services.Logger;

public static class PrettyPrinter
{
    private const ConsoleColor _defaultColor = ConsoleColor.White;

    private static ConsoleColor _currentColor;

    #region Public Methods

    public static void Write(string text, ConsoleColor consoleColor = _defaultColor)
    {
        SetColor(consoleColor);
        Console.Write(text);
        ResetColor();
    }

    public static void WriteLine(string text, ConsoleColor consoleColor = _defaultColor)
    {
        SetColor(consoleColor);
        Console.WriteLine(text);
        ResetColor();
    }

    #endregion

    #region Private Methods

    private static void SetColor(ConsoleColor consoleColor)
    {
        _currentColor = Console.ForegroundColor;
        Console.ForegroundColor = consoleColor;
    }

    private static void ResetColor()
    {
        Console.ForegroundColor = _currentColor;
    }

    #endregion
}