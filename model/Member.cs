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
        private List<Boat> _boatList;

        public Member(string socialSecurityNumber, string fullName, int id)
        {
            SSN = socialSecurityNumber;
            Name = fullName;
            Id = id;
            BoatList = new List<Boat>();
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
            private set { _id = value; }
        }

        public List<Boat> BoatList
        {
            get { return _boatList; }
            private set { _boatList = value; }
        }

        public void AddBoat(Boat boat)
        { 
            BoatList.Add(boat);
        }

        public void DeleteBoat(int boatId)
        {
            Boat boat = BoatList.SingleOrDefault(x => x.Id == boatId);
            if (boat != null)
            BoatList.Remove(boat);
        }
    }
}