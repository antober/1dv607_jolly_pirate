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
                    Member member = new Member(number, name, GenerateID(_memberDAL.memberList, m => m.Id));
                    this._memberDAL.AddMember(member);
                    this._memberDAL.SaveToFile();
                    this._view.MemberIsSaved(member);
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
        private int GenerateID<T>(List<T> anyList, Func<T,int> getID)
        {
            if(anyList.Count() == 0) 
            {
               return 1;
            } 
            else 
            {
                int indexOfLast = anyList.Count() - 1;
                return getID(anyList[indexOfLast]) + 1;
            }
        }
          
        private Boat.BoatType SelectBoatType(int input) 
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

        private Boat CreateBoat(Member member) 
        {
            Boat.BoatType boatType = SelectBoatType(this._view.BoatTypes());
            int length = this._view.BoatLength();

            Boat boat = new Boat(GenerateID(member.BoatList, b => b.Id), boatType, length);
            this._view.BoatIsSaved(boat);

            return boat;
        }

        private void AddBoat()
        {
            //  TODO: get value from view in another way. this way renders the string.
            int memberID = this._view.SelectMemberWithID();
            Member owner = _memberDAL.GetMemberByID(memberID);
            owner.BoatList.Add(CreateBoat(owner));
        }

        private void ChangeBoat(Member member)
        {
            int oldBoatID = _view.ChangeBoatInfoByID();
            Boat boatToUpdate = member.BoatList.Find(x => x.Id == oldBoatID);
            int index = member.BoatList.IndexOf(boatToUpdate);

            Console.WriteLine("Enter information about new boat.");

            Boat newboat = CreateBoat(member);
            member.BoatList[index] = newboat;

            this._memberDAL.SaveToFile();
        }

        //This is a Controller method and should be moved.
        public void MemberMenuController(Member member)
        {
            int memberMenuInput;

            try 
            {
                if (int.TryParse(Console.ReadLine(), out memberMenuInput) && memberMenuInput >= 0 && memberMenuInput <= 5) 
                {
                    switch (memberMenuInput) 
                    {
                        case 0: 
                            return;
                        case 1:
                            this.AddBoat();
                            this._memberDAL.SaveToFile();
                            break;

                        case 2:
                            //Find a way to refer to the current user by comparing the actual object instead
                            //of comparing a manual input with id.
                            //Defferent boats can have the same id.
                            _view.ShowBoatList(member.BoatList);
                            ChangeBoat(member);
                            break;

                        case 3:
                            //TODO : let view return values from Readline
                            // member.ToString();
                            _view.ShowBoatList(member.BoatList);
                            int boatID = _view.DeleteBoatByID();
                            member.DeleteBoat(boatID);
                            this._memberDAL.SaveToFile();

                            break;
                        case 4:
                            // Change member info
                            break;
                        case 5:
                            this._memberDAL.DeleteMember(_view.DeleteMember());
                            this._memberDAL.SaveToFile();    
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