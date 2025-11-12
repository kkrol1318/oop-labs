namespace Simulator
{
    public class Creature
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public Creature()
        {
            // bezparametrowy konstruktor - nic nie robi
        }

        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }

        public void SayHi()
        {
            Console.WriteLine($"Hi! I'm {Name} at level {Level}.");
        }

        public string Info => $"{Name} <{Level}>";
    }
}
