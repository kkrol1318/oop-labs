using Simulator.Maps;

namespace Simulator;

public class SimulationLog
{
    private readonly Simulation _simulation;

    public int SizeX { get; }
    public int SizeY { get; }

    public List<TurnLog> TurnLogs { get; } = [];

    public SimulationLog(Simulation simulation)
    {
        _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;

        Run();
    }

    private void Run()
    {
        TurnLogs.Add(new TurnLog
        {
            Mappable = "(start)",
            Move = "",
            Symbols = CaptureSymbols()
        });

        while (!_simulation.Finished)
        {
            string mappableText = _simulation.CurrentObject.ToString();
            string moveText = _simulation.CurrentMoveName;

            _simulation.Turn();

            TurnLogs.Add(new TurnLog
            {
                Mappable = mappableText,
                Move = moveText,
                Symbols = CaptureSymbols()
            });
        }
    }

    private Dictionary<Point, char> CaptureSymbols()
    {
        Dictionary<Point, char> result = new();

        for (int y = 0; y < SizeY; y++)
        {
            for (int x = 0; x < SizeX; x++)
            {
                var list = _simulation.Map.At(x, y).ToList();

                if (list.Count == 0) continue;

                if (list.Count == 1)
                    result[new Point(x, y)] = list[0].Symbol;
                else
                    result[new Point(x, y)] = 'X';
            }
        }

        return result;
    }
}

public class TurnLog
{
    public required string Mappable { get; init; }

    public required string Move { get; init; }

    public required Dictionary<Point, char> Symbols { get; init; }
}
