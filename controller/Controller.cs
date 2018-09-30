using System;
using System.Collections.Generic;
using System.Linq;

namespace jolly_pirate {
    class Controller {

        UserDAL userDAL;
        View view;

        public Controller () {
            this.userDAL = new UserDAL ();
            this.view = new View ();
        }
        public void InitMasterController () {

            // Just for testing methods:
            // userDAL.compactListOfMembers();
            // userDAL.verboseListOfMembers();


            do {
                Console.Clear ();
                view.StartMenu ();
                int input;

                try {
                    if (int.TryParse (Console.ReadLine (), out input) && input >= 0 && input <= 4) {
                        switch (input) {
                            case 0: 
                                     Console.WriteLine (); 
                                     return;
                            case 1:
                                RegisterModel registerModel = new RegisterModel(userDAL, view);
                                registerModel.TryRegister(view.RegNumber(), view.RegFullName());
                                // this.TryRegister (view.RegNumber (), view.RegFullName ());
                                break;

                            case 2:
                                /// BoatAssignment
                                this.findUserByID(view.SelectMemberWirthID());
                                /// Call login method from LonginController
                                break;

                            case 3:

                                Console.WriteLine ("Case: {0}", input);
                                // Call login method from LonginController
                                break;
                            case 4:

                                Console.WriteLine ("Case: {0}", input);
                                // Call login method from LonginController
                                break;
                        }
                    } else {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine ("You need to enter a number between 0 and 2!\nPress any key to continue, ESC exits ");
                        Console.ResetColor();
                    }
                } catch (Exception e) {
                    Console.WriteLine ("{0} Exception caught.", e);
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private int GenerateID () 
        {
            if (this.userDAL.userInfo.Count == 0) 
            {
                return 1;
            } 
            else 
            {
                int indexOfLast = this.userDAL.userInfo.Count - 1;
                return this.userDAL.userInfo[indexOfLast].id + 1;
            }
        }

        // UNDER CONSTUCTION !!!
        public User findUserByID (int id) 
        {

            var member = this.userDAL.userInfo.Find (x => x.id == id);

            if (member == null) 
            {
                throw new ArgumentException ("No user with the gives ID.");
            } 
            else 
            {
                view.MemberMenu();
                return member;
            }
        }

        /*  1. Välj lägg till båt i Vy
            2. Fyll i information till båtobjektet
            3. Ta inputvärden till skapa-båt-objekt
            4. Kör addBoat i user
            5. Spara till filen.
        */
    }
}