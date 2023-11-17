using FluentAssertions;
using Ohce.Services;

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
}