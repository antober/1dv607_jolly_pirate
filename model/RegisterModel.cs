using System;
using System.Collections.Generic;
using System.Linq;

namespace jolly_pirate
{
    class RegisterModel
    {
        private MemberDAL memberDAL;
        private Boat boat;
        private Member member;

        private static int MEMBERNAME_MINLENGTH = 3;
        private static int MEMBERNAME_MAXLENGTH = 16;
        private static int SSN_LENGTH = 10;

        private static int DEFAULT_ID = 1;

        public RegisterModel(MemberDAL memberDAL)
        {
            this.memberDAL = memberDAL;
        }

        /* Generates new ID by counting the id of the last index.
            Used for both member and boat*/
        public int GenerateUniqueID<T>(List<T> anyList, Func<T,int> getID)
        {
            if(!anyList.Any()) 
            {
               return DEFAULT_ID;
            } 
            else 
            {
                int indexOfLast = anyList.Count() - DEFAULT_ID;
                return getID(anyList[indexOfLast]) + DEFAULT_ID;
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
                default: throw new ArgumentOutOfRangeException("Invalid input.");
            }
        }

        public Boat CreateBoat(Member member, int boatTypeInput, int boatLegthInput) 
        {
            Boat.BoatType boatType = SelectBoatType(boatTypeInput);
            int length = boatLegthInput;
            Boat boat = new Boat(GenerateUniqueID(member.BoatList, b => b.Id), boatType, length);
            return boat;
        }

        public void ChangeBoat(Member member, int boatID, int boatTypeInput, int BoatlengthInput)
        {
            int oldBoatID = boatID;
            Boat boatToUpdate = member.BoatList.Find(x => x.Id == oldBoatID);
            int index = member.BoatList.IndexOf(boatToUpdate);
            Boat newboat = CreateBoat(member, boatTypeInput, BoatlengthInput);
            member.BoatList[index] = newboat;
        }

        public Member CreateMember(string SSN, string memberName)
        {
            if(SSN.Length != SSN_LENGTH)
            {
                throw new ArgumentOutOfRangeException("Social number must contain 10 digits!");
            }
            if(memberName.Length < MEMBERNAME_MINLENGTH || memberName.Length > MEMBERNAME_MAXLENGTH)
            {
                throw new ArgumentOutOfRangeException("Full name must be between 3-16 characters long.");
            }
            else
            {
                Member member = new Member(SSN, memberName, GenerateUniqueID(memberDAL.memberList, m => m.Id));
                memberDAL.AddMember(member);
                return member;
            }
        }  
    }
}