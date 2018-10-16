using System;

namespace jolly_pirate
{
    class Program
    {

        /* 

        The program works about 80%, its possible to:
        1. Register a member 
        2. Save a member.
        3. Delete a member.
        4. Create a boat.
        5. Delete a boat.
        6. Change a boats information.
        7. Change a members information.
        
        The functionality left TODO is:
        1. Full validation.

        */

        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.InitStartMenu();
        }
    }
}
