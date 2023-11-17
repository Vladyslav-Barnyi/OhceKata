using FluentAssertions;
using Ohce.Services;

namespace OhceTests;

public class GreetingServiceTests
{
    private GreetingService _greetingService;

    public GreetingServiceTests()
    {
        _greetingService = new GreetingService();
    }

    [Fact]
    public void GreetUser_ReturnsMorningGreeting_WhenMorning()
    {
        var morningTime = new DateTime(2023, 1, 1, 9, 0, 0);
        var result = _greetingService.GreetUser("Vlad", morningTime);
        result.Should().Be("¡Buenos días Vlad!");
    }

    [Fact]
    public void GreetUser_ReturnsMorningGreeting_WhenAfternoon()
    {
        var morningTime = new DateTime(2023, 1, 1, 15, 0, 0);
        var result = _greetingService.GreetUser("Vlad", morningTime);
        result.Should().Be("¡Buenas tardes Vlad!");
    }
    
    [Fact]
    public void GreetUser_ReturnsMorningGreeting_WhenEvening()
    {
        var morningTime = new DateTime(2023, 1, 1, 22, 0, 0);
        var result = _greetingService.GreetUser("Vlad", morningTime);
        result.Should().BeEquivalentTo("¡Buenas noches Vlad!");
    }
}