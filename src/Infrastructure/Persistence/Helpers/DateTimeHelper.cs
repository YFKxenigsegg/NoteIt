using Note.Infrastructure.Persistence.Helpers.Interfaces;

namespace Note.Infrastructure.Persistence.Helpers;
public class DateTimeHelper : IDateTimeHelper
{
    public DateTime UtcNow => DateTime.UtcNow;
}
