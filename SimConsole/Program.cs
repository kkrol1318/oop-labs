using SimConsole;
using Simulator;
using Simulator.Maps;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Wybierz symulację:");
Console.WriteLine("1 – Symulacja 1 (elf + ork)");
Console.WriteLine("2 – Symulacja 2 (zwierzęta i ptaki)");
Console.Write("Twój wybór: ");

string? choice = Console.ReadLine();
Console.Clear();

if (choice == "1")
{
    Sim1();
}
else if (choice == "2")
{
    Sim2();
}
else
{
    Console.WriteLine("Nieprawidłowy wybór.");
    Console.ReadLine();
}

static void Sim1()
{
    SmallSquareMap map = new(5);
    List<IMappable> objects = [new Orc("Gorbag"), new Elf("Elandor")];
    List<Point> points = [new(2, 2), new(3, 1)];
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
}

static void Sim2()
{
    SmallTorusMap map = new(8, 6);

    var elf = new Elf("Elandor");
    var orc = new Orc("Gorbag");

    var rabbits = new Animals
    {
        Description = "Rabbits",
        Size = 5
    };

    var eagles = new Birds
    {
        Description = "Eagles",
        CanFly = true
    };

    var ostriches = new Birds
    {
        Description = "Ostriches",
        CanFly = false
    };

    List<IMappable> objects =
    [
        elf,
        orc,
        rabbits,
        eagles,
        ostriches
    ];

    List<Point> points =
    [
        new(1, 1),
        new(2, 2),
        new(3, 3),
        new(4, 4),
        new(5, 2)
    ];

    string moves = "urdlurdlurdlurdlurdl";

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
}
