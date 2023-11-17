using Ohce.Services.Interfaces;

namespace Ohce.Services;

public class ReverseEchoingService : IReverseEchoingService
{
    public string RevertString(string str)
    {
        var reverse = str.ToCharArray();
        Array.Reverse(reverse);
        var result = new string(reverse);
        
        if (result.Equals(str))
            return $"{str}" + "\n" + "¡Bonita palabra!";

        return result;
    }
}