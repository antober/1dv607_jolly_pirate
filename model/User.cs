using System;
using System.Collections.Generic;

namespace jolly_pirate
{
    class User
    {
        public string socialSecurityNumber;
        public string fullName;
        public string id;

        public List<Boat> boatList;

        public User(string socialSecurityNumber, string fullName, string id)
        {
            this.socialSecurityNumber = socialSecurityNumber;
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