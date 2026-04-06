using System.Text.RegularExpressions;

try
{
    Environment.Exit(Run(args));
}
catch (ArgumentException ex)
{
    Console.Error.WriteLine(ex.Message);
    Console.Error.WriteLine();
    Console.Error.WriteLine(Usage());
    Environment.Exit(2);
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex.Message);
    Environment.Exit(1);
}

static int Run(string[] args)
{
    return args switch
    {
        [] => throw new ArgumentException("Missing arguments."),
        ["--message"] => throw new ArgumentException("Missing value for --message."),
        ["--message", .. var messageParts] => ValidateSingle(string.Join(' ', messageParts)),
        [var first, ..] when first == "--file" && args.Length != 2 => throw new ArgumentException("Usage for --file: --file <commit-message-file>"),
        ["--file", var filePath] => ValidateSingle(File.ReadAllText(filePath)),
        [var filePath] when !filePath.StartsWith("--", StringComparison.Ordinal) => ValidateSingle(File.ReadAllText(filePath)),
        _ when args.Any(arg => arg.StartsWith("--", StringComparison.Ordinal)) => throw new ArgumentException($"Unknown or invalid flags: {string.Join(' ', args)}"),
        _ => throw new ArgumentException("Invalid arguments.")
    };
}

static int ValidateSingle(string message)
{
    var (ok, result) = CommitMessageValidator.Validate(message);
    if (!ok)
    {
        Console.Error.WriteLine(result);
        return 1;
    }

    Console.WriteLine(result);
    return 0;
}

static string Usage() =>
    "Usage:\n" +
    "  dotnet run --file tools/commitlint.cs -- --message \"feat(scope): subject\"\n" +
    "  dotnet run --file tools/commitlint.cs -- <commit-message-file>";

static class CommitMessageValidator
{
    private static readonly HashSet<string> AllowedTypes =
    [
        "build",
        "chore",
        "ci",
        "docs",
        "feat",
        "fix",
        "perf",
        "refactor",
        "revert",
        "style",
        "test"
    ];

    private static readonly Regex HeaderRegex = new(
        "^(?<type>[a-z]+)(\\((?<scope>[a-z0-9._/-]+)\\))?(?<breaking>!)?: (?<subject>.+)$",
        RegexOptions.Compiled);

    public static (bool Ok, string Message) Validate(string rawMessage)
    {
        if (string.IsNullOrWhiteSpace(rawMessage))
        {
            return (false, "Commit message is empty.");
        }

        var firstLine = rawMessage.Replace("\r\n", "\n").Split('\n', 2)[0].Trim();

        if (string.IsNullOrWhiteSpace(firstLine))
        {
            return (false, "Commit message header is empty.");
        }

        if (firstLine.StartsWith("Merge ", StringComparison.Ordinal) ||
            firstLine.StartsWith("fixup! ", StringComparison.Ordinal) ||
            firstLine.StartsWith("squash! ", StringComparison.Ordinal))
        {
            return (true, "Commit message accepted (merge/fixup/squash commit).");
        }

        var match = HeaderRegex.Match(firstLine);
        if (!match.Success)
        {
            return (false,
                "Invalid commit header. Expected: type(scope?): subject\n" +
                "Example: feat(player): add jump buffering");
        }

        var type = match.Groups["type"].Value;
        if (!AllowedTypes.Contains(type))
        {
            return (false,
                $"Invalid commit type '{type}'. Allowed types: {string.Join(", ", AllowedTypes.OrderBy(x => x))}");
        }

        var subject = match.Groups["subject"].Value.Trim();
        if (subject.Length < 3)
        {
            return (false, "Commit subject must be at least 3 characters long.");
        }

        if (subject.EndsWith(".", StringComparison.Ordinal))
        {
            return (false, "Commit subject should not end with a period.");
        }

        return (true, "Commit message follows Conventional Commits.");
    }
}
