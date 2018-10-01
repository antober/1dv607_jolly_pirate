using System;
using System.Collections.Generic;

namespace jolly_pirate
{
    class User
    {
        public string SSN;
        public string fullName;
        public int id;

        public List<Boat> boatList;

        public User(string socialSecurityNumber, string fullName, int id)
        {
            this.SSN = socialSecurityNumber;
            this.fullName = fullName;
            this.id = id;
            this.boatList = new List<Boat>();
        }


        public void getBoatList()
        {
            foreach (Boat boat in this.boatList)
            {
                Console.WriteLine("{0}" + "{1}",boatList.IndexOf(boat), boat);
            }
        }

        public void AddBoat(Boat boat)
        {
            this.boatList.Add(boat);
        }

        public void ChangeBoat()
        {
            throw new Exception();
        }

        public void DeleteBoat(int boatIndex)
        {
            this.boatList.RemoveAt(boatIndex);
        }

        public void ChangeMemberInfo()
        {
            throw new Exception();
        }

        public void DeleteMember()
        {
            throw new Exception();
        }
    }
}