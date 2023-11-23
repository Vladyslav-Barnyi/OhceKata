using Ohce.Infrastructure.Interface;

namespace Ohce.Infrastructure;

public class ConsoleWrapper : IConsoleWrapper
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public string ReadLine()
    {
        return Console.ReadLine() ?? string.Empty;
    }
}