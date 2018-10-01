using System;
using System.Linq;

namespace jolly_pirate
{
    class RegisterModel
    {
        private MemberDAL _memberDAL;
        private View _view;


        public RegisterModel(MemberDAL mDAL, View view)
        {
            this._memberDAL = mDAL;
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
                    Member member = new Member(number, name, GenerateID());
                    this._memberDAL.AddMember(member);
                    this._memberDAL.SaveToFile();
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
            if(this._memberDAL.memberList.Count == 0) 
            {
               return 1;
            } 
            else 
            {
            int indexOfLast = this._memberDAL.memberList.Count - 1;
            return this._memberDAL.memberList[indexOfLast].id + 1;
            }
        }

        // TODO: Göra om, DELA upp metoden.
          public void FindMemberByID (int id) 
        {
            Member member = this._memberDAL.memberList.Find(x => x.id == id);

            if (member == null)
            {
                throw new ArgumentException ("No member with the gives ID.");
            } 
            else 
            {
                _view.MemberMenu();
                this.MemberMenuController(member);
            }
        }  

        // TODO: Validering för "Invalid input"
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
            System.Console.Write(boat.boatName + " | ");
            System.Console.Write(boat.boatType + " | ");
            System.Console.Write(boat.boatLength);

            return boat;
        }

        public void addaboattomember()
        {

            int memberID = this._view.SelectMemberWirthID();
            var owner = this._memberDAL.memberList.Where(x => x.id == memberID);
            
        }
        public void MemberMenuController(Member member)
        {
            int memberMenuInput;

            try 
            {
                if (int.TryParse (Console.ReadLine(), out memberMenuInput) && memberMenuInput >= 0 && memberMenuInput <= 5) 
                {
                    switch (memberMenuInput) 
                    {
                        case 0: 
                            Console.WriteLine();
                            return;
                        case 1:
                            member.AddBoat(CreateBoat());
                            
                            //Remove this temporary writeline.
                            foreach (Boat boat in member.boatList)
                            {
                                Console.WriteLine(boat.boatName, boat.boatType, boat.boatLength);  
                                //TODO: saved to file.
                            }
                                this._memberDAL.SaveToFile();
                            break;

                        case 2:
                            
                            break;

                        case 3:
                            //Extract to separate method?
                            member.getBoatList();
                            int removeBoatInput;
                            int.TryParse(Console.ReadLine(), out removeBoatInput);
                            member.DeleteBoat(removeBoatInput);
                            // TODO: save to file.

                            break;
                        case 4:

                            
                            break;
                        case 5:
                            _memberDAL.DeleteMember(_view.DeleteMember());
                            _memberDAL.SaveToFile();
                            
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