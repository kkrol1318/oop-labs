using SimConsole;
using Simulator;
using Simulator.Maps;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

SmallSquareMap map = new(5);

List<IMappable> objects =
[
    new Orc("Gorbag"),
    new Elf("Elandor")
];

List<Point> points =
[
    new(2, 2),
    new(3, 1)
];

string moves = "dlrludl";

Simulation simulation = new(map, objects, points, moves);

MapVisualizer visualizer = new(simulation);

visualizer.Draw();
Console.WriteLine("Wciśnij ENTER aby rozpocząć...");
Console.ReadLine();

while (!simulation.Finished)
{
    simulation.Turn();
    visualizer.Draw();
    Thread.Sleep(500);
}

Console.WriteLine("Koniec symulacji!");
Console.ReadLine();
