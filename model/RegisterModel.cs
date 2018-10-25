using System;
using System.Collections.Generic;
using System.Linq;

namespace jolly_pirate
{
    class RegisterModel
    {
        private MemberDAL memberDAL;


        public RegisterModel(MemberDAL memberDAL)
        {
            this.memberDAL = memberDAL;
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

        // TODO: SAVE BOATTYPE AND NOT INT.
        // HIDDEN Dependency..boat
        public Boat CreateBoat(Member member, int boatTypeInput, int boatLegthInput) 
        {
            Boat.BoatType boatType = SelectBoatType(boatTypeInput);
            int length = boatLegthInput;
            Boat boat = new Boat(GenerateUniqueID(member.BoatList, b => b.Id), boatType, length);
            return boat;
        }

        // TODO: SAVE BOATTYPE AND NOT INT.
        public void ChangeBoat(Member member, int boatID, int boatTypeInput, int BoatlengthInput)
        {
            int oldBoatID = boatID;
            Boat boatToUpdate = member.BoatList.Find(x => x.Id == oldBoatID);
            int index = member.BoatList.IndexOf(boatToUpdate);
            Boat newboat = CreateBoat(member, boatTypeInput, BoatlengthInput);
            member.BoatList[index] = newboat;
        }

        public Member createMember(string number, string name)
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
                return member;
            }
        }  
    }
}