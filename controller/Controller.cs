using System;

namespace jolly_pirate
{
    class Controller
    {
        public void InitMasterController()
        {
            UserDAL userDAL = new UserDAL();
            View view = new View();

            do
            {
                Console.Clear();
                view.StartMenu();
                int input;

                try
                {            
                    if (int.TryParse(Console.ReadLine(), out input) && input >= 0 && input <= 2)
                    {
                        switch (input)
                        {
                            case 0:
                                Console.WriteLine();
                                return;
                            case 1:
                                RegisterModel registerModel = new RegisterModel(userDAL, view);
                                registerModel.TryRegister(view.RegNumber(), view.RegFullName());
                                break;   

                            case 2:

                                Console.WriteLine("Case: {0}",input);
                                // Call login method from LonginController
                                break;
                                
                            case 3:

                                Console.WriteLine("Case: {0}",input);
                                // Call login method from LonginController
                                break;
                            case 4:

                                Console.WriteLine("Case: {0}",input);
                                // Call login method from LonginController
                                break;
                        }
                    }

                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You need to enter a number between 0 and 2!\nPress any key to continue, ESC exits ");
                        Console.ResetColor();
                        }
                    }

                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}