using System;
using System.Collections.Generic;
using System.IO;

namespace jolly_pirate
{
    
    class UserDAL
    {
        public void add(User user)
        {
            //System.Console.WriteLine(user.getSocialSecurityNumber());
            using (StreamWriter streamWriter = File.AppendText("users.txt"))
            {
                streamWriter.WriteLine(user.getSocialSecurityNumber());
            }
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You are successfully registered!");
            Console.ResetColor();
            System.Console.WriteLine("Press Enter to return to previous menu");
        }
    }
}   