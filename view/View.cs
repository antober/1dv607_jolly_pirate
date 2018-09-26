using System;

namespace jolly_pirate
{
    class View
    {
        public void startMenu()
        {
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                ║");
            Console.WriteLine("║             Jolly Pirate Boat Club             ║");
            Console.WriteLine("║                                                ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine(" 0 - Exit\n 1 - Register\n 2 - View Members List");
            Console.WriteLine("==================================================");
            Console.Write("Enter your choice [0-2]: ");
        }
    }
}