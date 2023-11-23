namespace Ohce.Infrastructure.Interface;

public interface IConsoleWrapper
{
    void WriteLine(string message);
    string ReadLine();
}