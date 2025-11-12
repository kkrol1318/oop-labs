namespace Simulator
{
    public static class DirectionParser
    {
        public static Direction[] Parse(string? pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                return Array.Empty<Direction>();

            List<Direction> directions = new();

            foreach (char ch in pattern)
            {
                switch (char.ToUpperInvariant(ch))
                {
                    case 'U': directions.Add(Direction.Up); break;
                    case 'R': directions.Add(Direction.Right); break;
                    case 'D': directions.Add(Direction.Down); break;
                    case 'L': directions.Add(Direction.Left); break;
                    default: break;
                }
            }

            return directions.ToArray();
        }
    }
}
