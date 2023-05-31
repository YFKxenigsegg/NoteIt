using NoteIt.Infrastructure.Persistence.Helpers.Interfaces;

namespace NoteIt.Infrastructure.Persistence.Helpers;
public class DateTimeHelper : IDateTimeHelper
{
    public DateTime UtcNow => DateTime.UtcNow;
}
