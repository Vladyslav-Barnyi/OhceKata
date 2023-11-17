using FluentAssertions;
using NSubstitute;
using Ohce;
using Ohce.Services.Interfaces;

namespace OhceTests;

public class OhceTests
{
    private readonly Program _sut;
    private readonly IGreetingService _greetingService = Substitute.For<IGreetingService>();
    private readonly IReverseEchoingService _reverseEchoingService = Substitute.For<IReverseEchoingService>();
    private readonly IDateTimeService _dateTimeService = Substitute.For<IDateTimeService>();
    private readonly StringWriter _stringWriter;
    private StringReader _stringReader;

    public OhceTests()
    {
        _stringWriter = new StringWriter();
        Console.SetOut(_stringWriter);
        _sut = new Program(_greetingService, _reverseEchoingService, _dateTimeService);
    }

    [Fact]
    public void Run_PrintsMorningGreeting_WhenMorning()
    {
        var morningTime = new DateTime(2023, 1, 1, 9, 0, 0);
        _dateTimeService.Now.Returns(morningTime);
        _greetingService.GreetUser(Arg.Any<string>(), Arg.Any<DateTime>())
            .Returns("¡Buenos días Vlad!");

        _stringReader = new StringReader("Vlad\nStop!");
        Console.SetIn(_stringReader);

        _sut.Run();

        var output = _stringWriter.ToString();
        output.Should().Contain("¡Buenos días Vlad!");
    }

    [Fact]
    public void Run_PrintsAfternoonGreeting_WhenAfternoon()
    {
        var afternoonTime = new DateTime(2023, 1, 1, 15, 0, 0);
        _dateTimeService.Now.Returns(afternoonTime);
        _greetingService.GreetUser(Arg.Any<string>(), Arg.Any<DateTime>())
            .Returns("¡Buenas tardes Vlad!");

        _stringReader = new StringReader("Vlad\nStop!");
        Console.SetIn(_stringReader);

        _sut.Run();

        var output = _stringWriter.ToString();
        output.Should().Contain("¡Buenas tardes Vlad!");
    }

    [Fact]
    public void Run_PrintsEveningGreeting_WhenEvening()
    {
        var eveningTime = new DateTime(2023, 1, 1, 22, 0, 0);
        _dateTimeService.Now.Returns(eveningTime);
        _greetingService.GreetUser(Arg.Any<string>(), Arg.Any<DateTime>())
            .Returns("¡Buenas noches Vlad!");

        _stringReader = new StringReader("Vlad\nStop!");
        Console.SetIn(_stringReader);

        _sut.Run();

        var output = _stringWriter.ToString();
        output.Should().Contain("¡Buenas noches Vlad!");
    }

    [Fact]
    public void Run_ReversesInputStringCorrectly()
    {
        string input = "Vlad\nhello\nStop!";
        _stringReader = new StringReader(input);
        Console.SetIn(_stringReader);

        _reverseEchoingService.RevertString(Arg.Any<string>())
            .Returns(x => new string((x.Arg<string>() ?? string.Empty)
                .Reverse().ToArray()));

        _sut.Run();

        var output = _stringWriter.ToString();
        output.Should().Contain("olleh");
    }

    [Fact]
    public void Run_HandlesStopCommandCorrectly()
    {
        _stringReader = new StringReader("Vlad\n\n");
        Console.SetIn(_stringReader);
        _greetingService.GreetUser(Arg.Any<string>(), Arg.Any<DateTime>())
            .Returns("¡Buenos días Vlad!");

        _sut.Run();

        var output = _stringWriter.ToString();
        output.Should().Contain("Chao Vlad!");
    }

    [Fact]
    public void Run_HandlesEmptyInputCorrectly()
    {
        _stringReader = new StringReader("Vlad\nStop!");
        Console.SetIn(_stringReader);
        _greetingService.GreetUser(Arg.Any<string>(), Arg.Any<DateTime>())
            .Returns("¡Buenos días Vlad!");

        _sut.Run();

        var output = _stringWriter.ToString();
        output.Should().Contain("Adios Vlad!");
    }
}