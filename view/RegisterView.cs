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
    }
}