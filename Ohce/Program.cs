using System.Text.RegularExpressions;
using Ohce.Services;
using Ohce.Services.Interfaces;

namespace Ohce
{
    public class Program
    {
        private readonly IGreetingService _greetingService;
        private readonly IReverseEchoingService _reverseEchoingService;
        private readonly IDateTimeService _dateTimeService;

        public Program(IGreetingService greetingService, 
            IReverseEchoingService reverseEchoingService, IDateTimeService dateTimeService)
        {
            _greetingService = greetingService;
            _reverseEchoingService = reverseEchoingService;
            _dateTimeService = dateTimeService;
        }

        public void Run()
        {
            string userName = GetValidNameFromUserInput();
            var time = _dateTimeService.Now;
            var greet = _greetingService.GreetUser(userName, time);
            Console.WriteLine(greet);
            
            while (true)
            {
                string? userInput = Console.ReadLine();
                
                if (userInput == "Stop!") {
                    Console.WriteLine($"Adios {userName}!");
                    return;
                }else {
                    if (string.IsNullOrWhiteSpace(userInput)) {
                        Console.WriteLine($"Chao {userName}!");
                        return;
                    }

                    var output = _reverseEchoingService.RevertString(userInput);
                    Console.WriteLine(output);
                }
            }
        }

        private string GetValidNameFromUserInput()
        {
            string userName;
            do
            {
                Console.WriteLine("Please enter your name (only letters allowed):");
                userName = Console.ReadLine()!;
            } while (!IsValidName(userName));

            return userName;
        }
        private static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) {
                Console.WriteLine("Name cannot be empty. Please try again.");
                return false;
            }

            Regex regex = new Regex("^[a-zA-Z]+$");
            if (regex.IsMatch(name))
                return true;

            Console.WriteLine("Please enter only letters (A-Z or a-z).");
            return false;
        }

        public static void Main()
        {
            var greetingService = new GreetingService(); 
            var reverseEchoingService = new ReverseEchoingService();
            var dateTimeService = new DateTimeService();

            var program = new Program(greetingService, reverseEchoingService, dateTimeService);
            program.Run();
        }
    }
}
