using System;
using System.Collections.Generic;
using System.Linq;

namespace jolly_pirate {
    class Controller {

        MemberDAL memberDAL;
        View view;

        RegisterModel registerModel;

        public Controller () {
            this.memberDAL = new MemberDAL();
            this.view = new View();
            this.registerModel = new RegisterModel(memberDAL, view);
        }
        public void InitMasterController () 
        {
            do 
            {
                Console.Clear();
                view.StartMenu();
                int input;

                try 
                {
                    if (int.TryParse(Console.ReadLine(), out input) && input >= 0 && input <= 4) 
                    {
                        switch (input) 
                        {
                            case 0: 
                                return;
                            case 1:
                                registerModel.TryRegister(view.RegNumber(), view.RegFullName());
                                break;
                            case 2:
                                this.registerModel.FindMemberByID(view.SelectMemberWirthID());
                                break;

                            case 3:
                                memberDAL.CompactListOfMembers();
                                break;
                            case 4:
                                memberDAL.VerboseListOfMembers();
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
                    Console.WriteLine ("{0} Exception caught.", e);
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}