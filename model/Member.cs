using System;
using System.Collections.Generic;
using System.Linq;

namespace jolly_pirate
{
    class Member
    {
        public string ssn;
        public string fullName;
        public int id;

        public List<Boat> boatList;

        public Member(string socialSecurityNumber, string fullName, int id)
        {
            this.ssn = socialSecurityNumber;
            this.fullName = fullName;
            this.id = id;
            this.boatList = new List<Boat>();
        }


        public void getBoatList()
        {
            foreach (Boat boat in this.boatList)
            {
                Console.Write(" {0} - " + "Id: {1} " + "Type: {2} " + "Length: {3}\n",
                boatList.IndexOf(boat), boat.id, boat.boatType, boat.length);
            }
        }

        public void AddBoat(Boat boat)
        { 
            this.boatList.Add(boat);
        }

        public void DeleteBoat(int boatId)
        {
            var item = boatList.SingleOrDefault(x => x.id == boatId);
            if (item != null)
            boatList.Remove(item);
        }

// Pick a boat ID and 
        public void UpdateBoat(Boat boatToUpdate, Boat newBoat)
        {
            boatToUpdate = newBoat;
        }


        public override string ToString()
        {
            string boats = "";

            foreach(Boat boat in this.boatList)
            {
                 boats += "  boat type: " + boat.boatType + "  length: " + boat.length + "  id: " + boat.id;
            }
            Console.WriteLine(boats);
            return boats;
        }
    }
}