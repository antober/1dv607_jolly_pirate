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

        public string regPassword()
        {
            Console.WriteLine("Enter a password: ");
            string inputPassword = Console.ReadLine();

            return inputPassword;
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