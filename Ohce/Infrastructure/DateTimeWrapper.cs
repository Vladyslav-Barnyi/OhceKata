using Ohce.Infrastructure.Interface;

namespace Ohce.Infrastructure;

public class DateTimeWrapper : IDateTimeWrapper
{
    public DateTime Now => DateTime.Now;
}