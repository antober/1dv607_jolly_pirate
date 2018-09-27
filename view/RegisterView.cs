using System;

namespace jolly_pirate
{
    class RegisterView
    {
        public string RegNumber()
        {
            Console.WriteLine("Enter Social security number: "); 
            string inputNumber = Console.ReadLine();

            return inputNumber;
        }

        public string regFullName()
        {
            Console.WriteLine("Enter fullname: ");
            string inputName = Console.ReadLine();

            return inputName;
        }
        public void regSuccess()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You are successfully registered!");
            Console.ResetColor();
            System.Console.WriteLine("Press Enter to return to previous menu");
        }
    }
}