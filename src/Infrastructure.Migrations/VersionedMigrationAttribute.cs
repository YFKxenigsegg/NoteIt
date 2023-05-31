using FluentMigrator;

namespace NoteIt.Infrastructure.Migrations;
[AttributeUsage(AttributeTargets.Class)]
public class VersionedMigrationAttribute : MigrationAttribute
{
    public VersionedMigrationAttribute(int major, int minor, int patch, int number, string description)
        : base(CalculateValue(major, minor, patch, number), description) { }

    private static long CalculateValue(int major, int minor, int patch, int number)
    {
        return 100000000000L
             + major * 100000000L
             + minor * 1000000L
             + patch * 10000L
             + number * 100L;
    }
}
