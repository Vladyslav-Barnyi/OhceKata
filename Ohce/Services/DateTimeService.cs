using Ohce.Services.Interfaces;

namespace Ohce.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
}