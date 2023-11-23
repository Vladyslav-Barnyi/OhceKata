namespace Ohce.Extensions;

public class StringExtension
{
    public string RevertString(string str)
    {
        var reverse = new string(str.Reverse().ToArray());
        
        if(IsPalindrome(str, reverse))
            return $"{str}" + "\n" + "¡Bonita palabra!";

        return reverse;
    }

    private bool IsPalindrome(string str, string reversed)
    {
        return  str == reversed;
    }
}