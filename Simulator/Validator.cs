namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        string s = value ?? string.Empty;

        s = s.Trim();

        if (s.Length > max)
            s = s[..max].TrimEnd();

        if (s.Length < min)
            s = s.PadRight(min, placeholder);

        return s;
    }
}

