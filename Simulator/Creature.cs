namespace Simulator
{
    public class Creature
    {
        private string _name = "Unknown";
        private int _level = 1;

        public string Name
        {
            get => _name;
            init => _name = ValidateName(value);
        }

        public int Level
        {
            get => _level;
            init => _level = ValidateLevel(value);
        }

        public string Info => $"{Name} <{Level}>";

        public Creature() { }

        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }

        public void SayHi()
        {
            Console.WriteLine($"Hi! I'm {Name} at level {Level}.");
        }

        public void Upgrade()
        {
            if (_level < 10) _level++;
        }

        private static string ValidateName(string? raw)
        {
            string s = raw ?? "Unknown";
            s = s.Trim();

            if (s.Length < 3)
                s = s.PadRight(3, '#');

            if (s.Length > 25)
                s = s[..25].TrimEnd();

            if (s.Length < 3)
                s = s.PadRight(3, '#');

            if (s.Length > 0 && char.IsLetter(s[0]) && char.IsLower(s[0]))
                s = char.ToUpperInvariant(s[0]) + s[1..];

            return s;
        }

        private static int ValidateLevel(int value)
        {
            if (value < 1) return 1;
            if (value > 10) return 10;
            return value;
        }
    }
}
