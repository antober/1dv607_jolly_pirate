using System;
using System.Collections.Generic;

namespace jolly_pirate
{
    class User
    {
        public string socialSecurityNumber;
        public string fullName;
        public int id;

        public List<Boat> boatList;

        //= new List<Boat>();

        // TODO: Have some type of way to Collect boats here.
        // TODO: Remove/ Add method as well.

        public User(string socialSecurityNumber, string fullName, int id)
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