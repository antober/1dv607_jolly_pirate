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
        
        The functionality left TODO is:
        1. Change member information.
        2. Change boat information 
        3. Buggfix and validation on input, in some cases.
        */

        static void Main(string[] args)
        {
            Controller c = new Controller();
            c.InitController();
        }
    }
}
