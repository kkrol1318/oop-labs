using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Simulation _simulation;
    private readonly Map _map;

    public MapVisualizer(Simulation simulation)
    {
        _simulation = simulation;
        _map = simulation.Map;
    }

    public void Draw()
    {
        Console.Clear();
        DrawTopBorder();
        DrawRows();
        DrawBottomBorder();
        Console.WriteLine();
        DrawCreaturesInfo();
    }

    private void DrawTopBorder()
    {
        Console.Write(Box.TopLeft);

        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < _map.SizeX - 1)
                Console.Write(Box.TopMid);
        }

        Console.Write(Box.TopRight);
        Console.WriteLine();
    }

    private void DrawRows()
    {
        for (int y = _map.SizeY - 1; y >= 0; y--)
        {
            Console.Write(Box.Vertical);

            for (int x = 0; x < _map.SizeX; x++)
            {
                var list = _map.At(x, y).ToList();

                if (list.Count == 0)
                    Console.Write(' ');
                else if (list.Count == 1)
                    Console.Write(list[0].Symbol);
                else
                    Console.Write('X');

                if (x < _map.SizeX - 1)
                    Console.Write(Box.Vertical);
            }

            Console.Write(Box.Vertical);
            Console.WriteLine();

            if (y > 0)
            {
                Console.Write(Box.MidLeft);

                for (int x = 0; x < _map.SizeX; x++)
                {
                    Console.Write(Box.Horizontal);
                    if (x < _map.SizeX - 1)
                        Console.Write(Box.Cross);
                }

                Console.Write(Box.MidRight);
                Console.WriteLine();
            }
        }
    }

    private void DrawBottomBorder()
    {
        Console.Write(Box.BottomLeft);

        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < _map.SizeX - 1)
                Console.Write(Box.BottomMid);
        }

        Console.Write(Box.BottomRight);
        Console.WriteLine();
    }
    private void DrawCreaturesInfo()
    {
        foreach (var c in _simulation.Creatures)
        {
            var pos = _simulation.MapPositionOf(c);
            Console.WriteLine($"{c.GetType().Name.ToUpper()}: {c.Info} at ({pos.X}, {pos.Y})");
        }
    }
}
