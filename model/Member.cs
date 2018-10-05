using System;
using System.Collections.Generic;
using System.Linq;

namespace jolly_pirate
{
    class Member
    {
        private string _ssn;
        private string _name;
        private int _id;

        public List<Boat> boatList;

        public Member(string socialSecurityNumber, string fullName, int id)
        {
            SSN = socialSecurityNumber;
            Name = fullName;
            Id = id;
            this.boatList = new List<Boat>();
        }

        public string SSN
        {
            get { return _ssn; }
            set { _ssn = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public void getBoatList()
        {
            foreach (Boat boat in this.boatList)
            {
                Console.Write(" {0} - " + "Id: {1} " + "Type: {2} " + "Length: {3}\n",
                boatList.IndexOf(boat), boat.Id, boat.Type, boat.Length);
            }
        }

        public void AddBoat(Boat boat)
        { 
            this.boatList.Add(boat);
        }

        public void DeleteBoat(int boatId)
        {
            Boat boat = boatList.SingleOrDefault(x => x.Id == boatId);
            if (boat != null)
            boatList.Remove(boat);
        }
        
        public void UpdateBoat(Boat boatToUpdate, Boat newBoat)
        {
            boatToUpdate = newBoat;
        }


        public override string ToString()
        {
            string boats = "";

            foreach(Boat boat in this.boatList)
            {
                 boats += "  boat type: " + boat.Type + "  length: " + boat.Length + "  id: " + boat.Id;
            }
            Console.WriteLine(boats);
            return boats;
        }
    }
}