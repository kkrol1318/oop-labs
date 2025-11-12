namespace Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator!\n");
            Creature shrek = new("Shrek", 5);
            shrek.SayHi();
            Console.WriteLine(shrek.Info);

            Animals dogs = new() { Description = "Dogs" };
            Console.WriteLine(dogs.Info);

        }
    }
}
