using Simulator;
using Simulator.Maps;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Animals dogs = new() { Description = "Dogs" };
        Console.WriteLine(dogs.Info);

        Console.WriteLine();
        TestElfsAndOrcs();

        Console.WriteLine();
        TestValidators();

        Console.WriteLine();
        TestObjectsToString();

        Console.WriteLine("\nEND");


        Point p = new(10, 25);

        Console.WriteLine(p.Next(Direction.Right));         // (11, 25)
        Console.WriteLine(p.NextDiagonal(Direction.Right)); // (11, 24)
        Console.WriteLine(p.Next(Direction.Up));            // (10, 24)
        Console.WriteLine(p.NextDiagonal(Direction.Up));    // (11, 24)


        var map = new SmallSquareMap(5);

        Point p2 = new(0, 0);

        Console.WriteLine(map.Next(p2, Direction.Left));   // (0,0)
        Console.WriteLine(map.Next(p2, Direction.Up));     // (0,0)
        Console.WriteLine(map.Next(p2, Direction.Right));  // (1,0)
        Console.WriteLine(map.Next(p2, Direction.Down));   // (0,1)

        Console.WriteLine(map.Exist(new Point(4, 4)));    // True
        Console.WriteLine(map.Exist(new Point(10, 10)));  // False

    }

    static void TestElfsAndOrcs()
    {
        Console.WriteLine("HUNT TEST\n");

        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        Console.WriteLine(o.Greeting());
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            Console.WriteLine(o.Greeting());
        }

        Console.WriteLine("\nSING TEST\n");

        var e = new Elf("Legolas", agility: 2);
        Console.WriteLine(e.Greeting());
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            Console.WriteLine(e.Greeting());
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
            o,
            e,
            new Orc("Morgash", 3, 8),
            new Elf("Elandor", 5, 3)
        };

        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }

    static void TestValidators()
    {
        Console.WriteLine("\nVALIDATORS TEST\n");

        Elf c = new() { Name = "   Shrek    ", Level = 20, Agility = 0 };
        Console.WriteLine(c.Greeting());
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Elf("  ", -5, 0);
        Console.WriteLine(c.Greeting());
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Elf("  donkey ") { Level = 7, Agility = 0 };
        Console.WriteLine(c.Greeting());
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Elf("Puss in Boots – a clever and brave cat.");
        Console.WriteLine(c.Greeting());
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Elf("a                            troll name", 5);
        Console.WriteLine(c.Greeting());
        c.Upgrade();
        Console.WriteLine(c.Info);

        var a = new Animals() { Description = "   Cats " };
        Console.WriteLine(a.Info);

        a = new() { Description = "Mice           are great", Size = 40 };
        Console.WriteLine(a.Info);
    }

    static void TestObjectsToString()
    {
        object[] myObjects = {
            new Animals() { Description = "dogs"},
            new Birds { Description = "  eagles ", Size = 10 },
            new Elf("e", 15, -3),
            new Orc("morgash", 6, 4)
        };

        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects)
            Console.WriteLine(o);
    }
}
