using Ohce.Services;

namespace Ohce;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            string name = args[0];
            var runner = new OhceRunner();
            runner.Run(name); 
        }
        else
        {
            Console.WriteLine("Please provide a name.");
        }
    }
}