using FluentAssertions;
using Ohce.Services;

namespace OhceTests;

public class DateTimeServiceTests
{
    private DateTimeService _dateTimeService;

    public DateTimeServiceTests()
    {
        _dateTimeService = new DateTimeService();
    }

    [Fact]
    public void Now_ReturnsCurrentDateTime()
    {
        var now = DateTime.Now;
        var result = _dateTimeService.Now;
        result.Date.Should().Be(now.Date);
    }
}