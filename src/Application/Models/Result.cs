namespace NoteIt.Application.Models;
public class Result
{
    public bool Succeeded { get; set; }
    public string[] Errors { get; set; }

    internal Result(bool secceeded, IEnumerable<string> errors)
        => (Succeeded, Errors) = (secceeded, errors.ToArray());

    public static Result Success()
        => new(true, Array.Empty<string>());

    public static Result Failure(IEnumerable<string> errors)
        => new(false, errors);
}
