using FluentAssertions;
using NSubstitute;
using Ohce.Services;
using Ohce.Services.Interfaces;

namespace OhceTests;

public class ReverseEchoingServiceTests
{
    private ReverseEchoingService _reverseEchoingService;

    public ReverseEchoingServiceTests()
    {
        _reverseEchoingService = new ReverseEchoingService();
    }

    [Fact]
    public void RevertString_ReturnsReversedString_WhenNotPalindrome()
    {
        var result = _reverseEchoingService.RevertString("hello");
        result.Should().Be("olleh");
    }

    [Fact]
    public void RevertString_ReturnsPalindromeMessage_WhenPalindrome()
    {
        var result = _reverseEchoingService.RevertString("radar");
        result.Should().Be("radar\n¡Bonita palabra!");
    }
    
    [Fact]
    public void SubstituteRevertString_ReturnsReversedString_WhenNotPalindrome()
    {
        var reverseEchoingService = Substitute.For<IReverseEchoingService>();
        reverseEchoingService.RevertString("hello").Returns("olleh");
        
        var result = reverseEchoingService.RevertString("hello");
        result.Should().Be("olleh");
    }

    [Fact]
    public void SubstituteRevertString_ReturnsPalindromeMessage_WhenPalindrome()
    {
        var reverseEchoingService = Substitute.For<IReverseEchoingService>();
        reverseEchoingService.RevertString("radar").Returns("radar\n¡Bonita palabra!");

        var result = reverseEchoingService.RevertString("radar");
        result.Should().Be("radar\n¡Bonita palabra!");
    }
}