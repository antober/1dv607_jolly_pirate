using System;

namespace jolly_pirate
{
    class RegisterModel
    {
        private UserDAL _userDAL;
        private View _view;

        public RegisterModel(UserDAL uDAL, View view)
        {
            this._userDAL = uDAL;
            this._view = view;
        }
        public void TryRegister(string number, string name)
        {
            try
            {
                // Console.Write(numberOfDigits);

                if(number.Length != 10)
                {
                    throw new Exception("Social number must contain 10 digits!");
                }

                if(name.Length < 3)
                {
                    throw new Exception("Full name must have atleast 3 characters");
                }
                
                else
                {
                    User user = new User(number, name, GenerateID());
                    this._userDAL.AddUser(user);
                    this._userDAL.SaveToFile();
                    this._view.RegSuccess();
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private int GenerateID()
        {
            if(this._userDAL.userInfo.Count == 0) 
            {
               return 1;
            } 
            else 
            {
            int indexOfLast = this._userDAL.userInfo.Count - 1;
            return this._userDAL.userInfo[indexOfLast].id + 1;
            }
        }

        public Boat.BoatType SelectBoatType(int input) 
        {
            switch (input)
            {
                case 0: return Boat.BoatType.Kayak_or_Canoe;
                case 1: return Boat.BoatType.Motorsailer;
                case 2: return Boat.BoatType.Sailboat;
                case 3: return Boat.BoatType.Other;
                default: throw new Exception("Invalid input.");
            }
        }

        public Boat CreateBoat() 
        {
            string name = this._view.BoatName();
            Boat.BoatType boatType = SelectBoatType(this._view.BoatTypes());
            int length = this._view.BoatLength();

            Boat boat = new Boat(name, boatType, length);
            System.Console.WriteLine(boat.boatName);
            System.Console.WriteLine(boat.boatType);
            System.Console.WriteLine(boat.boatLength);

            return boat;
        }

        public void UserMenu(User user)
        {
            int input;

            try 
            {
                if (int.TryParse (Console.ReadLine (), out input) && input >= 0 && input <= 5) 
                {
                    switch (input) 
                    {
                        case 0: 
                            Console.WriteLine();
                            return;
                        case 1:
                            user.AddBoat(CreateBoat());
                            
                            foreach (Boat boat in user.boatList)
                            {
                                Console.WriteLine(boat.boatName, boat.boatType, boat.boatLength);  
                                //TODO: needs to be saved to file.
                            }
                            break;

                        case 2:
                            
                            break;

                        case 3:
                            
                            break;
                        case 4:

                            
                            break;
                        case 5:

                            
                            break;
                    }
                } 
                else 
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine ("You need to enter a number between 0 and 5!\nPress any key to continue, ESC exits ");
                    Console.ResetColor();
                }
            } 
            catch (Exception e) 
            {
                Console.WriteLine ("{0} Exception caught.", e);
            }
        }  
    }
}