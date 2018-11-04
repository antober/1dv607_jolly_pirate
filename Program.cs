using System;

namespace jolly_pirate
{
    class Program
    {

        static void Main(string[] args)
        {
            View v = new View();

            MemberDAL mD = new MemberDAL();
            RegisterModel rm = new RegisterModel(mD);
            Controller controller = new Controller(mD, v, rm);
            while(controller.InitStartMenu()) 
            {
                Console.ReadKey(false);
            };
        }
    }
}
