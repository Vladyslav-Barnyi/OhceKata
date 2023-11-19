using FluentAssertions;
using NSubstitute;
using Ohce.Services.Interfaces;

namespace OhceTests;

public class DateTimeServiceTests
{
    private IDateTimeService _dateTimeService = Substitute.For<IDateTimeService>();
    
    [Fact]
    public void Now_ReturnsCurrentDateTime()
    {
        var now = DateTime.Now;

        _dateTimeService.Now.Returns(DateTime.Now);
        var result = _dateTimeService.Now;
        
        result.Date.Should().Be(now.Date);
    }
}