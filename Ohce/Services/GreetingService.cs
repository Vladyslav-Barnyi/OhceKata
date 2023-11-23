using Ohce.Services.Interfaces;

namespace Ohce.Services;

public class GreetingService : IGreetingService
{
    public string GreetUser(string userName , DateTime time)
    {
        var result = time.Hour switch
        {
            > 6 and < 12 => $"¡Buenos días {userName}!",
            > 12 and < 20 => $"¡Buenas tardes {userName}!",
            _ => $"¡Buenas noches {userName}!"
        };

        return result;
    }
}