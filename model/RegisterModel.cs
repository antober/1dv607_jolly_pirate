using System;
using System.Collections.Generic;
using System.Linq;

namespace jolly_pirate
{
    class RegisterModel
    {
        private MemberDAL memberDAL;
        private View view;


        public RegisterModel(MemberDAL mDAL, View view)
        {
            memberDAL = mDAL;
            this.view = view;
        }

        /* Generates new ID by counting the id of the last index.
            Used for both member and boat*/
        public int GenerateUniqueID<T>(List<T> anyList, Func<T,int> getID)
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

        public Boat CreateBoat(Member member) 
        {
            Boat.BoatType boatType = SelectBoatType(view.GetBoatTypes());
            int length = this.view.GetBoatLength();

            Boat boat = new Boat(GenerateUniqueID(member.BoatList, b => b.Id), boatType, length);
            this.view.ShowBoatIsSaved(boat);

            return boat;
        }

        public void ChangeBoat(Member member)
        {
            int oldBoatID = view.ChangeBoatInfoByID();
            Boat boatToUpdate = member.BoatList.Find(x => x.Id == oldBoatID);
            int index = member.BoatList.IndexOf(boatToUpdate);
            // view method
            Console.WriteLine("Enter information about new boat.");

            Boat newboat = CreateBoat(member);
            member.BoatList[index] = newboat;

            this.memberDAL.SaveToFile();
        }

        public void TryRegisterMember(string number, string name)
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
                    Member member = new Member(number, name, GenerateUniqueID(memberDAL.memberList, m => m.Id));
                    memberDAL.AddMember(member);
                    memberDAL.SaveToFile();
                    view.ShowSavedMember(member);
                    view.ShowSuccessMessage();
                }
            }
            catch (Exception e)
            {
                view.ShowRegisterError(e.Message);
            }
        }  
    }
}