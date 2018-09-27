using System;

namespace jolly_pirate
{
    class View
    {
        public void StartMenu()
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

        public string RegNumber()
        {
            Console.WriteLine("Enter Social security number: "); 
            string inputNumber = Console.ReadLine();

            return inputNumber;
        }

        public string RegFullName()
        {
            Console.WriteLine("Enter fullname: ");
            string inputName = Console.ReadLine();

            return inputName;
        }
        public void RegSuccess()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You are successfully registered!");
            Console.ResetColor();
            System.Console.WriteLine("Press Enter to return to previous menu");
        }

        public string BoatName()
        {
            Console.WriteLine("Enter boat name: ");
            string boatName = Console.ReadLine();

            return boatName;
        }

        public void BoatType()
        {
            Console.WriteLine("Enter boat name: ");
        }
    }
}