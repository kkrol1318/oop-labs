using Simulator;

namespace SimConsole;

internal class LogVisualizer
{
    private readonly SimulationLog _log;

    public LogVisualizer(SimulationLog log)
    {
        _log = log ?? throw new ArgumentNullException(nameof(log));
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= _log.TurnLogs.Count)
            throw new ArgumentOutOfRangeException(nameof(turnIndex));

        var turn = _log.TurnLogs[turnIndex];

        Console.Clear();

        DrawMap(turn.Symbols);

        Console.WriteLine();
        Console.WriteLine($"Tura: {turnIndex} / {_log.TurnLogs.Count - 1}");

        if (turnIndex == 0)
        {
            Console.WriteLine("Start symulacji");
        }
        else
        {
            Console.WriteLine($"Obiekt: {turn.Mappable}");
            Console.WriteLine($"Ruch: {turn.Move}");
        }
    }

    private void DrawMap(Dictionary<Point, char> symbols)
    {
        int width = _log.SizeX;
        int height = _log.SizeY;

        Console.Write(Box.TopLeft);
        for (int x = 0; x < width; x++)
            Console.Write(Box.Horizontal);
        Console.Write(Box.TopRight);
        Console.WriteLine();

        for (int y = height - 1; y >= 0; y--)
        {
            Console.Write(Box.Vertical);

            for (int x = 0; x < width; x++)
            {
                var p = new Point(x, y);

                if (symbols.TryGetValue(p, out char s))
                    Console.Write(s);
                else
                    Console.Write(' ');
            }

            Console.Write(Box.Vertical);
            Console.WriteLine();
        }

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < width; x++)
            Console.Write(Box.Horizontal);
        Console.Write(Box.BottomRight);
        Console.WriteLine();
    }
}
