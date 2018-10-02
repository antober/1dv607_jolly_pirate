using System;
using System.Collections.Generic;
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
                    Member member = new Member(number, name, GenerateID(_memberDAL.memberList, m => m.id));
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

        /* Generates new ID by counting the id of the last index.
            Used for bort member and boat*/
        private int GenerateID<T>(List<T> aList, Func<T,int> getID)
        {

            if(aList.Count() == 0) 
            {
               return 1;
            } 
            else 
            {
            int indexOfLast = aList.Count() - 1;
            return getID(aList[indexOfLast]) + 1;
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
        /* Under construction: Should take both 
            MemberList and BoatList */
        // public void DeleteByID<T>(List<T> aList, Func<T,int> getID)
        // {
        //     var item = aList.SingleOrDefault(x => x = ?);
        //     if (item != null)
        //     aList.Remove(item);
        //     // SELECT MEMBER WHERE ID : get index 
        // }

        // TODO: Validating input."
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

        public Boat CreateBoat(Member member) 
        {
            Boat.BoatType boatType = SelectBoatType(this._view.BoatTypes());
            int length = this._view.BoatLength();

            Boat boat = new Boat(GenerateID(member.boatList, b => b.id), boatType, length);
            System.Console.WriteLine("Saved:");
            System.Console.Write("type:  " + boat.boatType + " | ");
            System.Console.Write("length:  " + boat.length + " | ");
            System.Console.Write("id:  " + boat.id);

            return boat;
        }

        public void AddBoat()
        {

            int memberID = this._view.SelectMemberWirthID();
            Member owner = this._memberDAL.memberList.Find(x => x.id == memberID);
             owner.boatList.Add(CreateBoat(owner));
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
                            // Console.WriteLine();
                            return;
                        case 1:
                    
                            this.AddBoat();
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
                            this._memberDAL.DeleteMember(_view.DeleteMember());
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