namespace Ohce.Services.Interfaces;

public interface IGreetingService
{
    public string GreetUser(string userName, DateTime time);
}