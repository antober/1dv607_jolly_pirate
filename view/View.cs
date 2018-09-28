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
            Console.WriteLine(" 0 - Exit\n 1 - Register\n 2 - BoatAssignment \n 3 - View Members Compact List\n 4 - View Members Verbose List");
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

            Console.WriteLine("Choose a boat type: ");
            Console.WriteLine(" 0 - Kayak/Canoe\n 1 - Motorsailer\n 2 - Salilboat\n 3 - Other");
            // string boatTypeChoise = Console.ReadLine();
            
            // Case enum.

        }
    }
}