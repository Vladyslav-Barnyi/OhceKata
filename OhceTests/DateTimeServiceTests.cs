using FluentAssertions;
using NSubstitute;
using Ohce.Infrastructure.Interface;
using Ohce.Services;
using Ohce.Services.Interfaces;

namespace OhceTests;

public class DateTimeServiceTests
{
    private IDateTimeWrapper _dateTimeWrapper = Substitute.For<IDateTimeWrapper>();
    
    [Fact]
    public void SubstituteNow_ReturnsCurrentDateTime()
    {
        var now = DateTime.Now.Date;

        _dateTimeWrapper.Now.Returns(DateTime.Now);
        var result = _dateTimeWrapper.Now;
        
        result.Date.Should().Be(now);
    }
}