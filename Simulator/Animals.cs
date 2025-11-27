namespace Simulator;

public class Animals
{
    private string _description = "";

    public required string Description
    {
        get => _description;
        init => _description = ValidateDescription(value);
    }

    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";
    private static string ValidateDescription(string? raw)
    {
        string s = raw ?? "Unknown";
        s = s.Trim();

        if (s.Length < 3)
            s = s.PadRight(3, '#');

        if (s.Length > 15)
            s = s[..15].TrimEnd();

        if (s.Length < 3)
            s = s.PadRight(3, '#');

        if (s.Length > 0 && char.IsLetter(s[0]) && char.IsLower(s[0]))
            s = char.ToUpperInvariant(s[0]) + s[1..];

        return s;
    }
}
