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


        public List<Boat> getBoatList()
        {
            return this.boatList;
        }

        public void AddBoat(Boat boat)
        {
            this.boatList.Add(boat);
        }

        //   public void removeBoat(/*ID*/)
        // {
        //     this.boatList.Remove(/*ID*/);
        // }

    }
}