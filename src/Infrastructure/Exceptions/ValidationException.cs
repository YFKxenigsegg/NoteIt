using FluentValidation.Results;

namespace NoteIt.Infrastructure.Exceptions;
public class ValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    public ValidationException() : base("One or more validation failures occured.")
        => Errors = new Dictionary<string, string[]>();

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        var failuresGroups = failures.GroupBy(x => x.PropertyName, x => x.ErrorMessage);

        foreach (var failuresGroup in failuresGroups)
        {
            var propertyName = failuresGroup.Key;
            var propertyFailures = failuresGroup.ToArray();
            Errors.Add(propertyName, propertyFailures);
        }
    }
}
