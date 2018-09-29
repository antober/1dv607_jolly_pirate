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
            UserDAL userDAL = new UserDAL ();
            View view = new View ();

            do {
                Console.Clear ();
                view.StartMenu ();
                int input;

                try {
                    if (int.TryParse (Console.ReadLine (), out input) && input >= 0 && input <= 2) {
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

        // public void TryRegister (string number, string name) {
        //     try {
        //         // Console.Write(numberOfDigits);
        //         if (number.Length != 10) {
        //             throw new Exception ("Social number must contain 10 digits!");
        //         }
        //         if (name.Length < 3) {
        //             throw new Exception ("Full name must have atleast 3 characters");
        //         } else {
        //             User user = new User (number, name, GenerateID ());
        //             this.userDAL.addUser(user);
        //             this.userDAL.saveToFile();
        //             this.view.RegSuccess ();

        //         }
        //     } catch (Exception e) {
        //         Console.WriteLine (e.Message);
        //     }
        // }

        private int GenerateID () {
            if (this.userDAL.userInfo.Count == 0) {
                return 1;
            } else {
                int indexOfLast = this.userDAL.userInfo.Count - 1;
                return this.userDAL.userInfo[indexOfLast].id + 1;
            }
        }

        // UNDER CONSTUCTION !!!
        public User findUserByID (int id) {

            var member = this.userDAL.userInfo.Find(x => x.id == id);
            if (member == null) {
                throw new ArgumentException("No user with the gives ID.");
            } else {
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

        public Boat.BoatType SelectBoatType (int input) {
            //var b = new Boat(Boat.BoatType.Kayak_or_Canoe, 50, "Yasmins Skinkor");
           switch (input)
           {
               case 1: return Boat.BoatType.Kayak_or_Canoe;
               case 2: return Boat.BoatType.Motorsailer;
               case 3: return Boat.BoatType.Sailboat;
               case 4: return Boat.BoatType.Other;
               default: throw new ArgumentException("Gandalf: YOUU SHALL NOT SAIL");
           }
        }

    }
    
}