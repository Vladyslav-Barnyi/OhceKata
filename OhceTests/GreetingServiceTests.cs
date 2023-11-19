using FluentAssertions;
using NSubstitute;
using Ohce.Services;
using Ohce.Services.Interfaces;

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
    public void GreetUser_ReturnsAfternoonGreeting_WhenAfternoon()
    {
        var morningTime = new DateTime(2023, 1, 1, 15, 0, 0);
        var result = _greetingService.GreetUser("Vlad", morningTime);
        result.Should().Be("¡Buenas tardes Vlad!");
    }
    
    [Fact]
    public void GreetUser_ReturnsEveningGreeting_WhenEvening()
    {
        var morningTime = new DateTime(2023, 1, 1, 22, 0, 0);
        var result = _greetingService.GreetUser("Vlad", morningTime);
        result.Should().BeEquivalentTo("¡Buenas noches Vlad!");
    }
    
    
    [Fact]
    public void SubstituteGreetUser_ReturnsMorningGreeting_WhenMorning()
    {
        var morningTime = new DateTime(2023, 1, 1, 9, 0, 0);
        var sut = Substitute.For<IGreetingService>();
        sut.GreetUser("Vlad", morningTime).Returns("¡Buenas días Vlad!");
        
        var result = sut.GreetUser("Vlad", morningTime);
        result.Should().Be("¡Buenos días Vlad!");
    }

    [Fact]
    public void SubstituteGreetUser_ReturnsAfternoonGreeting_WhenAfternoon()
    {
        var afternoonTime = new DateTime(2023, 1, 1, 15, 0, 0);
        var sut = Substitute.For<IGreetingService>();
        sut.GreetUser("Vlad", afternoonTime).Returns("¡Buenas tardes Vlad!");
        
        var result = sut.GreetUser("Vlad", afternoonTime);
        result.Should().Be("¡Buenas tardes Vlad!");
    }
    
    [Fact]
    public void SubstituteGreetUser_ReturnsEveningGreeting_WhenEvening()
    {
        var eveningTime = new DateTime(2023, 1, 1, 22, 0, 0);
        var sut = Substitute.For<IGreetingService>();

        sut.GreetUser("Vlad", eveningTime).Returns("¡Buenas noches Vlad!");

        var result = sut.GreetUser("Vlad", eveningTime);
        
        result.Should().BeEquivalentTo("¡Buenas noches Vlad!");
    }
}