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
        string baseValue = string.IsNullOrWhiteSpace(raw) ? "Unknown" : raw;

        string s = Validator.Shortener(baseValue, min: 3, max: 15, placeholder: '#');

        if (s.Length > 0 && char.IsLetter(s[0]) && char.IsLower(s[0]))
            s = char.ToUpperInvariant(s[0]) + s[1..];

        return s;
    }

}
